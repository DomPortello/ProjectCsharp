using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public static class Tools
    {
        //vérification string avec uniquement des lettres
        public static void CheckFormatLettersOnly(string? s, string message)
        {
            if (s != null)
            {
                foreach (char letter in s)
                {
                    if (!(char.IsLetter(letter)))
                    {
                        throw new ArgumentException(message + "\n");
                    }
                }
            }
        }

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

        public static bool YesOrNoQuestion(string question)
        {
            ConsoleKeyInfo cki;
            Console.Write($"\n{question} (O/N)\n\n");
            do
            {
                cki = Console.ReadKey(true);
            }

            while (cki.Key != ConsoleKey.O && cki.Key != ConsoleKey.N);

            if (cki.Key == ConsoleKey.O)
            {
                return true;
            }

            return false;           
        }
    }
}
