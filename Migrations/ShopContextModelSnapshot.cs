﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekat.Models;

namespace projekat.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Projekat.Models.Kais", b =>
                {
                    b.Property<int>("KaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KaisID")
                        .UseIdentityColumn();

                    b.Property<double>("Cena")
                        .HasColumnType("float")
                        .HasColumnName("Cena");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Image");

                    b.Property<int>("NaStanju")
                        .HasColumnType("int")
                        .HasColumnName("Na stanju");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Opis");

                    b.HasKey("KaisId");

                    b.ToTable("Kais");
                });

            modelBuilder.Entity("Projekat.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID")
                        .UseIdentityColumn();

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int>("Broj")
                        .HasColumnType("int")
                        .HasColumnName("BrojKupljenihProizvoda");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Prezime");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sifra");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Projekat.Models.Narukvica", b =>
                {
                    b.Property<int>("NarukvicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarukvicaID")
                        .UseIdentityColumn();

                    b.Property<double>("Cena")
                        .HasColumnType("float")
                        .HasColumnName("Cena");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Image");

                    b.Property<int>("NaStanju")
                        .HasColumnType("int")
                        .HasColumnName("Na stanju");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Opis");

                    b.HasKey("NarukvicaId");

                    b.ToTable("Narukvica");
                });

            modelBuilder.Entity("Projekat.Models.Sat", b =>
                {
                    b.Property<int>("SatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SatID")
                        .UseIdentityColumn();

                    b.Property<double>("Cena")
                        .HasColumnType("float")
                        .HasColumnName("Cena");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Image");

                    b.Property<int>("NaStanju")
                        .HasColumnType("int")
                        .HasColumnName("Na stanju");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Opis");

                    b.HasKey("SatId");

                    b.ToTable("Sat");
                });
#pragma warning restore 612, 618
        }
    }
}
