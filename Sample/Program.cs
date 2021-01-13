using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RightPerception.Story.SDK.EAV;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {

        static IConfigurationRoot _configuration;
        static IServiceProvider _serviceProvider;

        static Program()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", true)
                .Build();

            var services = ConfigureServices();
            _serviceProvider = services.BuildServiceProvider();
        }

        static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddOptions();
            services.Configure<StoryAttributesOptions>(_configuration.GetSection("StoryAttributes"));
            services.AddHttpClient("Attributes", (p, c) =>
            {
                var options = p.GetService<IOptions<StoryAttributesOptions>>().Value;
                c.BaseAddress = new Uri(options.Endpoint);
            })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; },
                        ClientCertificateOptions = ClientCertificateOption.Manual
                    };
                });

            services.AddStoryAttributesClient<StoryAttributesOptions>();
            services.AddTransient<WorkdaySample>();
            services.AddTransient<AttributesSample>();
            return services;
        }

        static ISample GetSample(string param) => param switch
        {
            "workday" => _serviceProvider.GetService<WorkdaySample>(),
            "attributes" => _serviceProvider.GetService<AttributesSample>(),
            _ => throw new NotImplementedException(),
        };

        static async Task Main(string[] args)
        {
            var sample = GetSample(args[0]);
            await sample.Run();
        }
    }
}
