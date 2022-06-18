using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    internal class User
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        public static void VerifierFormat(string name)
        {
            if (!(name.Any(char.IsLetter)))
            {
                throw new ArgumentException("Votre nom et prénom ne doivent contenir que des lettres");
            }  
        }
        public void SaisirFirstName(out string firstName)
        {
            string? reponse;
            try
            {
                Console.WriteLine("Saisir votre nom");
                reponse = Console.ReadLine();
                VerifierFormat(reponse);
                firstName = reponse;

            }
            catch (ArgumentException ex)
            {
                firstName = ex.Message;
                Console.WriteLine(firstName);
                SaisirFirstName(out string test);
            }
        }

        public void SaisirLastName(out string lastName)
        {
            string? reponse;
            try
            {
                Console.WriteLine("Saisir votre prénom");
                reponse = Console.ReadLine();
                VerifierFormat(reponse);
                lastName = reponse;

            }
            catch (ArgumentException ex)
            {
                lastName = ex.Message;
                Console.WriteLine(lastName);
                SaisirLastName(out string last);
            };
        }

    }
}
