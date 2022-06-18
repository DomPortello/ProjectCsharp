using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    internal class Stats
    {
        internal void WriteScore(Quizz quizz, User user)
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine($"Date\tNom\tScore\tErreurs");
            string nbQuestion = "";
            foreach (var wrongQues in quizz.WrongQuestions)
            {
                nbQuestion += wrongQues.Number + ",";
            }
            sw.WriteLine($"{DateTime.Today.ToShortDateString()} \t {user.FirstName}{user.LastName} \t {quizz.CorrectAnswers}/{quizz.Questions.Count} \t {nbQuestion}");
            File.WriteAllText(@".\Score.txt", sw.ToString());
        }
    }
}
