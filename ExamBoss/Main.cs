using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;

        static List<Worker> Workers = new List<Worker>();
        static List<Employer> Employers = new List<Employer>();
        static List<Guest> Guests = new List<Guest>();
        static List<Vacancy> Vacancies = new List<Vacancy>();


        public Menu(string[] options)
        {
            SelectedIndex = 0;
            Options = options;
        }

        #region MainDisplay
        private void DisplayOptions()
        {
            Console.WriteLine();
            for (int i = 0; i < Options.Length; i++)
            {
                string prefix;
                string currentOption = Options[i];
                if (SelectedIndex == i)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    prefix = "";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($"{prefix}<<{currentOption}>>");
            }
            Console.ResetColor();
        }
        public int Run()
        {

            ConsoleKey key;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo info = Console.ReadKey(true);
                key = info.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                        SelectedIndex = Options.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                        SelectedIndex = 0;
                }


            } while (key != ConsoleKey.Enter);
            return SelectedIndex;

        }

        #endregion

        #region ChooseJob
        public void RunJobMenu(int selectedInde)
        {

            var stringData = File.ReadAllText("Vacancies.json");
            if (stringData != null)
                Vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(stringData);

            for (int i = 0; i < Vacancies.Count; i++)
            {
                if (selectedInde == i)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"======= You choose {Vacancies[i].JobName}. Good luck in your job =======");
                    Console.ResetColor();
                    Console.WriteLine(Vacancies[i]);

                    Thread.Sleep(5000);
                }
            }
        }
        #endregion

        #region Worker
        public void RunChooseMenu(int selectedInd)
        {
            List<string> jobNames = new List<string>();

            switch (selectedInd)
            {

                case 0:
                    {
                        using FileStream fs = new FileStream("Vacancies.json", FileMode.Open);
                        Vacancies = System.Text.Json.JsonSerializer.Deserialize<List<Vacancy>>(fs);
                    }
                    for (int i = 0; i < Vacancies.Count; i++)
                    {
                        jobNames.Add(Vacancies[i].JobName);
                    }


                    Menu all = new Menu(jobNames.ToArray());
                    all.RunJobMenu(all.Run());

                    break;
                case 1:
                    string jobType;
                    Console.WriteLine("Please enter the job type that you're looking for");
                    jobType = Console.ReadLine();

                    for (int i = 0; i < Vacancies.FindAll(vacancy => vacancy.JobName == jobType).Count; i++)
                    {
                        jobNames.Add(Vacancies.FindAll(vacancy => vacancy.JobName == jobType)[i].JobName);
                    }
                    Menu selectedJobs = new Menu(jobNames.ToArray());
                    selectedJobs.RunJobMenu(selectedJobs.Run());
                    break;
                case 2:
                    double minSalary;
                    Console.WriteLine("Please enter the minimum salary that you're looking for");

                    try
                    {
                        minSalary = Convert.ToDouble(Console.ReadLine());

                        if (minSalary < 0)
                            throw new Exception("Salary can not be negative");

                        for (int i = 0; i < Vacancies.FindAll(vacancy => vacancy.Salary >= minSalary).Count; i++)
                        {
                            jobNames.Add(Vacancies.FindAll(vacancy => vacancy.Salary >= minSalary)[i].JobName);
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception occured " + e.Message);
                        Thread.Sleep(2000);
                        RunChooseMenu(2);
                    }

                    break;
                case 3:
                    break;
                default:
                    break;

            }
        }
        #endregion

        #region Employer
        public void RunEmpMenu(int selectedInd)
        {
            string? jobName, ageRange, education, content;
            double salary;
            switch (selectedInd)
            {
                case 0:
                    Console.WriteLine("For adding vacancy please fill the form: ");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Enter job name: ");
                    jobName = Console.ReadLine();
                    Console.WriteLine("Enter salary: ");
                    salary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter age range: ");
                    ageRange = Console.ReadLine();
                    Console.WriteLine("Enter education: ");
                    education = Console.ReadLine();
                    Console.WriteLine("Enter content: ");
                    content = Console.ReadLine();



                    if (jobName != null && ageRange != null && education != null && content != null)
                        Vacancies.Add(new Vacancy(jobName, salary, ageRange, education, content));
                    else RunMenu(0);

                    var jsonString = System.Text.Json.JsonSerializer.Serialize(Vacancies);
                    File.WriteAllText("Vacancies.json", jsonString);


                    Console.WriteLine("Vacancy added successfully");
                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
                case 1:
                    var stringData = File.ReadAllText("Workers.json");
                    if (stringData != null)
                    {
                        Console.WriteLine("Here is our successfull workers");
                        foreach (var worker in JsonConvert.DeserializeObject<List<Worker>>(stringData))
                        {
                            if (worker != null)
                            {
                                Console.WriteLine($"   ~{worker.Name} Do you want to see details? y/n");

                                switch (Console.ReadLine())
                                {
                                    case "y":
                                        Console.WriteLine(worker);
                                        break;
                                    case "n":
                                        RunEmpMenu(2);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else Console.WriteLine("No data");
                        }

                    }
                    else Console.WriteLine("There is no data");
                    Thread.Sleep(5000);
                    break;
                case 2:
                    MainRun();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Guest
        public void RunGuestMenu(int selectedInd)
        {
            string? jobName, ageRange, education, content;
            double salary;
            switch (selectedInd)
            {
                case 0:
                    var stringData = File.ReadAllText("Workers.json");
                    if (stringData != null)
                    {
                        Console.WriteLine("Here is our successfull workers");
                        foreach (var worker in JsonConvert.DeserializeObject<List<Worker>>(stringData))
                        {
                            Console.WriteLine($"   ~{worker.Name} Do you want to see details? y/n");

                            switch (Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine(worker);
                                    break;
                                case "n":
                                    RunEmpMenu(2);
                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                    else Console.WriteLine("There is no data");
                    Thread.Sleep(5000);

                    break;
                case 1:
                    var stringVacan = File.ReadAllText("Vacancies.json");
                    if (stringVacan != null)
                        Vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(stringVacan);
                    else Console.WriteLine("There is no data");
                    if (Vacancies != null)
                    {
                        Console.WriteLine("Here is vacancies");
                        foreach (var vacancy in Vacancies)
                        {
                            Console.WriteLine(vacancy);
                        }
                    }
                    else Console.WriteLine("There is no data");
                    Thread.Sleep(5000);


                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ChooseUser
        public void RunMenu(int selectedIndex)
        {
            int id;
            string? name, surname, city, phone;
            int age;

            switch (selectedIndex)
            {
                case 0:
                    try
                    {
                        Console.WriteLine("Welcome, please enter your name,surname,city,phone and age: ");
                        name = Console.ReadLine();
                        surname = Console.ReadLine();
                        city = Console.ReadLine();
                        phone = Console.ReadLine();
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("For continue you need to create your CV");
                        CV cV = CV.CreateCV();

                        if (name != null && surname != null && city != null && phone != null)
                        {
                            Workers.Add(new Worker(cV, name, surname, city, phone, age));
                            Menu.GetLogger().Information($"New Worker Joined");
                        }
                        else RunMenu(0);



                        var jsonString = JsonConvert.SerializeObject(Workers, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText("Workers.json", jsonString);
                        Console.WriteLine($"I'm happy to see you here {name} {surname}. Good luck");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Try Again");
                        RunMenu(0);


                    }

                    Thread.Sleep(5000);

                    string[] menuOpt = { "See all", "Enter job type", "Enter minimum salary", "Exit" };
                    Menu chooseMenu = new Menu(menuOpt);
                    chooseMenu.RunChooseMenu(chooseMenu.Run());
                    break;
                case 1:
                    try
                    {
                        Console.WriteLine("Welcome, please enter your name,surname,city,phone and age: ");
                        name = Console.ReadLine();
                        surname = Console.ReadLine();
                        city = Console.ReadLine();
                        phone = Console.ReadLine();
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Employers.Add(new Employer(name, surname, city, phone, age));
                        Menu.GetLogger().Information($"New Employer Joined");
                        Thread.Sleep(1000);

                    }
                    catch (Exception ex)
                    {
                        Menu.GetLogger().Error(ex.Message);
                        Console.WriteLine(ex.Message);
                        RunMenu(1);
                    }

                    var jsonStringEmp = JsonConvert.SerializeObject(Employers, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("Employers.json", jsonStringEmp);
                    string[] empMenuOp = { "Add vacancy", "See workers", "Exit" };
                    Menu empMenu = new Menu(empMenuOp);
                    while (true)
                    {
                        empMenu.RunEmpMenu(empMenu.Run());
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Welcome, please enter your name,surname,city,phone and age: ");
                        name = Console.ReadLine();
                        surname = Console.ReadLine();
                        city = Console.ReadLine();
                        phone = Console.ReadLine();
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Guests.Add(new Guest(name, surname, city, phone, age));
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Menu.GetLogger().Error(ex.Message);
                        Console.WriteLine(ex.Message);
                        RunMenu(2);
                    }
                    var jsonStringGuest = JsonConvert.SerializeObject(Employers, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("Guests.json", jsonStringGuest);
                    string[] guestMenuOp = { "See all workers", "See jobs", "Exit" };
                    Menu guestMenu = new Menu(guestMenuOp);
                    guestMenu.RunGuestMenu(guestMenu.Run());
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($@"====== Goodbye, Come Again ======

╔╗ ┌─┐┌─┐┌─┐ ╔═╗╔═╗
╠╩╗│ │└─┐└─┐ ╠═╣╔═╝
╚═╝└─┘└─┘└─┘o╩ ╩╚═╝
");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion


        public static Serilog.ILogger GetLogger()
        {
            string format = @"[{Timestamp:HH:mm:ss} {Level:u3}] {Message} {Exception} {MachineName} {ThreadId} {NewLine}";
            return Log.Logger = new LoggerConfiguration()
         .WriteTo.File("myLog.txt", outputTemplate: format)
         .WriteTo.Console(outputTemplate: format)
         .CreateLogger();

        }

        #region Main
        public static void MainRun()
        {
            string[] options = { "Worker", "Employer", "Guest", "Exit" };
            Menu menu = new Menu(options);
            while (true)
            {
                menu.RunMenu(menu.Run());
            }
        }
        #endregion
    }
}
