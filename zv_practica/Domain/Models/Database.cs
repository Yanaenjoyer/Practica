﻿// Licence file C:\Users\Максим\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.
// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Models
{

    #region POCO classes

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Адрес
    public class Адрес
    {
        public string City { get; set; } // City (length: 50)
        public string Country { get; set; } // Country (length: 50)
        public string Street { get; set; } // Street (length: 50)
        public string House { get; set; } // House (length: 50)
        public string Appartments { get; set; } // Appartments (length: 50)
        public string Login { get; set; } // Login (Primary key) (length: 50)
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) Адрес pointed by [Пользователи].[Login] (FK_Пользователи_Адрес)
        /// </summary>
        public Пользователи Пользователи { get; set; } // Пользователи.FK_Пользователи_Адрес
    }

    // Заказ
    public class Заказ
    {
        public int OrderNumber { get; set; } // Order_number (Primary key)
        public DateTime? OrderDate { get; set; } // Order_date
        public string Login { get; set; } // Login (length: 50)
        public double? Price { get; set; } // Price
        public bool IsDeleted { get; set; } // IsDeleted
        public string DeliveryType { get; set; } // Delivery_Type (length: 50)
        public string Status { get; set; } // Status (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child ЗаказТовара where [Заказ_товара].[Order_number] point to this entity (FK_Заказ_товара_Заказ)
        /// </summary>
        public ICollection<ЗаказТовара> ЗаказТовара { get; set; } // Заказ_товара.FK_Заказ_товара_Заказ

        // Foreign keys

        /// <summary>
        /// Parent Пользователи pointed by [Заказ].([Login]) (FK_Заказ_Пользователи)
        /// </summary>
        public Пользователи Пользователи { get; set; } // FK_Заказ_Пользователи

        public Заказ()
        {
            ЗаказТовара = new List<ЗаказТовара>();
        }
    }

    // Заказ_товара
    public class ЗаказТовара
    {
        public int OrderNumber { get; set; } // Order_number (Primary key)
        public int ProductId { get; set; } // Product_ID (Primary key)
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Заказ pointed by [Заказ_товара].([OrderNumber]) (FK_Заказ_товара_Заказ)
        /// </summary>
        public Заказ Заказ { get; set; } // FK_Заказ_товара_Заказ

        /// <summary>
        /// Parent Товар pointed by [Заказ_товара].([ProductId]) (FK_Заказ_товара_Товар)
        /// </summary>
        public Товар Товар { get; set; } // FK_Заказ_товара_Товар
    }

    // Категории
    public class Категории
    {
        public string CategoryName { get; set; } // Category_name (length: 50)
        public string Comments { get; set; } // Comments (length: 50)
        public int CategoryId { get; set; } // Category_ID (Primary key)
        public bool? IsDeleted { get; set; } // Is_Deleted

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) Категории pointed by [Товар].[Product_ID] (FK_Товар_Категории)
        /// </summary>
        public Товар Товар { get; set; } // Товар.FK_Товар_Категории
    }

    // Оценка_товара
    public class Оценкатовара
    {
        public int ProductId { get; set; } // Product_ID (Primary key)
        public string Login { get; set; } // Login (Primary key) (length: 50)
        public int? Grade { get; set; } // Grade
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Пользователи pointed by [Оценка_товара].([Login]) (FK_Оценка_товара_Пользователи)
        /// </summary>
        public Пользователи Пользователи { get; set; } // FK_Оценка_товара_Пользователи

        /// <summary>
        /// Parent Товар pointed by [Оценка_товара].([ProductId]) (FK_Оценка_товара_Товар)
        /// </summary>
        public Товар Товар { get; set; } // FK_Оценка_товара_Товар
    }

    // Пользователи
    public class Пользователи
    {
        public string Login { get; set; } // Login (Primary key) (length: 50)
        public string Password { get; set; } // Password (length: 50)
        public string Surname { get; set; } // Surname (length: 50)
        public string Name { get; set; } // Name (length: 50)
        public string Lastname { get; set; } // Lastname (length: 50)
        public DateTime Birthday { get; set; } // Birthday
        public bool IsDeleted { get; set; } // IsDeleted
        public bool IsAdmin { get; set; } // IsAdmin

        // Reverse navigation

        /// <summary>
        /// Child Заказ where [Заказ].[Login] point to this entity (FK_Заказ_Пользователи)
        /// </summary>
        public ICollection<Заказ> Заказ { get; set; } // Заказ.FK_Заказ_Пользователи

        /// <summary>
        /// Child Оценкатовара where [Оценка_товара].[Login] point to this entity (FK_Оценка_товара_Пользователи)
        /// </summary>
        public ICollection<Оценкатовара> Оценкатовара { get; set; } // Оценка_товара.FK_Оценка_товара_Пользователи

        // Foreign keys

        /// <summary>
        /// Parent Адрес pointed by [Пользователи].([Login]) (FK_Пользователи_Адрес)
        /// </summary>
        public Адрес Адрес { get; set; } // FK_Пользователи_Адрес

        public Пользователи()
        {
            Заказ = new List<Заказ>();
            Оценкатовара = new List<Оценкатовара>();
        }
    }

    // Товар
    public class Товар
    {
        public int ProductId { get; set; } // Product_ID (Primary key)
        public double? ProductPrice { get; set; } // Product_Price
        public double? ProductWeight { get; set; } // Product_weight
        public double? ProductLenght { get; set; } // Product_Lenght
        public double? ProductWidth { get; set; } // Product_width
        public string Comment { get; set; } // Comment (length: 100)
        public bool IsDeleted { get; set; } // IsDeleted
        public int? SumProduct { get; set; } // Sum_product

        // Reverse navigation

        /// <summary>
        /// Child ЗаказТовара where [Заказ_товара].[Product_ID] point to this entity (FK_Заказ_товара_Товар)
        /// </summary>
        public ICollection<ЗаказТовара> ЗаказТовара { get; set; } // Заказ_товара.FK_Заказ_товара_Товар

        /// <summary>
        /// Child Оценкатовара where [Оценка_товара].[Product_ID] point to this entity (FK_Оценка_товара_Товар)
        /// </summary>
        public ICollection<Оценкатовара> Оценкатовара { get; set; } // Оценка_товара.FK_Оценка_товара_Товар

        // Foreign keys

        /// <summary>
        /// Parent Категории pointed by [Товар].([ProductId]) (FK_Товар_Категории)
        /// </summary>
        public Категории Категории { get; set; } // FK_Товар_Категории

        public Товар()
        {
            ЗаказТовара = new List<ЗаказТовара>();
            Оценкатовара = new List<Оценкатовара>();
        }
    }


    #endregion

    #region POCO Configuration

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Адрес
    public class АдресConfiguration : IEntityTypeConfiguration<Адрес>
    {
        public void Configure(EntityTypeBuilder<Адрес> builder)
        {
            builder.ToTable("Адрес", "dbo");
            builder.HasKey(x => x.Login).HasName("PK_Адрес").IsClustered();

            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Street).HasColumnName(@"Street").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.House).HasColumnName(@"House").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Appartments).HasColumnName(@"Appartments").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Login).HasColumnName(@"Login").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50).ValueGeneratedNever();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
        }
    }

    // Заказ
    public class ЗаказConfiguration : IEntityTypeConfiguration<Заказ>
    {
        public void Configure(EntityTypeBuilder<Заказ> builder)
        {
            builder.ToTable("Заказ", "dbo");
            builder.HasKey(x => x.OrderNumber).HasName("PK_Заказ").IsClustered();

            builder.Property(x => x.OrderNumber).HasColumnName(@"Order_number").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.OrderDate).HasColumnName(@"Order_date").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.Login).HasColumnName(@"Login").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.DeliveryType).HasColumnName(@"Delivery_Type").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.Пользователи).WithMany(b => b.Заказ).HasForeignKey(c => c.Login).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Заказ_Пользователи");
        }
    }

    // Заказ_товара
    public class ЗаказТовараConfiguration : IEntityTypeConfiguration<ЗаказТовара>
    {
        public void Configure(EntityTypeBuilder<ЗаказТовара> builder)
        {
            builder.ToTable("Заказ_товара", "dbo");
            builder.HasKey(x => new { x.OrderNumber, x.ProductId }).HasName("PK_Заказ_товара").IsClustered();

            builder.Property(x => x.OrderNumber).HasColumnName(@"Order_number").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ProductId).HasColumnName(@"Product_ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Заказ).WithMany(b => b.ЗаказТовара).HasForeignKey(c => c.OrderNumber).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Заказ_товара_Заказ");
            builder.HasOne(a => a.Товар).WithMany(b => b.ЗаказТовара).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Заказ_товара_Товар");
        }
    }

    // Категории
    public class КатегорииConfiguration : IEntityTypeConfiguration<Категории>
    {
        public void Configure(EntityTypeBuilder<Категории> builder)
        {
            builder.ToTable("Категории", "dbo");
            builder.HasKey(x => x.CategoryId).HasName("PK_Категории").IsClustered();

            builder.Property(x => x.CategoryName).HasColumnName(@"Category_name").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Comments).HasColumnName(@"Comments").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.CategoryId).HasColumnName(@"Category_ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IsDeleted).HasColumnName(@"Is_Deleted").HasColumnType("bit").IsRequired(false);
        }
    }

    // Оценка_товара
    public class ОценкатовараConfiguration : IEntityTypeConfiguration<Оценкатовара>
    {
        public void Configure(EntityTypeBuilder<Оценкатовара> builder)
        {
            builder.ToTable("Оценка_товара", "dbo");
            builder.HasKey(x => new { x.ProductId, x.Login }).HasName("PK_Оценка_товара").IsClustered();

            builder.Property(x => x.ProductId).HasColumnName(@"Product_ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Login).HasColumnName(@"Login").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50).ValueGeneratedNever();
            builder.Property(x => x.Grade).HasColumnName(@"Grade").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Пользователи).WithMany(b => b.Оценкатовара).HasForeignKey(c => c.Login).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Оценка_товара_Пользователи");
            builder.HasOne(a => a.Товар).WithMany(b => b.Оценкатовара).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Оценка_товара_Товар");
        }
    }

    // Пользователи
    public class ПользователиConfiguration : IEntityTypeConfiguration<Пользователи>
    {
        public void Configure(EntityTypeBuilder<Пользователи> builder)
        {
            builder.ToTable("Пользователи", "dbo");
            builder.HasKey(x => x.Login).HasName("PK_Пользователи").IsClustered();

            builder.Property(x => x.Login).HasColumnName(@"Login").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50).ValueGeneratedNever();
            builder.Property(x => x.Password).HasColumnName(@"Password").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).HasColumnName(@"Surname").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lastname).HasColumnName(@"Lastname").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Birthday).HasColumnName(@"Birthday").HasColumnType("date").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsAdmin).HasColumnName(@"IsAdmin").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Адрес).WithOne(b => b.Пользователи).HasForeignKey<Пользователи>(c => c.Login).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Пользователи_Адрес");
        }
    }

    // Товар
    public class ТоварConfiguration : IEntityTypeConfiguration<Товар>
    {
        public void Configure(EntityTypeBuilder<Товар> builder)
        {
            builder.ToTable("Товар", "dbo");
            builder.HasKey(x => x.ProductId).HasName("PK_Товар").IsClustered();

            builder.Property(x => x.ProductId).HasColumnName(@"Product_ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ProductPrice).HasColumnName(@"Product_Price").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.ProductWeight).HasColumnName(@"Product_weight").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.ProductLenght).HasColumnName(@"Product_Lenght").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.ProductWidth).HasColumnName(@"Product_width").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.Comment).HasColumnName(@"Comment").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SumProduct).HasColumnName(@"Sum_product").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Категории).WithOne(b => b.Товар).HasForeignKey<Товар>(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Товар_Категории");
        }
    }


    #endregion

}
// </auto-generated>
