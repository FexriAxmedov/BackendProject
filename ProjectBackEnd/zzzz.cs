using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackEnd
{
    class zzzz
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Task1");
            Console.WriteLine("2) Task2");
            Console.Write("\r\nSelect an option: ");
            switch   (Console.ReadLine())
            {
                case "1":
                    Fexri();
                    return true;
                case "2":
                    Ferid();
                    return true;
                default:
                    return true;
            }
        }

        private static string Fexri()
        {
            Console.WriteLine("nese yazi");
            return Console.ReadLine();
        }
        private static string Ferid()
        {
            Console.WriteLine("nese birsey");
            return Console.ReadLine();
        }
    }
}

