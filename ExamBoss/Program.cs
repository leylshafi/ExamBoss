using Newtonsoft.Json;
using Serilog;
namespace ExamBoss;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
 ▄▄▄▄    ▒█████    ██████   ██████       ▄▄▄      ▒███████▒
▓█████▄ ▒██▒  ██▒▒██    ▒ ▒██    ▒      ▒████▄    ▒ ▒ ▒ ▄▀░
▒██▒ ▄██▒██░  ██▒░ ▓██▄   ░ ▓██▄        ▒██  ▀█▄  ░ ▒ ▄▀▒░ 
▒██░█▀  ▒██   ██░  ▒   ██▒  ▒   ██▒     ░██▄▄▄▄██   ▄▀▒   ░
░▓█  ▀█▓░ ████▓▒░▒██████▒▒▒██████▒▒ ██▓  ▓█   ▓██▒▒███████▒
░▒▓███▀▒░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░ ▒▓▒  ▒▒   ▓▒█░░▒▒ ▓░▒░▒
▒░▒   ░   ░ ▒ ▒░ ░ ░▒  ░ ░░ ░▒  ░ ░ ░▒    ▒   ▒▒ ░░░▒ ▒ ░ ▒
 ░    ░ ░ ░ ░ ▒  ░  ░  ░  ░  ░  ░   ░     ░   ▒   ░ ░ ░ ░ ░
 ░          ░ ░        ░        ░    ░        ░  ░  ░ ░    
      ░                              ░            ░        
                                                           ");
        Thread.Sleep(3000);
        Console.ResetColor();

        Menu.MainRun();

    }
}
