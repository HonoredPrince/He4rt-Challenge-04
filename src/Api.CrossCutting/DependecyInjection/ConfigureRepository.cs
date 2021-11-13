using System;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<ITrainerRepository, TrainerRepository>();
            serviceCollection.AddScoped<IPokemonRepository, PokemonRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();


            if (Environment.GetEnvironmentVariable("DB_PROVIDER").ToLower() == "MYSQL".ToLower())
            {
                //var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=PokeAPI-Heart-Challenge;Uid=root;Pwd=451236";
                //For Docker
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                );
            }
            else
            {
                //If wants to use another type of database instead of MYSQL, define here
            }
        }
    }
}
