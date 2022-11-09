﻿// <auto-generated />
using System;
using Gesc.Api.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gesc.Api.Datas.Migrations
{
    [DbContext(typeof(SchoolConfigDbContext))]
    partial class SchoolConfigDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CycleFiliere", b =>
                {
                    b.Property<Guid>("CyclesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilieresId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CyclesId", "FilieresId");

                    b.HasIndex("FilieresId");

                    b.ToTable("CycleFiliere");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Cycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cygle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Departement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cygle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EcoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EcoleId");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Ecole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cygle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ecoles");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Filiere", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cygle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.FiliereCycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CycleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FiliereId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.HasIndex("FiliereId");

                    b.ToTable("FiliereCycles");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Niveau", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FiliereCycleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValeurCycle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FiliereCycleId");

                    b.ToTable("Niveaux");
                });

            modelBuilder.Entity("CycleFiliere", b =>
                {
                    b.HasOne("Gesc.Api.Modeles.Config.Cycle", null)
                        .WithMany()
                        .HasForeignKey("CyclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gesc.Api.Modeles.Config.Filiere", null)
                        .WithMany()
                        .HasForeignKey("FilieresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Departement", b =>
                {
                    b.HasOne("Gesc.Api.Modeles.Config.Ecole", "Ecole")
                        .WithMany("Departements")
                        .HasForeignKey("EcoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ecole");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Filiere", b =>
                {
                    b.HasOne("Gesc.Api.Modeles.Config.Departement", "Departement")
                        .WithMany("Filieres")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.FiliereCycle", b =>
                {
                    b.HasOne("Gesc.Api.Modeles.Config.Cycle", "Cycle")
                        .WithMany("FiliereCycles")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gesc.Api.Modeles.Config.Filiere", "Filiere")
                        .WithMany("FiliereCycles")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cycle");

                    b.Navigation("Filiere");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Niveau", b =>
                {
                    b.HasOne("Gesc.Api.Modeles.Config.FiliereCycle", "FiliereCycle")
                        .WithMany("Niveaux")
                        .HasForeignKey("FiliereCycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FiliereCycle");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Cycle", b =>
                {
                    b.Navigation("FiliereCycles");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Departement", b =>
                {
                    b.Navigation("Filieres");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Ecole", b =>
                {
                    b.Navigation("Departements");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.Filiere", b =>
                {
                    b.Navigation("FiliereCycles");
                });

            modelBuilder.Entity("Gesc.Api.Modeles.Config.FiliereCycle", b =>
                {
                    b.Navigation("Niveaux");
                });
#pragma warning restore 612, 618
        }
    }
}
