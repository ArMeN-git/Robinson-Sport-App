using Microsoft.AspNetCore.Identity;

namespace RobinsonSportApp.Data.Entities.Identity;

public class Role : IdentityRole<int>
{
    public ICollection<User> Users { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
}
