using RobinsonSportApp.Data.Entities.Identity;
using RobinsonSportApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinsonSportApp.Core.Managers.EventComments.NewFolder;

public class EventCommentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public long EventId { get; set; }
    public Event Event { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
}
