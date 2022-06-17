using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    internal class Question
    {
        public Question(string line)
        {
            Statement = line;
        }

        public int Number { get; set; }
        public string Statement { get; set; }
        public List<Answer>? Answer { get; set; }
    }
}
