using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Quizz
    {
    

        public static string[] GetQuestions(string file)
        {
            

            string[] allQuestionsBrut = File.ReadAllLines(file);

            return allQuestionsBrut;
        }
    }
}
