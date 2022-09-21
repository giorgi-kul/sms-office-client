using Microsoft.Extensions.Configuration;
using SmsOffice.Client;
using SmsOffice.Client.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// ASP.NET Core service collection extentions for service configuration
    /// </summary>
    public static class IServiceCollectionExtentions
    {
        /// <summary>
        /// Add services required for iPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="settingsKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddSmsOffice(this IServiceCollection services, IConfiguration configuration, string settingsKey)
        {
            ConfigureServices(services);

            services.Configure<SmsOfficeClientOptions>(configuration.GetSection(settingsKey));

            return services;
        }

        /// <summary>
        /// Add services required for iPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddSmsOffice(this IServiceCollection services, Action<SmsOfficeClientOptions> options)
        {
            ConfigureServices(services);

            services.Configure(options);

            return services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISmsOfficeClient, SmsOfficeClient>();
            services.AddHttpClient<SmsOfficeClient, SmsOfficeClient>();
        }
    }
}