﻿// <auto-generated />
using System;
using DigitalOnlineShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MvcPhone.Migrations
{
    [DbContext(typeof(DigitalOnlineShopContext))]
    [Migration("20240505093306_Img")]
    partial class Img
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MvcMovie.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("parent_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("MvcMovie.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("MvcMovie.Models.FieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("ProductId");

                    b.ToTable("FieldValue");
                });

            modelBuilder.Entity("MvcMovie.Models.Product", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Vivobook r655",
                            Price = 3000.02m
                        });
                });

            modelBuilder.Entity("MvcMovie.Models.Field", b =>
                {
                    b.HasOne("MvcMovie.Models.Category", "Category")
                        .WithMany("Fields")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MvcMovie.Models.FieldValue", b =>
                {
                    b.HasOne("MvcMovie.Models.Field", "Field")
                        .WithMany("FieldValues")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcMovie.Models.Product", "Product")
                        .WithMany("FieldValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MvcMovie.Models.Product", b =>
                {
                    b.HasOne("MvcMovie.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MvcMovie.Models.Category", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("MvcMovie.Models.Field", b =>
                {
                    b.Navigation("FieldValues");
                });

            modelBuilder.Entity("MvcMovie.Models.Product", b =>
                {
                    b.Navigation("FieldValues");
                });
#pragma warning restore 612, 618
        }
    }
}
