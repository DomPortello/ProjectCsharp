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




string[] allLines = Quizz.GetQuestions("QCM.txt");

List<string> allLinesList = allLines.ToList();

Question aQuestion = new Question();
aQuestion.Answer = new List<string>();

for (int i = 0; i < allLinesList.Count(); i++)
{
    if (allLinesList[i].StartsWith("Question"))
    {

        aQuestion.Statement = allLinesList[i];
        //allLinesList.Remove(line);


    }
    else if (allLinesList[i] == string.Empty)
    {
        break;
    }
    else
    {

        aQuestion.Answer.Add(allLinesList[i]);

    }

}

Console.WriteLine(aQuestion.Statement);

foreach (var answer in aQuestion.Answer)
{
    Console.WriteLine(answer);
}
