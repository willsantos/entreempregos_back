﻿// <auto-generated />
using System;
using EntreEmpregos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntreEmpregos.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230724144619_FixJobLevel")]
    partial class FixJobLevel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntreEmpregos.Api.Entities.JobLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("JobLevels");
                });

            modelBuilder.Entity("EntreEmpregos.Api.Entities.JobRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abbr")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("JobRegions");
                });

            modelBuilder.Entity("EntreEmpregos.Domain.Entities.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("EntreEmpregos.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Contract")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Exclusivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<int?>("JobRegionId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("Publication")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobRegionId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobJobLevel", b =>
                {
                    b.Property<Guid>("JobsId")
                        .HasColumnType("char(36)");

                    b.Property<int>("LevelsId")
                        .HasColumnType("int");

                    b.HasKey("JobsId", "LevelsId");

                    b.HasIndex("LevelsId");

                    b.ToTable("JobJobLevel");
                });

            modelBuilder.Entity("EntreEmpregos.Domain.Entities.Job", b =>
                {
                    b.HasOne("EntreEmpregos.Domain.Entities.Employer", null)
                        .WithMany("Jobs")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntreEmpregos.Api.Entities.JobRegion", null)
                        .WithMany("Jobs")
                        .HasForeignKey("JobRegionId");
                });

            modelBuilder.Entity("JobJobLevel", b =>
                {
                    b.HasOne("EntreEmpregos.Domain.Entities.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntreEmpregos.Api.Entities.JobLevel", null)
                        .WithMany()
                        .HasForeignKey("LevelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntreEmpregos.Api.Entities.JobRegion", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EntreEmpregos.Domain.Entities.Employer", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
