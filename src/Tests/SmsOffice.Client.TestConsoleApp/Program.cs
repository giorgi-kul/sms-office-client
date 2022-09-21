using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmsOffice.Client;
using SmsOffice.Client.Interfaces;
using SmsOffice.Client.Models;

SmsOfficeClientOptions _options = new();
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configurationRoot = configuration.Build();

        configurationRoot.GetSection("SmsOffice").Bind(_options);
    })
    .ConfigureServices((_, services) =>
    {
        services.AddSmsOffice(opt =>
        {
            opt.BaseUrl = "http://smsoffice.ge/api";
            opt.ApiKey = "04308629d00c4bf7a1002e94d1e6462a";
        });

    })
    .Build();

HttpClient httpClient = host.Services.GetRequiredService<HttpClient>();

ISmsOfficeClient smsOfficeClient = host.Services.GetRequiredService<ISmsOfficeClient>();

SendSmsResult sendSmsResult = await smsOfficeClient.SendSms("TestApp", "595161617", "test2");

int balanceResult = await smsOfficeClient.GetBalance();