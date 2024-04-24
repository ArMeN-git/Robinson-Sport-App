using Microsoft.AspNetCore.Identity;

namespace RobinsonSportApp.Data.Entities.Identity;

public class User : IdentityUser<int>
{
    public ICollection<Role> Roles { get; set; }
    public ICollection<UserLogin> UserLogins { get; set; }
}
