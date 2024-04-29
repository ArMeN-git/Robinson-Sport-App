using IdentityModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RobinsonSportApp.Core.Managers.Claims;

internal class ClaimsAccessor(IHttpContextAccessor contextAccessor) : IClaimsAccessor
{
    public int UserId { get; set; } = Convert.ToInt32(contextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.Subject));
    public string Email { get; set; } = contextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.Email);
}
