namespace RobinsonSportApp.Core.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string MatchType { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Location { get; set; }
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }

    }
}
