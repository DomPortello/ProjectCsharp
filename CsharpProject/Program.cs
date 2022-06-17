using CsharpProject;

//Console.WriteLine("Bienvenue sur le quizz de votre vie !");

//Console.WriteLine();

//Console.WriteLine("Merci de saisir votre nom");
//string? lastName = Console.ReadLine();
//Console.WriteLine("Merci de saisir votre prénom");
//string? firstName = Console.ReadLine();



<<<<<<< HEAD
//Quizz quizz = new Quizz();
//Quizz.Start(4);

//while (quizz.nbOfQuestions <= quizz.maxQuestions)
//{
//    AskQuestion;
//}


//CheckUser(identity);




string[] allLines = Quizz.GetQuestions("QCM.txt");

List<string> allLinesList = allLines.ToList();

for (int i = 0; i < allLinesList.Count(); i++)
{
    if (allLinesList[i].StartsWith("Question"))
    {
        Question question = new Question(allLinesList[i]);
        question.Answer = new List<Answer>();
        while (allLinesList[i] != string.Empty)
        {
            question.Answer.Add(new Answer(allLinesList[i]));
        }

        Console.WriteLine(question.Statement);

        foreach (var answer in question.Answer)
        {
            Console.WriteLine(answer.Text);
        }

    }
}

=======
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
>>>>>>> 686809190d72260224561d90cee0164ace43a994
