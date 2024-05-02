using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TacoFastFoodAPI.Models;

public partial class AhbcTeachingContext : DbContext
{
    public AhbcTeachingContext()
    {
    }

    public AhbcTeachingContext(DbContextOptions<AhbcTeachingContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Drink> Drinks { get; set; }


    public virtual DbSet<Taco> Tacos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Name=DefaultConnection");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drink__3214EC271F42DCDE");

            entity.ToTable("Drink");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });


        modelBuilder.Entity<Taco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Taco__3214EC2775740D3E");

            entity.ToTable("Taco");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
