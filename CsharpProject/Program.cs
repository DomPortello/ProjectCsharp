using CsharpProject;

Console.WriteLine("Bienvenue sur le quizz de votre vie !");

Console.WriteLine();

Console.WriteLine("Merci de saisir votre nom");
string? name = Console.ReadLine();
Console.WriteLine("Merci de saisir votre prénom");
string? lastName = Console.ReadLine();

StringReader sr = new StringReader();

//try
//{
//    createNewUser(name, lastName);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

//Quizz quizz = new Quizz();
//Quizz.Start(4);

//while (quizz.nbOfQuestions <= quizz.maxQuestions)
//{
//    AskQuestion;
//}


//CheckUser(identity);