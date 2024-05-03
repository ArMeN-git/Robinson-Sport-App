using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RobinsonSportApp.Core.Constants;
using RobinsonSportApp.Data;
using RobinsonSportApp.Data.Entities.Identity;

namespace RobinsonSportApp.Web.Extensions;

public static class IdentityExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();

        services.AddAuthorizationBuilder()
                .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Roles.Guest, Roles.Manager)
                .Build());

        services.AddIdentityCore<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-:@._+*' /\"";
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;

        })
        .AddRoles<Role>()
        .AddUserManager<UserManager<User>>()
        .AddRoleManager<RoleManager<Role>>()
        .AddSignInManager<SignInManager<User>>()
        .AddEntityFrameworkStores<RobinsonSportAppDbContext>()
        .AddDefaultTokenProviders();
    }
}
