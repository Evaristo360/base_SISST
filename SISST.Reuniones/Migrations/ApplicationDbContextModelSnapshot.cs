﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SISST.Reuniones.Data;

namespace SISST.Reuniones.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Reunion")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SISST.Reuniones.Models.Documento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("ReunionId")
                        .HasMaxLength(10)
                        .HasColumnType("INT");

                    b.Property<string>("Ruta")
                        .HasColumnType("TEXT");

                    b.HasKey("DocumentoId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("ReunionId");

                    b.ToTable("TDocumentos");
                });

            modelBuilder.Entity("SISST.Reuniones.Models.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdReunion")
                        .HasMaxLength(10)
                        .HasColumnType("INT");

                    b.Property<int>("IdTrabajador")
                        .HasMaxLength(10)
                        .HasColumnType("INT");

                    b.Property<int?>("ReunionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ReunionId");

                    b.ToTable("TParticipantes");
                });

            modelBuilder.Entity("SISST.Reuniones.Models.Reunion", b =>
                {
                    b.Property<int>("ReunionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Apoyo")
                        .HasMaxLength(10)
                        .HasColumnType("INT");

                    b.Property<string>("Conclusiones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Desarrollo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Introduccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NoParticipantes")
                        .HasMaxLength(10)
                        .HasColumnType("INT");

                    b.Property<string>("Retroalimentacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("ReunionId");

                    b.HasIndex("ReunionId");

                    b.ToTable("TReuniones");
                });

            modelBuilder.Entity("SISST.Reuniones.Models.Documento", b =>
                {
                    b.HasOne("SISST.Reuniones.Models.Reunion", null)
                        .WithMany("Documento")
                        .HasForeignKey("ReunionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SISST.Reuniones.Models.Participante", b =>
                {
                    b.HasOne("SISST.Reuniones.Models.Reunion", null)
                        .WithMany("Participantes")
                        .HasForeignKey("ReunionId");
                });

            modelBuilder.Entity("SISST.Reuniones.Models.Reunion", b =>
                {
                    b.Navigation("Documento");

                    b.Navigation("Participantes");
                });
#pragma warning restore 612, 618
        }
    }
}