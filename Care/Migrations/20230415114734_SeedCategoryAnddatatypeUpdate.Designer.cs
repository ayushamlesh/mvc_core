﻿// <auto-generated />
using System;
using Care.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Care.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230415114734_SeedCategoryAnddatatypeUpdate")]
    partial class SeedCategoryAnddatatypeUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Care.Models.Category", b =>
                {
                    b.Property<string>("CatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CatId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CatId = "11",
                            CatName = "k",
                            Price = 100,
                            Quantity = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
