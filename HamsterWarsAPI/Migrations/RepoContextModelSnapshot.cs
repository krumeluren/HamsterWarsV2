﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Infrastructure.Repository;

#nullable disable

namespace Presentation.HamsterWarsAPI.Migrations
{
    [DbContext(typeof(RepoContext))]
    partial class RepoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("LoserHamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfPost")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WinnerHamsterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoserHamsterId");

                    b.HasIndex("WinnerHamsterId");

                    b.ToTable("Battles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LoserHamsterId = 1,
                            TimeOfPost = new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6542),
                            WinnerHamsterId = 2
                        },
                        new
                        {
                            Id = 2,
                            LoserHamsterId = 3,
                            TimeOfPost = new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6584),
                            WinnerHamsterId = 2
                        },
                        new
                        {
                            Id = 3,
                            LoserHamsterId = 2,
                            TimeOfPost = new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6586),
                            WinnerHamsterId = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.Models.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FavFood")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            FavFood = "Nuts",
                            Games = 0,
                            ImgName = "1.jpg",
                            Losses = 0,
                            Loves = "Running",
                            Name = "Hamster1",
                            Wins = 0
                        },
                        new
                        {
                            Id = 2,
                            Age = 2,
                            FavFood = "Carrot",
                            Games = 0,
                            ImgName = "2.jpg",
                            Losses = 0,
                            Loves = "Sleeping",
                            Name = "Hamster2",
                            Wins = 0
                        },
                        new
                        {
                            Id = 3,
                            Age = 3,
                            FavFood = "Lettuce",
                            Games = 0,
                            ImgName = "3.jpg",
                            Losses = 0,
                            Loves = "Climbing",
                            Name = "Hamster3",
                            Wins = 0
                        },
                        new
                        {
                            Id = 4,
                            Age = 4,
                            FavFood = "Spinach",
                            Games = 0,
                            ImgName = "4.jpg",
                            Losses = 0,
                            Loves = "Digging",
                            Name = "Hamster4",
                            Wins = 0
                        },
                        new
                        {
                            Id = 5,
                            Age = 5,
                            FavFood = "Banana",
                            Games = 0,
                            ImgName = "5.jpg",
                            Losses = 0,
                            Loves = "Jumping",
                            Name = "Hamster5",
                            Wins = 0
                        },
                        new
                        {
                            Id = 6,
                            Age = 6,
                            FavFood = "Carrot",
                            Games = 0,
                            ImgName = "6.jpg",
                            Losses = 0,
                            Loves = "Running",
                            Name = "Hamster6",
                            Wins = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Models.Battle", b =>
                {
                    b.HasOne("Domain.Entities.Models.Hamster", "LoserHamster")
                        .WithMany("BattlesLost")
                        .HasForeignKey("LoserHamsterId")
                        .OnDelete(DeleteBehavior.ClientSetNull);

                    b.HasOne("Domain.Entities.Models.Hamster", "WinnerHamster")
                        .WithMany("BattlesWon")
                        .HasForeignKey("WinnerHamsterId")
                        .OnDelete(DeleteBehavior.ClientSetNull);

                    b.Navigation("LoserHamster");
                    
                    b.Navigation("WinnerHamster");
                });
            
            modelBuilder.Entity("Domain.Entities.Models.Hamster", b =>
                {
                    b.Navigation("BattlesLost");

                    b.Navigation("BattlesWon");
                });
#pragma warning restore 612, 618
        }
    }
}
