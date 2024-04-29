using RobinsonSportApp.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace RobinsonSportApp.Core.Managers.EventComments.NewFolder;

public class AddCommentModel
{
    public int UserId { get; set; }
    public long EventId { get; set; }
    [Required, MinLength(ValidationLiterals.CommentMinLength), MaxLength(ValidationLiterals.CommentMaxLength)]
    public string Comment { get; set; }
}
