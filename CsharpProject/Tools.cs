using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public static class Tools
    {
        public static void ExitQuestion()
        {
            ConsoleKeyInfo cki;
            Console.Write("\nAppuyez sur Q pour quitter");
            do
            {               
                cki = Console.ReadKey(true);
            }

            while (cki.Key != ConsoleKey.Q);
        }

        public static void YesOrNoQuestion(string question)
        {
            ConsoleKeyInfo cki;
            Console.Write($"\n{question} (O/N)\n\n");
            do
            {
                cki = Console.ReadKey(true);
            }

            while (cki.Key != ConsoleKey.O && cki.Key != ConsoleKey.N);
        }
    }
}
