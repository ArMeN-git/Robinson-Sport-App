using RobinsonSportApp.Data.Entities;

namespace RobinsonSportApp.Core.Managers.Events.Models;

public class EventModel
{
    public long Id { get; set; }
    public string Opponent1 { get; set; }
    public string Opponent2 { get; set; }
    public string Opponent1Logo { get; set; }
    public string Opponent2Logo { get; set; }
    public float Score1 { get; set; }
    public float Score2 { get; set; }
    public string Place { get; set; }
    public SportCategory SportCategory { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
