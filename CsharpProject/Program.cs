using CsharpProject;

Console.WriteLine("Bienvenue sur le quizz de votre vie !\n");

User user = new User();
user.SetFullName();

Quizz quizz = new Quizz();
quizz.GetQuestions();
quizz.Play();

Stats.WriteScore(quizz, user);

bool wantStats = Tools.YesOrNoQuestion("Voulez-vous voir vos statistiques ?");
if (wantStats)
{
    Stats stats = new Stats();
    stats.GetStatsUser(user);
    Console.WriteLine(stats);
}

Tools.ExitQuestion();
Environment.Exit(0);