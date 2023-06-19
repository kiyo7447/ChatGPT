// See https://aka.ms/new-console-template for more information
using AzureNotificationHubConsoleApp.Services;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false)
    .AddEnvironmentVariables();

IConfiguration configuration = builder.Build();

string? notificationHubConnectionString = configuration["NotificationHubConnectionString"];
string? notificationHubName = configuration["NotificationHubName"];


//NotificationServiceを実体化して使用します。
var notificationService = new NotificationService(notificationHubConnectionString, notificationHubName);
notificationService.SendNotificationAsync("Hello, World!", new List<string>() { "uid-222", "tag2" }).Wait();

