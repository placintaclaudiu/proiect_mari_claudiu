﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiect_mari_claudiu.Data;

#nullable disable

namespace proiect_mari_claudiu.Migrations
{
    [DbContext(typeof(proiect_mari_claudiuContext))]
    [Migration("20221123181540_FurnizorName")]
    partial class FurnizorName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proiect_mari_claudiu.Models.Furnizor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Furnizor");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Masina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("An_Fabricatie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FurnizorID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ID");

                    b.HasIndex("FurnizorID");

                    b.ToTable("Masina");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Masina", b =>
                {
                    b.HasOne("proiect_mari_claudiu.Models.Furnizor", "Furnizor")
                        .WithMany("Masini")
                        .HasForeignKey("FurnizorID");

                    b.Navigation("Furnizor");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Furnizor", b =>
                {
                    b.Navigation("Masini");
                });
#pragma warning restore 612, 618
        }
    }
}
