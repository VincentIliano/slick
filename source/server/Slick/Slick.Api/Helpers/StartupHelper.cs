using Microsoft.Extensions.DependencyInjection;
using Slick.Repositories.Skills;
using Slick.Services.Skills;

namespace Slick.Api
{
    public static class StartupHelper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelService, SpecialisationLevelService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelRepository, SpecialisationLevelRepository>();
        }
    }
}
