using CsharpProject;

Console.WriteLine("Bienvenue sur le quizz de votre vie !");

Console.WriteLine();

Console.WriteLine("Merci de saisir votre nom");
string? lastName = Console.ReadLine();
Console.WriteLine("Merci de saisir votre prénom");
string? firstName = Console.ReadLine();



try
{
    createNewUser(name, lastName);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Quizz quizz = new Quizz();
Quizz.Start(4);

while (quizz.nbOfQuestions <= quizz.maxQuestions)
{
    AskQuestion;
}


CheckUser(identity);

Quizz newQuizz = new Quizz();
newQuizz.GetQuestions("QCM.txt");

foreach (Question question in newQuizz.Questions)
{
    Console.WriteLine(question.Statement);
    foreach (Answer answer in question.Answers)
    {
        Console.WriteLine(answer.Text);
        Console.WriteLine(answer.Letter);
        Console.WriteLine(answer.IsCorrect);
    }
    
}
