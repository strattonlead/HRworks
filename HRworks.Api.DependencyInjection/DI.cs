using Microsoft.Extensions.DependencyInjection;

namespace HRworks.Api.DependencyInjection
{
    public static class DI
    {
        public static void AddHrWorksClient(this IServiceCollection services)
        {
            services.AddScoped<HRworksClient>();
        }
    }
}