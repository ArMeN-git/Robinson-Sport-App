namespace RobinsonSportApp.Core.Managers.EventComments.NewFolder;

public class AddCommentModel
{
    public int UserId { get; set; }
    public long EventId { get; set; }
    public string Comment { get; set; }
}
