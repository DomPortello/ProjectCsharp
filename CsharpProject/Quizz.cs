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
        public List<Question> WrongQuestions { get; set; }

        public int CorrectAnswers { get; set; }
        public Quizz()
        {
            Questions = new List<Question>();
            WrongQuestions = new List<Question>();
        }

        const string file = "QCM.txt";

        public void GetQuestions()
        {
            string[] allLines = File.ReadAllLines(file);
            List<string> allLinesList = allLines.ToList();

            for (int i = 0; i < allLinesList.Count(); i++)
            {

                if (allLinesList[i].StartsWith("Question"))
                {
                    Question aQuestion = new Question(allLinesList[i]);
                    aQuestion.Answers = new List<Answer>();

                    for (int j = i; j < allLinesList.Count(); j++)
                    {
                        if ((allLinesList[j] != string.Empty) && !(allLinesList[j].StartsWith("Question")))
                        {
                            Answer anAnswer = new Answer();
                            if (allLinesList[j][0] == '*')
                            {
                                anAnswer.IsCorrect = true;
                                anAnswer.Letter = allLinesList[j][1];
                                anAnswer.Text = allLinesList[j].Substring(1);
                                aQuestion.NbCorrectAnswers++;
                            }
                            else
                            {
                                anAnswer.IsCorrect = false;
                                anAnswer.Letter = allLinesList[j][0];
                                anAnswer.Text = allLinesList[j];
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
        internal void Start()
        {
            DisplayQuizz();
            DisplayScore();
            DisplayWrongAnswers();
        }

        private void DisplayWrongAnswers()
        {
            foreach (var ques in WrongQuestions)
            {
                Console.WriteLine(ques.Statement);
                foreach (var wer in ques.Answers)
                {
                    if (wer.IsCorrect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(wer.Text);
                    Console.ResetColor();
                }
            }
        }

        private void DisplayScore()
        {
            Console.Clear();
            Console.WriteLine($"Vous avez obtenu un score de {CorrectAnswers}/{Questions.Count()}");
            Console.WriteLine();
        }

        private void DisplayQuizz()
        {
            List<char> choices = new List<char>();
            foreach (var question in Questions)
            {
                Console.WriteLine(question.Statement);
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine(answer.Text);
                    choices.Add(answer.Letter);
                }
                string? reponse = Console.ReadLine();
                List<char> repo = reponse.ToUpper().ToList<char>();
                try
                {
                    checkFormat(reponse, repo, question, choices);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                checkAnswer(question, reponse);
            }
        }


        private void checkFormat(string reponse, List<char> repo, Question question, List<char> choices)
        {
            if (reponse != null && reponse.Any(char.IsLetter) && reponse.Count() <= question.Answers.Count())
            {
                if (repo.Distinct().Count() == repo.Count())
                {
                    foreach (var lett in repo)
                    {
                        if (!(choices.Contains(lett)))
                        {
                            throw new ArgumentOutOfRangeException("Merci de mettre les bonnes lettres pour que la réponse soit comptabilisée.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Merci de ne pas mettre plusieurs fois la même lettre.");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Merci de respecter le format de réponse qui est en majuscules sans espaces");
            };
        }

        private void checkAnswer(Question? question, string? reponse)
        {
            if (reponse.Count() == question.NbCorrectAnswers)
            {
                int compt = 0;
                foreach (var rep in question.Answers)
                {
                    if (reponse.Contains(rep.Letter) && rep.IsCorrect == true)
                    {
                        compt++;
                    }
                }
                if (compt == question.NbCorrectAnswers)
                {
                    CorrectAnswers++;
                }
                else
                {
                    WrongQuestions.Add(question);
                }
            }
            else
            {
                WrongQuestions.Add(question);
            }
        }
    }
}
