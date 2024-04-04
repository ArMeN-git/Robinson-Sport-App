using RobinsonSportApp.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace RobinsonSportApp.Core.Models;

public class ContactFormModel
{
    [Required, MaxLength(ValidationLiterals.FirstNameMaxLength)]
    public string FirstName { get; set; }

    [Required, MaxLength(ValidationLiterals.LastNameMaxLength)]
    public string LastName { get; set; }

    [Required, RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = ErrorMessages.InvalidEmailAddress)]
    public string Email { get; set; }

    [Required, MinLength(ValidationLiterals.QuestionMinLength), MaxLength(ValidationLiterals.QuestionMaxLength)]
    public string Question { get; set; }
}
