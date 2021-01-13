using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RightPerception.Story.SDK.EAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStoryAttributesClient<T>(this IServiceCollection services)
            where T : StoryAttributesOptions
        {
            services.AddTransient(p =>
            {
                var options = p.GetService<IOptions<T>>().Value;
                var clientFactory = p.GetService<IHttpClientFactory>();
                var client = clientFactory.CreateClient(options.HttpClientName);
                return new StoryAttributesClient(client);
            });
        }
    }
}
