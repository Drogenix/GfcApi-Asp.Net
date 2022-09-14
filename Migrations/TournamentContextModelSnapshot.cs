﻿// <auto-generated />
using System;
using Gfc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gfc.Migrations
{
    [DbContext(typeof(TournamentContext))]
    partial class TournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GfcWebApi.Models.Fight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstEndRating")
                        .HasColumnType("int");

                    b.Property<int>("FirstFighterId")
                        .HasColumnType("int");

                    b.Property<int>("IsComplete")
                        .HasColumnType("int");

                    b.Property<int>("IsTitleFight")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SecondEndRating")
                        .HasColumnType("int");

                    b.Property<int>("SecondFighterId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<string>("WinReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinnerNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstFighterId");

                    b.HasIndex("SecondFighterId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Fight");
                });

            modelBuilder.Entity("GfcWebApi.Models.Fighter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccurateHits")
                        .HasColumnType("int");

                    b.Property<int>("AccurateTakedowns")
                        .HasColumnType("int");

                    b.Property<int>("Byknockout")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Draw")
                        .HasColumnType("int");

                    b.Property<int>("FirstRoundWins")
                        .HasColumnType("int");

                    b.Property<int>("Lose")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHits")
                        .HasColumnType("int");

                    b.Property<int>("TotalTakedowns")
                        .HasColumnType("int");

                    b.Property<int>("WInByDecision")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Win")
                        .HasColumnType("int");

                    b.Property<int>("WinByKoTko")
                        .HasColumnType("int");

                    b.Property<int>("WinBySubmission")
                        .HasColumnType("int");

                    b.Property<int>("Winstreak")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fighter");
                });

            modelBuilder.Entity("GfcWebApi.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsComplete")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("GfcWebApi.Models.Fight", b =>
                {
                    b.HasOne("GfcWebApi.Models.Fighter", "FirstFighter")
                        .WithMany()
                        .HasForeignKey("FirstFighterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GfcWebApi.Models.Fighter", "SecondFighter")
                        .WithMany()
                        .HasForeignKey("SecondFighterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GfcWebApi.Models.Tournament", null)
                        .WithMany("Fights")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstFighter");

                    b.Navigation("SecondFighter");
                });

            modelBuilder.Entity("GfcWebApi.Models.Tournament", b =>
                {
                    b.Navigation("Fights");
                });
#pragma warning restore 612, 618
        }
    }
}
