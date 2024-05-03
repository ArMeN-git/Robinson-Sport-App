using Microsoft.AspNetCore.Identity;

namespace RobinsonSportApp.Data.Entities.Identity;

public class Role(string name) : IdentityRole<int>(name)
{
    public ICollection<User> Users { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
}
