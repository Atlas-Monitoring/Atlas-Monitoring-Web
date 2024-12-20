using Atlas_Monitoring_Web.Components;
using Atlas_Monitoring_Web.Core.Application.Repositories;
using Atlas_Monitoring_Web.Core.Infrastructure.DataLayers;
using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Services;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Add Serilog
Log.Logger = new LoggerConfiguration()
    .CreateLogger();

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console(outputTemplate: "[{Timestamp:[yyyy-MM-dd HH:mm:ss.fff]} [{Level:u3}] ({SourceContext}) {Message}{NewLine}{Exception}]"));

builder.Services.AddLocalization();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add BlazorBootstrap
builder.Services.AddBlazorBootstrap();

//Scope DataLayer interface
builder.Services.AddScoped<IAutomateReportDataLayer, AutomateReportDataLayer>();
builder.Services.AddScoped<IComputerDataDataLayer, ComputerDataDataLayer>();
builder.Services.AddScoped<IComputerDataLayer, ComputerDataLayer>();
builder.Services.AddScoped<IComputerPartsDataLayer, ComputerPartsDataLayer>();
builder.Services.AddScoped<IComputerHardDriveDataLayer, ComputerHardDriveDataLayer>();
builder.Services.AddScoped<IDeviceDataLayer, DeviceDataLayer>();
builder.Services.AddScoped<IDeviceHistoryDataLayer, DeviceHistoryDataLayer>();
builder.Services.AddScoped<IDeviceSoftwareInstalledDataLayer, DeviceSoftwareInstalledDataLayer>();
builder.Services.AddScoped<IEntityDataLayer, EntityDataLayer>();
builder.Services.AddScoped<IUserDataLayer, UserDataLayer>();

//Scope Repository interface
builder.Services.AddScoped<IAutomateReportRepository, AutomateReportRepository>();
builder.Services.AddScoped<IComputerDataRepository, ComputerDataRepository>();
builder.Services.AddScoped<IComputerHardDriveRepository, ComputerHardDriveRepository>();
builder.Services.AddScoped<IComputerPartsRepository, ComputerPartsRepository>();
builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceHistoryRepository, DeviceHistoryRepository>();
builder.Services.AddScoped<IDeviceSoftwareInstalledRepository, DeviceSoftwareInstalledRepository>();
builder.Services.AddScoped<IEntityRepository, EntityRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Add HTTP Client
builder.Services.AddScoped(sp => new HttpClient());

//Add Custom Authentification
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredSessionStorage();

//Add Configuration
if (builder.Environment.IsDevelopment())
{
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    builder.Services.Configure<AppConfig>(config.GetSection("AppConfig"));
}
else
{
    builder.Services.Configure<AppConfig>(o =>
    {
        o.URLApi = Environment.GetEnvironmentVariable("URLApi").ToString();
    });
}

var app = builder.Build();

//Add supported language
string[] supportedCultures = ["en-US", "fr-FR"];
RequestLocalizationOptions localisationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localisationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
