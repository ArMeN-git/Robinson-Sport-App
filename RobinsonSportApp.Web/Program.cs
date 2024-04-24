using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.ServiceExtensions;
using RobinsonSportApp.Data;
using RobinsonSportApp.Data.Configurations;
using RobinsonSportApp.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://*:7193");
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
var connectionStrings = configuration.GetSection(ConnectionStringsConfig.ConnectionStrings).Get<ConnectionStringsConfig>();
services.AddDbContextPool<RobinsonSportAppDbContext>(o => o.UseSqlServer(connectionStrings.RobinsonSportAppDatabase));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
