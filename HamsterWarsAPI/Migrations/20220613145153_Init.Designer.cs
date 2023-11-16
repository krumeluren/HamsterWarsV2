﻿// <auto-generated />
using System;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamsterWarsAPI.Migrations
{
    [DbContext(typeof(RepoContext))]
    [Migration("20220613145153_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Domain.Entities.Models.Battle", b =>
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
                            TimeOfPost = new DateTime(2022, 6, 13, 16, 51, 53, 149, DateTimeKind.Local).AddTicks(1552),
                            WinnerHamsterId = 2
                        },
                        new
                        {
                            Id = 2,
                            LoserHamsterId = 3,
                            TimeOfPost = new DateTime(2022, 6, 13, 16, 51, 53, 149, DateTimeKind.Local).AddTicks(1587),
                            WinnerHamsterId = 2
                        },
                        new
                        {
                            Id = 3,
                            LoserHamsterId = 2,
                            TimeOfPost = new DateTime(2022, 6, 13, 16, 51, 53, 149, DateTimeKind.Local).AddTicks(1588),
                            WinnerHamsterId = 4
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Models.Hamster", b =>
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

                    b.Property<int?>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            FavFood = "Food1",
                            Games = 0,
                            ImgName = "hamster-1.jpg",
                            Losses = 0,
                            Loves = "Loves1",
                            Name = "Hamster1",
                            Wins = 0
                        },
                        new
                        {
                            Id = 2,
                            Age = 2,
                            FavFood = "Food2",
                            Games = 0,
                            ImgName = "hamster-2.jpg",
                            Losses = 0,
                            Loves = "Loves2",
                            Name = "Hamster2",
                            Wins = 0
                        },
                        new
                        {
                            Id = 3,
                            Age = 3,
                            FavFood = "Food3",
                            Games = 0,
                            ImgName = "hamster-3.jpg",
                            Losses = 0,
                            Loves = "Loves3",
                            Name = "Hamster3",
                            Wins = 0
                        },
                        new
                        {
                            Id = 4,
                            Age = 4,
                            FavFood = "Food4",
                            Games = 0,
                            ImgName = "hamster-4.jpg",
                            Losses = 0,
                            Loves = "Loves4",
                            Name = "Hamster4",
                            Wins = 0
                        },
                        new
                        {
                            Id = 5,
                            Age = 5,
                            FavFood = "Food5",
                            Games = 0,
                            ImgName = "hamster-5.jpg",
                            Losses = 0,
                            Loves = "Loves5",
                            Name = "Hamster5",
                            Wins = 0
                        },
                        new
                        {
                            Id = 6,
                            Age = 6,
                            FavFood = "Food6",
                            Games = 0,
                            ImgName = "hamster-6.jpg",
                            Losses = 0,
                            Loves = "Loves6",
                            Name = "Hamster6",
                            Wins = 0
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Models.Battle", b =>
                {
                    b.HasOne("Core.Domain.Entities.Models.Hamster", "LoserHamster")
                        .WithMany("BattlesLost")
                        .HasForeignKey("LoserHamsterId");

                    b.HasOne("Core.Domain.Entities.Models.Hamster", "WinnerHamster")
                        .WithMany("BattlesWon")
                        .HasForeignKey("WinnerHamsterId");

                    b.Navigation("LoserHamster");

                    b.Navigation("WinnerHamster");
                });

            modelBuilder.Entity("Core.Domain.Entities.Models.Hamster", b =>
                {
                    b.Navigation("BattlesLost");

                    b.Navigation("BattlesWon");
                });
#pragma warning restore 612, 618
        }
    }
}