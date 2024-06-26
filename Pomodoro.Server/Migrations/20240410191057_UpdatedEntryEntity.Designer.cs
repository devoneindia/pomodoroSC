﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pomodoro.Server.DbContexts;

#nullable disable

namespace Pomodoro.Server.Migrations
{
    [DbContext(typeof(EntryDbContext))]
    [Migration("20240410191057_UpdatedEntryEntity")]
    partial class UpdatedEntryEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pomodoro.Server.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("Date")
                        .HasColumnType("text")
                        .HasColumnName("date");

                    b.Property<string>("Devname")
                        .HasColumnType("text")
                        .HasColumnName("dev-name");

                    b.Property<string>("Endingtime")
                        .HasColumnType("text")
                        .HasColumnName("ending-time");

                    b.Property<string>("Startingtime")
                        .HasColumnType("text")
                        .HasColumnName("starting-time");

                    b.Property<string>("Totaltime")
                        .HasColumnType("text")
                        .HasColumnName("total-time");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user-id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("entry");
                });

            modelBuilder.Entity("Pomodoro.Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user-id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Pomodoro.Server.Models.Entry", b =>
                {
                    b.HasOne("Pomodoro.Server.Models.User", null)
                        .WithMany("entries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pomodoro.Server.Models.User", b =>
                {
                    b.Navigation("entries");
                });
#pragma warning restore 612, 618
        }
    }
}
