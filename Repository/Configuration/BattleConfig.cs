
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

internal class BattleConfig : IEntityTypeConfiguration<Battle>
{
    public void Configure(EntityTypeBuilder<Battle> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasData
            (
                new Battle { Id = 1, LoserHamsterId = 1, WinnerHamsterId = 2 },
                new Battle { Id = 2, LoserHamsterId = 3, WinnerHamsterId = 2 },
                new Battle { Id = 3, LoserHamsterId = 2, WinnerHamsterId = 4 }
            );
    }
}
