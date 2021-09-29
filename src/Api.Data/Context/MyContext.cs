using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TrainerEntity> Trainers { get; set; }
        public DbSet<PokemonEntity> Pokemons { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainerEntity>(new TrainerMap().Configure);
            modelBuilder.Entity<PokemonEntity>(new PokemonMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            AdminUserSeed.AddAdminUser(modelBuilder);
        }
    }
}
