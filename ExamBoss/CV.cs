using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{
    internal class CV
    {
        public string Speciality { get; }
        public string School { get; }
        public double PointOfEntranceExam { get; }
        public string Skills { get; }
        public string Companies { get; }
        public string WorkStartEndDate { get; }
        public string Languages { get; }
        public bool SpecialDiploma { get; }
        public string GithubLink { get; }
        public string Linkedin { get; }

        public CV(string speciality, string school, double pointOfEntranceExam, string skills, string companies, string workStartEndDate, string languages, bool specialDiploma, string githubLink, string linkedin)
        {
            Speciality = speciality;
            School = school;
            PointOfEntranceExam = pointOfEntranceExam;
            Skills = skills;
            Companies = companies;
            WorkStartEndDate = workStartEndDate;
            Languages = languages;
            SpecialDiploma = specialDiploma;
            GithubLink = githubLink;
            Linkedin = linkedin;
        }
        public static CV CreateCV()
        {
            try
            {
                Console.WriteLine("Enter your Speciality: ");
                string Speciality = Console.ReadLine();
                Console.WriteLine("Enter your School: ");
                string School = Console.ReadLine();
                Console.WriteLine("Enter your Point of Entrance Exam: ");
                double PointOfEntranceExam = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your Skills: ");
                string Skills = Console.ReadLine();
                Console.WriteLine("Enter your Companies: ");
                string Companies = Console.ReadLine();
                Console.WriteLine("Enter your Start and end date: ");
                string WorkStartEndDate = Console.ReadLine();
                Console.WriteLine("Enter Languages you know: ");
                string Languages = Console.ReadLine();
                Console.WriteLine("Do you have special diploma? if yes enter 1: ");
                int a = Convert.ToInt32(Console.ReadLine());
                bool SpecialDiploma = (a == 1) ? true : false;
                Console.WriteLine("Enter your Github link: ");
                string GithubLink = Console.ReadLine();
                Console.WriteLine("Enter your Linkedin: ");
                string Linkedin = Console.ReadLine();
                CV cv = new CV(Speciality, School, PointOfEntranceExam, Skills, Companies, WorkStartEndDate, Languages, SpecialDiploma, GithubLink, Linkedin);
                return cv;
            }
            catch (Exception ex)
            {
                Menu.GetLogger().Error($"Error ocurred...{ex.Message}");
                Console.WriteLine(ex.Message);

                return CreateCV();
            }
            
        }

        public override string ToString() => ($@"
Speciality: {Speciality},
School: {School},
Point of Entrance Exam: {PointOfEntranceExam},
Skills: {Skills},
Companies: {Companies},
Work start and end date: {WorkStartEndDate},
Languages: {Languages},
Special diploma: {SpecialDiploma},
Github link: {GithubLink},
Linkedin: {Linkedin}");
    }



}
