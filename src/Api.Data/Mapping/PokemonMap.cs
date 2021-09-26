using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class PokemonMap : IEntityTypeConfiguration<PokemonEntity>
    {
        public void Configure(EntityTypeBuilder<PokemonEntity> builder)
        {
            builder.ToTable("Pokemon");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Name)
                .IsUnique();

            builder.Property(u => u.ImageUrl)
                .IsRequired();

            builder.Property(u => u.Attribute)
                .IsRequired();

            builder.HasMany<TrainerEntity>(u => u.Trainers);
        }
    }
}
