namespace CsharpProject
{
    public class Stats
    {
        public int TotalGames { get; set; }
        public string AverageScore { get; set; }
        public SortedList<int, double> GoodPercents { get; set; }

        const string filePath = @"..\..\..\.\Score.txt";

        //écriture du score d'une partie dans un fichier texte
        public static void WriteScore(Quizz quizz, User user)
        {
            StringWriter sw = new();
            //écriture du nom des colonnes uniquement si le fichier n'existe pas encore
            if (!File.Exists(filePath))
            {
                sw.WriteLine($"Date\tNom\tScore\tErreurs");
            }

            string nbQuestion = "";
            foreach (var wrongQues in quizz.WrongQuestions)
            {
                nbQuestion += wrongQues.Number + ",";
            }
            nbQuestion = nbQuestion.Remove(nbQuestion.Length - 1);
            sw.WriteLine($"{DateTime.Today.ToShortDateString()} \t {user.FirstName} {user.LastName} \t {quizz.CorrectAnswers}/{quizz.Questions.Count} \t {nbQuestion}");
            File.AppendAllText(filePath, sw.ToString());
        }

        //calcul des statistique d'un joueur
        public void GetStatsUser(User user)
        {
            List<ScoreDetails> scoreDetailsList = GetScoresUser(user);
            double sumScore = 0;
            List<int> allErrors = new List<int>();

            foreach (ScoreDetails scoreDetails in scoreDetailsList)
            {
                TotalGames++;
                sumScore += double.Parse(scoreDetails.Score.Split('/')[0]);

                //liste de toutes les erreurs
                allErrors = allErrors.Concat(scoreDetails.ListErrors).ToList();
            }

            //grouper les erreurs par numero de questions
            //dictionnaire avec le numero de question comme clé et le % de bonnes réponses sur la question
            var goodPercentsDic = allErrors.GroupBy(i => i)
                                  .ToDictionary(i => i.Key, i => (double)(100 - (i.Count() * 100 / TotalGames)));
            //TODO: optimize
            GoodPercents = new SortedList<int, double>(goodPercentsDic);

            int nbQuestions = int.Parse(scoreDetailsList[0].Score.Split('/')[1]);

            for (int i = 1; i <= nbQuestions; i++)
            {
                if (!GoodPercents.ContainsKey(i))
                {
                    GoodPercents[i] = 100;
                }
            }

            AverageScore = Math.Round((sumScore / TotalGames), 2).ToString() + '/'
                           + int.Parse(scoreDetailsList[0].Score.Split('/')[1]);
        }

        public List<ScoreDetails> GetScoresUser(User user)
        {
            List<ScoreDetails> scoreDetailsList = new List<ScoreDetails>();

            string[] allLines = File.ReadAllLines(filePath);
            List<string> allScoresUser = new List<string>();


            foreach (var score in allLines)
            {
                if (score.Contains(user.FirstName) && score.Contains(user.LastName))
                {
                    allScoresUser.Add(score);
                }
            }

            foreach (var scoreDetailsRaw in allScoresUser)
            {
                ScoreDetails scoreDetails = new ScoreDetails();

                string[] tabVal = scoreDetailsRaw.Split('\t');

                scoreDetails.Date = DateTime.Parse(tabVal[0]);

                scoreDetails.Name = tabVal[1];

                scoreDetails.Score = tabVal[2];

                string[] errorsRaw = tabVal[3].Split(',');
                scoreDetails.ListErrors = new List<int>();
                foreach (var error in errorsRaw)
                {
                    scoreDetails.ListErrors.Add(int.Parse(error));
                }

                scoreDetailsList.Add(scoreDetails);
            }
            return scoreDetailsList;
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var test in GoodPercents)
            {
                s += $"Question { test.Key} : {Math.Round((test.Value), 2)}% de bonnes réponses \n";
            }
            return $"Nombre total de jeux : {TotalGames}\nScore moyen : {AverageScore}\n{s}";
        }
    }
}