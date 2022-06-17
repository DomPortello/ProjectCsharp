using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Quizz
    {
        public List<Question> Questions { get; set; }
        public Quizz()
        {
            Questions = new List<Question>();
        }

        public void GetQuestions(string file)
        {
            string[] allLines = File.ReadAllLines(file);
            List<string> allLinesList = allLines.ToList();

            for (int i = 0; i < allLinesList.Count(); i++)
            {

                if (allLinesList[i].StartsWith("Question"))
                {
                    Question aQuestion = new Question(allLinesList[i]);
                    aQuestion.Answers = new List<Answer>();

                    for (int j = 0; j < allLinesList.Count(); j++)
                    {
                        if ((allLinesList[j] != string.Empty) && !(allLinesList[j].StartsWith("Question")))
                        {
                            Answer anAnswer = new Answer(allLinesList[j]);
                            if (allLinesList[j][0] == '*')
                            {
                                anAnswer.IsCorrect = true;
                                anAnswer.Letter = allLinesList[j][1];
                            }
                            else
                            {
                                anAnswer.IsCorrect = false;
                                anAnswer.Letter = allLinesList[j][0];
                            }
                            aQuestion.Answers.Add(anAnswer);
                        }
                        else if (allLinesList[j] == string.Empty)
                        {
                            break;
                        }
                    }

                    Questions.Add(aQuestion);
                }
            }
        }
    }
}
