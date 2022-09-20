using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmsOffice.Client;
using SmsOffice.Client.Interfaces;
using SmsOffice.Client.Models;

SmsOfficeClientOptions options = new();
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configurationRoot = configuration.Build();

        configurationRoot.GetSection("SmsOffice").Bind(options);
    })
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient();
        services.AddScoped<ISmsOfficeClient, SmsOfficeClient>();
        services.AddScoped(opt => options);
    })
    .Build();

HttpClient httpClient = host.Services.GetRequiredService<HttpClient>();

ISmsOfficeClient smsOfficeClient = host.Services.GetRequiredService<ISmsOfficeClient>();

SendSmsResult sendSmsResult = await smsOfficeClient.SendSms("TestApp", "595161617", "test2");

int balanceResult = await smsOfficeClient.GetBalance();