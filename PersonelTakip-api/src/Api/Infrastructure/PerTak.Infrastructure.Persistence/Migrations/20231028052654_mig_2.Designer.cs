﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PerTak.Infrastructure.Persistence.Context;

#nullable disable

namespace PerTak.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PerTakDbContext))]
    [Migration("20231028052654_mig_2")]
    partial class mig_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PerTak.Api.Domain.Models.Departmen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DepartmenName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Departmens");
                });

            modelBuilder.Entity("PerTak.Api.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PerTak.Api.Domain.Models.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DepartmenId")
                        .HasColumnType("uuid");

                    b.Property<string>("JobName")
                        .HasColumnType("text");

                    b.Property<string>("WorkerName")
                        .HasColumnType("text");

                    b.Property<DateTime>("WorkerTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmenId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("PerTak.Api.Domain.Models.Work", b =>
                {
                    b.HasOne("PerTak.Api.Domain.Models.Departmen", "Departmen")
                        .WithMany("works")
                        .HasForeignKey("DepartmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departmen");
                });

            modelBuilder.Entity("PerTak.Api.Domain.Models.Departmen", b =>
                {
                    b.Navigation("works");
                });
#pragma warning restore 612, 618
        }
    }
}
