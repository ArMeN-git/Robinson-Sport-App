using RobinsonSportApp.Core.Enums;

namespace RobinsonSportApp.Core.Models;

public class MatchResult
{
    public int Id { get; set; }
    public string HomeTeamLogo { get; set; }
    public string AwayTeamLogo { get; set; }
    public string HomeTeamName { get; set; }
    public string AwayTeamName { get; set; }
    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; }
    public string Location { get; set; }
    public SportCategory SportCategory { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string AdditionalInfo { get; set; }
    public List<MatchComment> Comments { get; set; }
    public bool IsPastMatch => DateTime.UtcNow > EndTime;
    public bool IsLiveMatch => DateTime.UtcNow > StartTime && DateTime.UtcNow < EndTime;
    public bool IsFutureMatch => DateTime.UtcNow < StartTime;
}
