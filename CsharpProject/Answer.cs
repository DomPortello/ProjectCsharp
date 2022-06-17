using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class Answer
    {
        public Answer(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public char Letter { get; set; }
        public bool IsCorrect { get; set; }
    }
}
