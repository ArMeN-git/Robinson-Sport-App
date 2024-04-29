namespace RobinsonSportApp.Core.Managers.Claims;

public interface IClaimsAccessor
{
    int UserId { get; set; }
    string Email { get; set; }
}
