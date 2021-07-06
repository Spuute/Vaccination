﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

namespace backend.Migrations
{
    [DbContext(typeof(VaccinationContext))]
    [Migration("20210704143011_Updated_Tables")]
    partial class Updated_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HealthCareEmployee")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MedicalCondition")
                        .HasColumnType("bit");

                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VaccinationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("backend.Model.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("FirstDose")
                        .HasColumnType("bit");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<bool>("SecondDose")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("backend.Model.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableDoses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AvailableDoses");
                });

            modelBuilder.Entity("backend.Model.Person", b =>
                {
                    b.HasOne("backend.Model.Vaccination", "Vaccination")
                        .WithMany("Persons")
                        .HasForeignKey("VaccinationId");

                    b.Navigation("Vaccination");
                });

            modelBuilder.Entity("backend.Model.Vaccination", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
