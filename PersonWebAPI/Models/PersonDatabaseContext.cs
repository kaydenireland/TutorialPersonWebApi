using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonWebAPI.Models;

public partial class PersonDatabaseContext : DbContext
{
    public PersonDatabaseContext()
    {
    }

    public PersonDatabaseContext(DbContextOptions<PersonDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
