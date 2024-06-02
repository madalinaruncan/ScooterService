﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScooterService.Data;

#nullable disable

namespace ScooterService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240511202617_AddUserToken")]
    partial class AddUserToken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ScooterService.Entities.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("HoursOfWork")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("ReparationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReparationId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("ScooterService.Entities.Reparation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ScooterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ScooterId");

                    b.HasIndex("UserId");

                    b.ToTable("Reparations");
                });

            modelBuilder.Entity("ScooterService.Entities.Scooter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IssueDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<string>("ScooterOwner")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Scooters");
                });

            modelBuilder.Entity("ScooterService.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "allan.service@gmail.com",
                            Name = "Allan",
                            PasswordHash = "ascrvdvs",
                            Role = 1,
                            Token = " hjdgasdjhfs",
                            Username = "Allan"
                        });
                });

            modelBuilder.Entity("ScooterService.Entities.Issue", b =>
                {
                    b.HasOne("ScooterService.Entities.Reparation", null)
                        .WithMany("Issues")
                        .HasForeignKey("ReparationId");
                });

            modelBuilder.Entity("ScooterService.Entities.Reparation", b =>
                {
                    b.HasOne("ScooterService.Entities.Scooter", "Scooter")
                        .WithMany()
                        .HasForeignKey("ScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScooterService.Entities.User", "User")
                        .WithMany("Reparations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scooter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScooterService.Entities.Reparation", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("ScooterService.Entities.User", b =>
                {
                    b.Navigation("Reparations");
                });
#pragma warning restore 612, 618
        }
    }
}