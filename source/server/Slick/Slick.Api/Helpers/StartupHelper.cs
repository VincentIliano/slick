using Microsoft.Extensions.DependencyInjection;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Models.Skills;
using Slick.Repositories;
using Slick.Services.Contracts;
using Slick.Services.People;
using Slick.Services.Skills;

namespace Slick.Api
{
    public static class StartupHelper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelService, SpecialisationLevelService>();
            services.AddTransient<IConsultantService, ConsultantService>();
            services.AddTransient<IContractService, ContractService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEntityRepository<SpecialisationLevel>, EntityRepository<SpecialisationLevel>>();
            services.AddTransient<IEntityRepository<Consultant>, EntityRepository<Consultant>>();
            services.AddTransient<IEntityRepository<Contract>, EntityRepository<Contract>>();
        }
    }
}
