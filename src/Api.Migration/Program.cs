using System;
using System.IO;
using Api.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Api.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<ConsoleStartup>()
                .Build();

            using (var context = (MyContext)webHost.Services.GetService(typeof(MyContext)))
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Done");
        }
    }
}
