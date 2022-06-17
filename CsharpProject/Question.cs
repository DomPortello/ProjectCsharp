using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Question
    {
        public Question(string line)
        {
            Statement = line;
        }

        public int Number { get; set; }
        public string Statement { get; set; }
<<<<<<< HEAD
        public List<Answer>? Answer { get; set; }
=======
        public List<Answer> Answers { get; set; }

        public Question(string statement)
        {
            Statement = statement;
        }
>>>>>>> 686809190d72260224561d90cee0164ace43a994
    }
}
