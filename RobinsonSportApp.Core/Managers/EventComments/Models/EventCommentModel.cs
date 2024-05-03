using RobinsonSportApp.Data.Entities;
using RobinsonSportApp.Data.Entities.Identity;

namespace RobinsonSportApp.Core.Managers.EventComments.NewFolder;

public class EventCommentModel
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public long EventId { get; set; }
    public Event Event { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
}
