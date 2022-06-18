using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Stats
    {
        public void WriteScore(Quizz quizz, User user)
        {
            string filePath = @".\Score.txt";
            StringWriter sw = new StringWriter();
            if (!File.Exists(filePath))
            {
                sw.WriteLine($"Date\tNom\tScore\tErreurs");
            }

            string nbQuestion = "";
            foreach (var wrongQues in quizz.WrongQuestions)
            {
                nbQuestion += wrongQues.Number + ",";
            }
            sw.WriteLine($"{DateTime.Today.ToShortDateString()} \t {user.FirstName} {user.LastName} \t {quizz.CorrectAnswers}/{quizz.Questions.Count} \t {nbQuestion}");
            File.AppendAllText(filePath, sw.ToString());
        }
    }
}
