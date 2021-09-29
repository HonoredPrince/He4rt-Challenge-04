using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Auth;
using Api.Service.Services;
using Api.Service.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITrainerService, TrainerService>();
            serviceCollection.AddTransient<IPokemonService, PokemonService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<ITokenService, TokenService>();
        }
    }
}
