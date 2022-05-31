
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

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
            new Hamster { Id = 1, Name = "Hamster1", Age = 1, FavFood = "Nuts", Loves = "Running", ImgName = "1.jpg" },
            new Hamster { Id = 2, Name = "Hamster2", Age = 2, FavFood = "Carrot", Loves = "Sleeping", ImgName = "2.jpg" },
            new Hamster { Id = 3, Name = "Hamster3", Age = 3, FavFood = "Lettuce", Loves = "Climbing", ImgName = "3.jpg" },
            new Hamster { Id = 4, Name = "Hamster4", Age = 4, FavFood = "Spinach", Loves = "Digging", ImgName = "4.jpg" },
            new Hamster { Id = 5, Name = "Hamster5", Age = 5, FavFood = "Banana", Loves = "Jumping", ImgName = "5.jpg" },
            new Hamster { Id = 6, Name = "Hamster6", Age = 6, FavFood = "Carrot", Loves = "Running", ImgName = "6.jpg" }
            );
    }
}
