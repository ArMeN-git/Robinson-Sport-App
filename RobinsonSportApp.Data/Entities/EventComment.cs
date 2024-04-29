using RobinsonSportApp.Data.Entities.Identity;

namespace RobinsonSportApp.Data.Entities;

public class EventComment
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public long EventId { get; set; }
    public Event Event { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
}
