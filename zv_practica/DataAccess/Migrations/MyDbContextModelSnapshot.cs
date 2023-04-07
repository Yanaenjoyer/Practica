﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Адрес", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.Property<string>("Appartments")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Appartments");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Country");

                    b.Property<string>("House")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("House");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Street");

                    b.HasKey("Login")
                        .HasName("PK_Адрес");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Login"));

                    b.ToTable("Адрес", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Заказ", b =>
                {
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int")
                        .HasColumnName("Order_number");

                    b.Property<string>("DeliveryType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Delivery_Type");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("Order_date");

                    b.Property<double?>("Price")
                        .HasPrecision(53)
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Status");

                    b.HasKey("OrderNumber")
                        .HasName("PK_Заказ");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("OrderNumber"));

                    b.HasIndex("Login");

                    b.ToTable("Заказ", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Заказтовара", b =>
                {
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int")
                        .HasColumnName("Order_number");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.HasKey("OrderNumber", "ProductId")
                        .HasName("PK_Заказ_товара");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("OrderNumber", "ProductId"));

                    b.HasIndex("ProductId");

                    b.ToTable("Заказ_товара", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Категории", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_ID");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category_name");

                    b.Property<string>("Comments")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Comments");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Deleted");

                    b.HasKey("CategoryId")
                        .HasName("PK_Категории");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("CategoryId"));

                    b.ToTable("Категории", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Оценкатовара", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.Property<int?>("Grade")
                        .HasColumnType("int")
                        .HasColumnName("Grade");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.HasKey("ProductId", "Login")
                        .HasName("PK_Оценка_товара");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ProductId", "Login"));

                    b.HasIndex("Login");

                    b.ToTable("Оценка_товара", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Пользователи", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("Birthday");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Surname");

                    b.HasKey("Login")
                        .HasName("PK_Пользователи");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Login"));

                    b.ToTable("Пользователи", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Товар", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    b.Property<string>("Comment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Comment");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<double?>("ProductLenght")
                        .HasPrecision(53)
                        .HasColumnType("float")
                        .HasColumnName("Product_Lenght");

                    b.Property<double?>("ProductPrice")
                        .HasPrecision(53)
                        .HasColumnType("float")
                        .HasColumnName("Product_Price");

                    b.Property<double?>("ProductWeight")
                        .HasPrecision(53)
                        .HasColumnType("float")
                        .HasColumnName("Product_weight");

                    b.Property<double?>("ProductWidth")
                        .HasPrecision(53)
                        .HasColumnType("float")
                        .HasColumnName("Product_width");

                    b.Property<int?>("SumProduct")
                        .HasColumnType("int")
                        .HasColumnName("Sum_product");

                    b.HasKey("ProductId")
                        .HasName("PK_Товар");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ProductId"));

                    b.ToTable("Товар", "dbo");
                });

            modelBuilder.Entity("Domain.Models.Заказ", b =>
                {
                    b.HasOne("Domain.Models.Пользователи", "Пользователи")
                        .WithMany("Заказ")
                        .HasForeignKey("Login")
                        .HasConstraintName("FK_Заказ_Пользователи");

                    b.Navigation("Пользователи");
                });

            modelBuilder.Entity("Domain.Models.Заказтовара", b =>
                {
                    b.HasOne("Domain.Models.Заказ", "Заказ")
                        .WithMany("Заказтовара")
                        .HasForeignKey("OrderNumber")
                        .IsRequired()
                        .HasConstraintName("FK_Заказ_товара_Заказ");

                    b.HasOne("Domain.Models.Товар", "Товар")
                        .WithMany("Заказтовара")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Заказ_товара_Товар");

                    b.Navigation("Заказ");

                    b.Navigation("Товар");
                });

            modelBuilder.Entity("Domain.Models.Оценкатовара", b =>
                {
                    b.HasOne("Domain.Models.Пользователи", "Пользователи")
                        .WithMany("Оценкатовара")
                        .HasForeignKey("Login")
                        .IsRequired()
                        .HasConstraintName("FK_Оценка_товара_Пользователи");

                    b.HasOne("Domain.Models.Товар", "Товар")
                        .WithMany("Оценкатовара")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Оценка_товара_Товар");

                    b.Navigation("Пользователи");

                    b.Navigation("Товар");
                });

            modelBuilder.Entity("Domain.Models.Пользователи", b =>
                {
                    b.HasOne("Domain.Models.Адрес", "Адрес")
                        .WithOne("Пользователи")
                        .HasForeignKey("Domain.Models.Пользователи", "Login")
                        .IsRequired()
                        .HasConstraintName("FK_Пользователи_Адрес");

                    b.Navigation("Адрес");
                });

            modelBuilder.Entity("Domain.Models.Товар", b =>
                {
                    b.HasOne("Domain.Models.Категории", "Категории")
                        .WithOne("Товар")
                        .HasForeignKey("Domain.Models.Товар", "ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Товар_Категории");

                    b.Navigation("Категории");
                });

            modelBuilder.Entity("Domain.Models.Адрес", b =>
                {
                    b.Navigation("Пользователи");
                });

            modelBuilder.Entity("Domain.Models.Заказ", b =>
                {
                    b.Navigation("Заказтовара");
                });

            modelBuilder.Entity("Domain.Models.Категории", b =>
                {
                    b.Navigation("Товар");
                });

            modelBuilder.Entity("Domain.Models.Пользователи", b =>
                {
                    b.Navigation("Заказ");

                    b.Navigation("Оценкатовара");
                });

            modelBuilder.Entity("Domain.Models.Товар", b =>
                {
                    b.Navigation("Заказтовара");

                    b.Navigation("Оценкатовара");
                });
#pragma warning restore 612, 618
        }
    }
}
