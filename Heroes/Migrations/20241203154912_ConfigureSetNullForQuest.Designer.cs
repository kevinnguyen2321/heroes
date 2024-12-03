﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Heroes.Migrations
{
    [DbContext(typeof(HeroesDbContext))]
    [Migration("20241203154912_ConfigureSetNullForQuest")]
    partial class ConfigureSetNullForQuest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Heroes.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EquipmentTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("HeroId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("HeroId");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A legendary sword said to be unbreakable and capable of cutting through any material.",
                            EquipmentTypeId = 1,
                            Name = "Excalibur",
                            Weight = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Description = "Armor forged from the scales of an ancient dragon, providing unmatched durability.",
                            EquipmentTypeId = 2,
                            Name = "Dragon Scale Armor",
                            Weight = 15.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "A shield imbued with divine power to repel even the fiercest attacks.",
                            EquipmentTypeId = 3,
                            Name = "Aegis",
                            Weight = 6.0
                        },
                        new
                        {
                            Id = 4,
                            Description = "A helmet that grants the wearer heightened perception and clarity of thought.",
                            EquipmentTypeId = 4,
                            Name = "Helm of Insight",
                            Weight = 3.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lightweight boots that allow the wearer to move with incredible speed.",
                            EquipmentTypeId = 5,
                            Name = "Boots of Swiftness",
                            Weight = 2.0
                        },
                        new
                        {
                            Id = 6,
                            Description = "Gauntlets that grant the wearer immense physical power.",
                            EquipmentTypeId = 6,
                            Name = "Gauntlets of Strength",
                            Weight = 5.0
                        },
                        new
                        {
                            Id = 7,
                            Description = "A mystical ring that slows the effects of aging and enhances magical abilities.",
                            EquipmentTypeId = 7,
                            Name = "Ring of Eternity",
                            Weight = 0.10000000000000001
                        },
                        new
                        {
                            Id = 8,
                            Description = "An enchanted amulet that creates a magical barrier around the wearer.",
                            EquipmentTypeId = 8,
                            Name = "Amulet of Protection",
                            Weight = 0.5
                        },
                        new
                        {
                            Id = 9,
                            Description = "A potion that restores health and vitality when consumed.",
                            EquipmentTypeId = 9,
                            Name = "Healing Potion",
                            Weight = 0.29999999999999999
                        },
                        new
                        {
                            Id = 10,
                            Description = "A magical scroll containing the spell to cast a devastating fireball.",
                            EquipmentTypeId = 10,
                            Name = "Scroll of Fireball",
                            Weight = 0.20000000000000001
                        });
                });

            modelBuilder.Entity("Heroes.Models.EquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Weapon"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Armor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shield"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Helmet"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Boots"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Gloves"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ring"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Amulet"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Potion"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Scroll"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HeroClassId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("QuestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HeroClassId");

                    b.HasIndex("QuestId");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A brave knight seeking redemption.",
                            HeroClassId = 1,
                            Level = 10,
                            Name = "Arthas",
                            QuestId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "A powerful mage wielding frost magic.",
                            HeroClassId = 2,
                            Level = 12,
                            Name = "Jaina",
                            QuestId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "A shaman connected to the elements.",
                            HeroClassId = 3,
                            Level = 15,
                            Name = "Thrall",
                            QuestId = 4
                        },
                        new
                        {
                            Id = 4,
                            Description = "A skilled ranger turned dark.",
                            HeroClassId = 4,
                            Level = 20,
                            Name = "Sylvanas"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A demon hunter seeking vengeance.",
                            HeroClassId = 5,
                            Level = 25,
                            Name = "Illidan"
                        });
                });

            modelBuilder.Entity("Heroes.Models.HeroClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HeroClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Paladin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ranger"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sorcerer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rogue"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Barbarian"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Complete")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Complete = false,
                            Description = "The princess has been captured by the dark sorcerer. Travel to the enchanted castle and bring her back safely.",
                            Name = "Rescue the Princess"
                        },
                        new
                        {
                            Id = 2,
                            Complete = false,
                            Description = "A ferocious dragon has been terrorizing the nearby villages. Slay the beast to restore peace.",
                            Name = "Defeat the Dragon"
                        },
                        new
                        {
                            Id = 3,
                            Complete = false,
                            Description = "The ancient artifact has been stolen by a band of thieves. Recover it from their hidden lair.",
                            Name = "Retrieve the Lost Artifact"
                        },
                        new
                        {
                            Id = 4,
                            Complete = false,
                            Description = "Few have ventured into the Forbidden Forest and returned. Uncover its secrets and report back.",
                            Name = "Explore the Forbidden Forest"
                        },
                        new
                        {
                            Id = 5,
                            Complete = false,
                            Description = "Ensure the caravan reaches its destination safely through treacherous territory.",
                            Name = "Escort the Caravan"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Equipment", b =>
                {
                    b.HasOne("Heroes.Models.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes.Models.Hero", null)
                        .WithMany("Equipments")
                        .HasForeignKey("HeroId");

                    b.Navigation("EquipmentType");
                });

            modelBuilder.Entity("Heroes.Models.Hero", b =>
                {
                    b.HasOne("Heroes.Models.HeroClass", "HeroClass")
                        .WithMany()
                        .HasForeignKey("HeroClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes.Models.Quest", "Quest")
                        .WithMany("Heroes")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeroClass");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("Heroes.Models.Hero", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("Heroes.Models.Quest", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}