using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Quizz
    {
        public List<Question> Questions { get; }
        public List<Question> WrongQuestions { get; }
        public int CorrectAnswers { get; private set; }
        public Quizz()
        {
            Questions = new List<Question>();
            WrongQuestions = new List<Question>();
        }

        const string file = "QCM.txt";

        //méthode pour stocker chaque question avec ces réponses dans un nouvel objet Question
        public void GetQuestions()
        {
            string[] allLines = File.ReadAllLines(file);
            List<string> allLinesList = allLines.ToList();
            int nbQuestion = 0;

            for (int i = 0; i < allLinesList.Count; i++)
            {
                if (allLinesList[i].StartsWith("Question"))
                {
                    nbQuestion++;

                    //initialisation d'un nouvel objet Question
                    Question aQuestion = new(allLinesList[i])
                    {
                        Number = nbQuestion,
                    };

                    for (int j = i; j < allLinesList.Count; j++)
                    {
                        if ((allLinesList[j] != string.Empty) && !(allLinesList[j].StartsWith("Question")))
                        {
                            Answer anAnswer = new();
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

        //Méthode permettant de faire une partie complète
        public void Play()
        {
            DisplayQuizz();
            DisplayScore();
            DisplayWrongAnswers();
        }

        //affichage de chaque question du quizz après réponse de l'utilisateur
        private void DisplayQuizz()
        {

            foreach (var question in Questions)
            {
                List<char> choiceLetters = new();
                bool isFormatOk = false;
                do
                {
                    Console.ResetColor();
                    Console.WriteLine("\n" + question.Statement);

                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine(answer.Text);
                        choiceLetters.Add(answer.Letter);
                    }

                    Console.WriteLine("\nBonne(s) réponse(s) ? :");
                    string? givenAnswerRaw = Console.ReadLine();

                    try
                    {
                        CheckFormat(givenAnswerRaw, question, choiceLetters);
                        CheckAnswer(givenAnswerRaw, question);
                        isFormatOk = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (!isFormatOk);
            }
        }

        //réaffichage des questions ayant obtenu une reponse fausse et mise en valeur de la ou les bonne(s) réponse(s)
        private void DisplayWrongAnswers()
        {
            foreach (var question in WrongQuestions)
            {
                Console.WriteLine(question.Statement);

                foreach (var answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(answer.Text);
                    Console.ResetColor();
                }
            }
        }

        //affichage du score
        private void DisplayScore()
        {
            Console.Clear();
            Console.WriteLine($"Vous avez obtenu un score de {CorrectAnswers}/{Questions.Count}");
            Console.WriteLine();
        }

        //vérifications du format de la réponse saisie par l'utilisateur
        private void CheckFormat(string? givenAnswerRaw, Question question, List<char> choiceLetters)
        {
            if (givenAnswerRaw != null
                && givenAnswerRaw.Any(char.IsLetter)
                && givenAnswerRaw.Length <= question.Answers.Count
               )
            {
                List<char> givenAnswerLetters = givenAnswerRaw.ToUpper().ToList<char>();

                if (givenAnswerLetters.Distinct().Count() == givenAnswerLetters.Count)
                {
                    foreach (var letter in givenAnswerLetters)
                    {
                        if (!(choiceLetters.Contains(letter)))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            throw new ArgumentException("Merci de mettre les bonnes lettres pour que la réponse soit comptabilisée.");

                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new ArgumentException("Merci de ne pas mettre plusieurs fois la même lettre.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new ArgumentException("Merci de respecter le format de réponse qui est en majuscules sans espaces");
            };
        }


        //vérification si la réponse de l'utilisateur est juste
        private void CheckAnswer(string? givenAnswerRaw, Question question)
        {
            if (givenAnswerRaw != null && givenAnswerRaw.Length == question.NbCorrectAnswers)
            {
                int compt = 0;
                foreach (var possibleAnswer in question.Answers)
                {
                    if (givenAnswerRaw.ToUpper().Contains(possibleAnswer.Letter) && possibleAnswer.IsCorrect == true)
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
