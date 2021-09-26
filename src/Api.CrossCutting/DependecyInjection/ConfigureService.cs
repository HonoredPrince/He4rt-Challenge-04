using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITrainerService, TrainerService>();
        }
    }
}
