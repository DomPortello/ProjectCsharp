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

        public void SetFullName()
        {
            GetFullName(out string? firstName, out string? lastName);
            FirstName = firstName;
            LastName = lastName;
        }

        private void CheckFormat(string? name)
        {
            if (name != null)
            {
                foreach (char letter in name)
                {
                    if (!(char.IsLetter(letter)))
                    {
                        throw new ArgumentException("Votre nom et prénom ne doivent contenir que des lettres");
                    }
                }
            }           
        }

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
                    CheckFormat(givenFirstName);
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
                    CheckFormat(givenLastName);
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
