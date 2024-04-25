using RobinsonSportApp.Data.Entities;

namespace RobinsonSportApp.Core.Managers.Events.Models;

public class AddEventModel
{
    public string Opponent1 { get; set; }
    public string Opponent2 { get; set; }
    public string Score1 { get; set; }
    public string Score2 { get; set; }
    public string Place { get; set; }
    public SportCategory SportCategory { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
