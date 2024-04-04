using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinsonSportApp.Core.Models
{
    public class Match
    {
        public string matchType { get; set; }
        public DateTime date { get; set; }
        public string place { get; set; }
        public string location {  get; set; }
        public string firstTeam { get; set; }
        public string secondTeam {  get; set; }

    }
}
