using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class ScoreDetails
    {
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public string? Score { get; set; }
        public List<int>? ListErrors { get; set; }
    }
}
