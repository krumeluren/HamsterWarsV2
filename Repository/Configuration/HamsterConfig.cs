using Core.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configuration;
internal class HamsterConfig : IEntityTypeConfiguration<Hamster>
{
    public void Configure(EntityTypeBuilder<Hamster> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Age).IsRequired();
        builder.Property(p => p.FavFood).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Loves).IsRequired().HasMaxLength(100);
        builder.Property(p => p.ImgName).IsRequired().HasMaxLength(100);
        builder.HasData
            (
            new Hamster { Id = 1, Name = "Hamster1", Age = 1, FavFood = "Food1", Loves = "Loves1", ImgName = "hamster-1.jpg" },
            new Hamster { Id = 2, Name = "Hamster2", Age = 2, FavFood = "Food2", Loves = "Loves2", ImgName = "hamster-2.jpg" },
            new Hamster { Id = 3, Name = "Hamster3", Age = 3, FavFood = "Food3", Loves = "Loves3", ImgName = "hamster-3.jpg" },
            new Hamster { Id = 4, Name = "Hamster4", Age = 4, FavFood = "Food4", Loves = "Loves4", ImgName = "hamster-4.jpg" },
            new Hamster { Id = 5, Name = "Hamster5", Age = 5, FavFood = "Food5", Loves = "Loves5", ImgName = "hamster-5.jpg" },
            new Hamster { Id = 6, Name = "Hamster6", Age = 6, FavFood = "Food6", Loves = "Loves6", ImgName = "hamster-6.jpg" }
            );
    }
}
