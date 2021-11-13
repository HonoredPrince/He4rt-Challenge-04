using System;
using Api.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Migration
{
    public class ConsoleStartup
    {
        public ConsoleStartup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=PokeAPI-Heart-Challenge;Uid=root;Pwd=451236";
            //For Docker Support
            var connectionString = "Persist Security Info=True;Server=db;Port=3306;Database=pokeapi-heart-challenge;Uid=root;Pwd=docker;SslMode=none;";

            //.. for test
            Console.WriteLine(connectionString);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=PokeAPI-Heart-Challenge;Uid=root;Pwd=451236";
            //For Docker Support
            var connectionString = "Persist Security Info=True;Server=db;Port=3306;Database=pokeapi-heart-challenge;Uid=root;Pwd=docker;SslMode=none;";

            services.AddDbContext<MyContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
