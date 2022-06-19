using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Question
    {
        public int Number { get; set; }
        public string Statement { get; }
        public List<Answer> Answers { get; }
        public int NbCorrectAnswers { get; set; }
        public Question(string statement)
        {
            Statement = statement;
            Answers = new List<Answer>();
        }
    }
}
