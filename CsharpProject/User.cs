using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class User
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        //stockage des attributs de l'utilisateur dans l'instance courante
        public void SetFullName()
        {
            GetFullName(out string? firstName, out string? lastName);
            FirstName = firstName;
            LastName = lastName;
        }

        //récupération du nom et du prénom saisis
        private void GetFullName(out string? firstName, out string? lastName)
        {
            bool isFormatOk = false;
            firstName = string.Empty;
            lastName = string.Empty;
            
            while (!isFormatOk)
            {
                try
                {
                    Console.WriteLine("Veuillez saisir votre prénom");
                    string? givenFirstName = Console.ReadLine();
                    Tools.CheckFormatLettersOnly(
                        givenFirstName,
                        "Votre prénom ne doit contenir que des lettres"
                        );
                    firstName = givenFirstName;
                    isFormatOk = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            isFormatOk = false;

            while (!isFormatOk)
            {
                try
                {
                    Console.WriteLine("Veuillez saisir votre nom");
                    string? givenLastName = Console.ReadLine();
                    Tools.CheckFormatLettersOnly(
                        givenLastName,
                        "Votre nom ne doit contenir que des lettres"
                        );
                    lastName = givenLastName;
                    isFormatOk = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
