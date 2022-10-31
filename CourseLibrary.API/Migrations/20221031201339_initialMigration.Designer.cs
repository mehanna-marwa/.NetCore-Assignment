﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.API.DbContexts;

namespace Products.API.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20221031201339_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Products.API.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "category 2"
                        });
                });

            modelBuilder.Entity("Products.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CateogryID")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CateogryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CateogryID = 1,
                            ImgURL = "",
                            Name = "product 1",
                            Price = 10.5,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 2,
                            CateogryID = 1,
                            ImgURL = "",
                            Name = "product 2",
                            Price = 15.0,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 3,
                            CateogryID = 2,
                            ImgURL = "",
                            Name = "product 3",
                            Price = 150.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            CateogryID = 1,
                            ImgURL = "",
                            Name = "product 4",
                            Price = 300.39999999999998,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 5,
                            CateogryID = 2,
                            ImgURL = "",
                            Name = "product 5",
                            Price = 1000.0,
                            Quantity = 300
                        });
                });

            modelBuilder.Entity("Products.API.Entities.Product", b =>
                {
                    b.HasOne("Products.API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CateogryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}