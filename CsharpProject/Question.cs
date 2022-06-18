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
        public string Statement { get; set; }
        public List<Answer> Answers { get; set; }
        public int NbCorrectAnswers { get; set; }
        public Question(string statement)
        {
            Statement = statement;
        }
    }
}
