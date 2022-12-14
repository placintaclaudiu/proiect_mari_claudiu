// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiect_mari_claudiu.Data;

#nullable disable

namespace proiect_mari_claudiu.Migrations
{
    [DbContext(typeof(proiect_mari_claudiuContext))]
    partial class proiect_mari_claudiuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proiect_mari_claudiu.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Furnizor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeFurnizor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Furnizor");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Inchiriere", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPreluare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReturnare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MasinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("MasinaID");

                    b.ToTable("Inchiriere");
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

                    b.Property<int?>("ModelID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ID");

                    b.HasIndex("FurnizorID");

                    b.HasIndex("ModelID");

                    b.ToTable("Masina");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeTip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.TipMasina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MasinaID")
                        .HasColumnType("int");

                    b.Property<int>("TipID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MasinaID");

                    b.HasIndex("TipID");

                    b.ToTable("TipMasina");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Inchiriere", b =>
                {
                    b.HasOne("proiect_mari_claudiu.Models.Client", "Client")
                        .WithMany("Inchirieri")
                        .HasForeignKey("ClientID");

                    b.HasOne("proiect_mari_claudiu.Models.Masina", "Masina")
                        .WithMany()
                        .HasForeignKey("MasinaID");

                    b.Navigation("Client");

                    b.Navigation("Masina");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Masina", b =>
                {
                    b.HasOne("proiect_mari_claudiu.Models.Furnizor", "Furnizor")
                        .WithMany("Masini")
                        .HasForeignKey("FurnizorID");

                    b.HasOne("proiect_mari_claudiu.Models.Model", "Model")
                        .WithMany("Masini")
                        .HasForeignKey("ModelID");

                    b.Navigation("Furnizor");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.TipMasina", b =>
                {
                    b.HasOne("proiect_mari_claudiu.Models.Masina", "Masina")
                        .WithMany("TipMasini")
                        .HasForeignKey("MasinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiect_mari_claudiu.Models.Tip", "Tip")
                        .WithMany("TipMasini")
                        .HasForeignKey("TipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masina");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Client", b =>
                {
                    b.Navigation("Inchirieri");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Furnizor", b =>
                {
                    b.Navigation("Masini");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Masina", b =>
                {
                    b.Navigation("TipMasini");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Model", b =>
                {
                    b.Navigation("Masini");
                });

            modelBuilder.Entity("proiect_mari_claudiu.Models.Tip", b =>
                {
                    b.Navigation("TipMasini");
                });
#pragma warning restore 612, 618
        }
    }
}
