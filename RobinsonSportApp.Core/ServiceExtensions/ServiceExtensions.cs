using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RobinsonSportApp.Core.Managers.Subscription;
using RobinsonSportApp.Core.Services.Email;
using RobinsonSportApp.Core.Services.Email.Settings;
using SendGrid.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace RobinsonSportApp.Core.ServiceExtensions;

public static class ServiceExtensions
{
    public static void AddEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSendGrid(options =>
        options.ApiKey = configuration.GetSection(nameof(EmailSettings))
        .GetValue<string>(nameof(EmailSettings.ApiKey)));

        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        services.AddScoped<IEmailService, EmailService>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionManager, SubscriptionManager>();
    }
}
