using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.Mappings;
using RobinsonSportApp.Core.ServiceExtensions;
using RobinsonSportApp.Data;
using RobinsonSportApp.Data.Configurations;
using RobinsonSportApp.Web.Components;
using RobinsonSportApp.Web.Components.Account;
using RobinsonSportApp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://*:7193");
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
var connectionStrings = configuration.GetSection(ConnectionStringsConfig.ConnectionStrings).Get<ConnectionStringsConfig>();
services.AddDbContextPool<RobinsonSportAppDbContext>(o => o.UseSqlServer(connectionStrings.RobinsonSportAppDatabase));

services.AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddCascadingAuthenticationState();
services.AddScoped<IdentityUserAccessor>();
services.AddScoped<IdentityRedirectManager>();
services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

services.AddAutoMapper(typeof(AutoMapperProfileConfiguration));
services.AddManagers();
services.AddEmail(configuration);

services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});
services.AddHttpContextAccessor();
services.ConfigureIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

await using var scope = app.Services.CreateAsyncScope();
var context = scope.ServiceProvider.GetRequiredService<RobinsonSportAppDbContext>();
await context.Database.MigrateAsync();

await app.RunAsync();
