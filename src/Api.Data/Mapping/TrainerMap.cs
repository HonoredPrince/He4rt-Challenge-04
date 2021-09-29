using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TrainerMap : IEntityTypeConfiguration<TrainerEntity>
    {
        public void Configure(EntityTypeBuilder<TrainerEntity> builder)
        {
            builder.ToTable("Trainer");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Name)
                .IsUnique();

            builder.Property(u => u.Region)
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired();

            builder.HasOne(u => u.User);

            builder.HasMany<PokemonEntity>(u => u.Pokemons);
        }
    }
}
