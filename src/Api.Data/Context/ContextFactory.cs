using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=PokeAPI-Heart-Challenge;Uid=root;Pwd=451236";
            //For Docker Support
            var connectionString = "Persist Security Info=True;Server=db;Port=3306;Database=pokeapi-heart-challenge;Uid=root;Pwd=docker;SslMode=none;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new MyContext(optionsBuilder.Options);
        }
    }
}
