using CsharpProject;

Console.WriteLine("Bienvenue sur le quizz de votre vie !\n");

//Console.WriteLine();

User user = new User();

user.SetFullName();

//user.SaisirFirstName(out string firstName);
//user.SaisirLastName(out string lastName);

//user.FirstName = firstName;
//user.LastName = lastName;
Console.Clear();
Console.WriteLine(user.FirstName);
Console.WriteLine(user.LastName);

Quizz quizz = new Quizz();
quizz.GetQuestions();
quizz.Play();

Stats stats = new Stats();
stats.WriteScore(quizz, user);
Console.ReadKey();