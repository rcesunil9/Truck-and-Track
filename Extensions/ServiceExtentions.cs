
using Microsoft.Extensions.DependencyInjection;

namespace TrucknDriver.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
        //    services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
