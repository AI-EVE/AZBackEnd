﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241112225231_AddProductsBoughtProductOrdersTables")]
    partial class AddProductsBoughtProductOrdersTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarGenerationId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarGenerationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("Plate")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("API.Models.CarGeneration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("Name", "CarModelId")
                        .IsUnique();

                    b.ToTable("CarGenerations");
                });

            modelBuilder.Entity("API.Models.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("API.Models.CarMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarMakers");
                });

            modelBuilder.Entity("API.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarMakerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarMakerId");

                    b.HasIndex("Name", "CarMakerId")
                        .IsUnique();

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("API.Models.CarSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarSections");
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Models.ClientImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientImages");
                });

            modelBuilder.Entity("API.Models.ClientPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("ClientPhones");
                });

            modelBuilder.Entity("API.Models.ClientSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("SocialTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("SocialUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SocialTypeId");

                    b.ToTable("ClientSocials");
                });

            modelBuilder.Entity("API.Models.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FlagUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarSectionId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryOfOriginId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<int>("ProductMakerId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarSectionId");

                    b.HasIndex("CountryOfOriginId");

                    b.HasIndex("ProductMakerId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Models.ProductBought", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BoughtAt")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitDiscount")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(16, 4)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductsBought");
                });

            modelBuilder.Entity("API.Models.ProductCarGeneration", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CarGenerationId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CarGenerationId");

                    b.HasIndex("CarGenerationId");

                    b.HasIndex("ProductId", "CarGenerationId")
                        .IsUnique();

                    b.ToTable("ProductCarGenerations");
                });

            modelBuilder.Entity("API.Models.ProductImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("API.Models.ProductMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductMakers");
                });

            modelBuilder.Entity("API.Models.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateOnly>("OrderedAt")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitDiscount")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(16, 4)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("API.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("API.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("API.Models.ShopBillImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("TakenAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopBillImages");
                });

            modelBuilder.Entity("API.Models.ShopImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopImages");
                });

            modelBuilder.Entity("API.Models.ShopPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("ShopId");

                    b.ToTable("ShopPhones");
                });

            modelBuilder.Entity("API.Models.ShopSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<int>("SocialTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("SocialUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("SocialTypeId");

                    b.ToTable("ShopSocials");
                });

            modelBuilder.Entity("API.Models.SocialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("SocialTypes");
                });

            modelBuilder.Entity("API.Models.Car", b =>
                {
                    b.HasOne("API.Models.CarGeneration", "CarGeneration")
                        .WithMany("Cars")
                        .HasForeignKey("CarGenerationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CarGeneration");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("API.Models.CarGeneration", b =>
                {
                    b.HasOne("API.Models.CarModel", "CarModel")
                        .WithMany("CarGenerations")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("API.Models.CarImage", b =>
                {
                    b.HasOne("API.Models.Car", "Car")
                        .WithMany("CarImages")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("API.Models.CarModel", b =>
                {
                    b.HasOne("API.Models.CarMaker", "CarMaker")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMaker");
                });

            modelBuilder.Entity("API.Models.ClientImage", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("ClientImages")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("API.Models.ClientPhone", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("ClientPhones")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("API.Models.ClientSocial", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("ClientSocials")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.SocialType", "SocialType")
                        .WithMany("ClientSocials")
                        .HasForeignKey("SocialTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("SocialType");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.HasOne("API.Models.CarSection", "CarSection")
                        .WithMany("Products")
                        .HasForeignKey("CarSectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Countries", "CountryOfOrigin")
                        .WithMany("Products")
                        .HasForeignKey("CountryOfOriginId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.ProductMaker", "ProductMaker")
                        .WithMany("Products")
                        .HasForeignKey("ProductMakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CarSection");

                    b.Navigation("CountryOfOrigin");

                    b.Navigation("ProductMaker");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("API.Models.ProductBought", b =>
                {
                    b.HasOne("API.Models.Product", "Product")
                        .WithMany("ProductsBought")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Shop", "Shop")
                        .WithMany("ProductsBought")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("API.Models.ProductCarGeneration", b =>
                {
                    b.HasOne("API.Models.CarGeneration", "CarGeneration")
                        .WithMany("ProductCarGenerations")
                        .HasForeignKey("CarGenerationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Product", "Product")
                        .WithMany("ProductCarGenerations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarGeneration");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Models.ProductImages", b =>
                {
                    b.HasOne("API.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Models.ProductOrder", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Models.ShopBillImage", b =>
                {
                    b.HasOne("API.Models.Shop", "Shop")
                        .WithMany("ShopProducts")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("API.Models.ShopImage", b =>
                {
                    b.HasOne("API.Models.Shop", "Shop")
                        .WithMany("ShopImages")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("API.Models.ShopPhone", b =>
                {
                    b.HasOne("API.Models.Shop", "Shop")
                        .WithMany("ShopPhones")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("API.Models.ShopSocial", b =>
                {
                    b.HasOne("API.Models.Shop", "Shop")
                        .WithMany("ShopSocials")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.SocialType", "SocialType")
                        .WithMany("ShopSocials")
                        .HasForeignKey("SocialTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shop");

                    b.Navigation("SocialType");
                });

            modelBuilder.Entity("API.Models.Car", b =>
                {
                    b.Navigation("CarImages");
                });

            modelBuilder.Entity("API.Models.CarGeneration", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ProductCarGenerations");
                });

            modelBuilder.Entity("API.Models.CarMaker", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("API.Models.CarModel", b =>
                {
                    b.Navigation("CarGenerations");
                });

            modelBuilder.Entity("API.Models.CarSection", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ClientImages");

                    b.Navigation("ClientPhones");

                    b.Navigation("ClientSocials");

                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("API.Models.Countries", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Navigation("ProductCarGenerations");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductOrders");

                    b.Navigation("ProductsBought");
                });

            modelBuilder.Entity("API.Models.ProductMaker", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.Shop", b =>
                {
                    b.Navigation("ProductsBought");

                    b.Navigation("ShopImages");

                    b.Navigation("ShopPhones");

                    b.Navigation("ShopProducts");

                    b.Navigation("ShopSocials");
                });

            modelBuilder.Entity("API.Models.SocialType", b =>
                {
                    b.Navigation("ClientSocials");

                    b.Navigation("ShopSocials");
                });
#pragma warning restore 612, 618
        }
    }
}
