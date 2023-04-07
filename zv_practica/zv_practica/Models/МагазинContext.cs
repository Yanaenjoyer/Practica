using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace zv_practica.Models;

public partial class МагазинContext : DbContext
{
    public МагазинContext()
    {
    }

    public МагазинContext(DbContextOptions<МагазинContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Адрес> Адресs { get; set; }

    public virtual DbSet<Заказ> Заказs { get; set; }

    public virtual DbSet<ЗаказТовара> ЗаказТовараs { get; set; }

    public virtual DbSet<Категории> Категорииs { get; set; }

    public virtual DbSet<ОценкаТовара> ОценкаТовараs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Товар> Товарs { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Адрес>(entity =>
        {
            entity.HasKey(e => e.Login);

            entity.ToTable("Адрес");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Appartments).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.House).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<Заказ>(entity =>
        {
            entity.HasKey(e => e.OrderNumber);

            entity.ToTable("Заказ");

            entity.Property(e => e.OrderNumber)
                .ValueGeneratedNever()
                .HasColumnName("Order_number");
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(50)
                .HasColumnName("Delivery_Type");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("Order_date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.Login)
                .HasConstraintName("FK_Заказ_Пользователи");
        });

        modelBuilder.Entity<ЗаказТовара>(entity =>
        {
            entity.HasKey(e => new { e.OrderNumber, e.ProductId });

            entity.ToTable("Заказ_товара");

            entity.Property(e => e.OrderNumber).HasColumnName("Order_number");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.OrderNumberNavigation).WithMany(p => p.ЗаказТовараs)
                .HasForeignKey(d => d.OrderNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказ_товара_Заказ");

            entity.HasOne(d => d.Product).WithMany(p => p.ЗаказТовараs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказ_товара_Товар");
        });

        modelBuilder.Entity<Категории>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("Категории");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("Category_name");
            entity.Property(e => e.Comments).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");
        });

        modelBuilder.Entity<ОценкаТовара>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.Login });

            entity.ToTable("Оценка_товара");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.Login).HasMaxLength(50);

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.ОценкаТовараs)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Оценка_товара_Пользователи");

            entity.HasOne(d => d.Product).WithMany(p => p.ОценкаТовараs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Оценка_товара_Товар");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.Login);

            entity.ToTable("Пользователи");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.LoginNavigation).WithOne(p => p.Пользователи)
                .HasForeignKey<Пользователи>(d => d.Login)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пользователи_Адрес");
        });

        modelBuilder.Entity<Товар>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Товар");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_ID");
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.ProductLenght).HasColumnName("Product_Lenght");
            entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");
            entity.Property(e => e.ProductWeight).HasColumnName("Product_weight");
            entity.Property(e => e.ProductWidth).HasColumnName("Product_width");
            entity.Property(e => e.SumProduct).HasColumnName("Sum_product");

            entity.HasOne(d => d.Product).WithOne(p => p.Товар)
                .HasForeignKey<Товар>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Товар_Категории");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
