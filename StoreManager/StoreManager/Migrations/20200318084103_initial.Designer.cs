﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManager.Models;

namespace StoreManager.Migrations
{
    [DbContext(typeof(StoreManagerDbContext))]
    [Migration("20200318084103_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreManager.Models.Cart", b =>
                {
                    b.Property<int>("cartID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("totalPrice");

                    b.Property<int>("userID");

                    b.HasKey("cartID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("StoreManager.Models.Products", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("cartID");

                    b.Property<string>("productDescription")
                        .IsRequired();

                    b.Property<string>("productImage1");

                    b.Property<string>("productImage2");

                    b.Property<string>("productName")
                        .IsRequired();

                    b.Property<decimal>("productPrice");

                    b.Property<int>("productQuantity");

                    b.HasKey("productID");

                    b.HasIndex("cartID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreManager.Models.Users", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserKind");

                    b.Property<string>("eMail")
                        .IsRequired();

                    b.Property<string>("userAddress");

                    b.Property<string>("userImage");

                    b.Property<string>("userName")
                        .IsRequired();

                    b.Property<string>("userPassword")
                        .IsRequired();

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StoreManager.Models.Products", b =>
                {
                    b.HasOne("StoreManager.Models.Cart")
                        .WithMany("Products")
                        .HasForeignKey("cartID");
                });
#pragma warning restore 612, 618
        }
    }
}