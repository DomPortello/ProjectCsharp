using CsharpProject;

Console.WriteLine("Bienvenue sur le quizz de votre vie !\n");

User user = new User();
user.SetFullName();

Quizz quizz = new Quizz();
quizz.GetQuestions();
quizz.Play();

Stats.WriteScore(quizz, user);

//TODO : MANAGE EXCEPTIONS FOR ANSWERS TO STAT AND QUIT

Console.WriteLine("Voulez-vous voir vos statistiques ? (O/N)");
char repStats = char.Parse(Console.ReadLine());
Console.Clear();
if (repStats == 'O' || repStats == 'o')
{
    Stats stats = new Stats();
    stats.GetStatsUser(user);
    Console.WriteLine(stats);
}

Console.WriteLine("Appuyez sur Q pour quitter");
char repEnd = char.Parse(Console.ReadLine());

if (repEnd == 'Q' || repEnd == 'q')
{
    Environment.Exit(0);
}