using Atlas_Monitoring_Web.Components;
using Atlas_Monitoring_Web.Core.Application.Repositories;
using Atlas_Monitoring_Web.Core.Infrastructure.DataLayers;
using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
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
builder.Services.AddScoped<IComputerDataDataLayer, ComputerDataDataLayer>();
builder.Services.AddScoped<IComputerDataLayer, ComputerDataLayer>();
builder.Services.AddScoped<IComputerPartsDataLayer, ComputerPartsDataLayer>();
builder.Services.AddScoped<IComputerHardDriveDataLayer, ComputerHardDriveDataLayer>();

//Scope Repository interface
builder.Services.AddScoped<IComputerDataRepository, ComputerDataRepository>();
builder.Services.AddScoped<IComputerHardDriveRepository, ComputerHardDriveRepository>();
builder.Services.AddScoped<IComputerPartsRepository, ComputerPartsRepository>();
builder.Services.AddScoped<IComputerRepository, ComputerRepository>();

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
    IConfiguration config = new ConfigurationBuilder().Build();

    AppConfig AppConfig = new();
    AppConfig.URLApi = Environment.GetEnvironmentVariable("URLApi").ToString();

    Log.Information($"API URL = {AppConfig.URLApi}");

    config.Bind("AppConfig", AppConfig);
    builder.Services.Configure<AppConfig>(config.GetSection("AppConfig"));
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
