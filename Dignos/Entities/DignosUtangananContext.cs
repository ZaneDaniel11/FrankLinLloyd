﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dignos.Entities;

public partial class DignosUtangananContext : DbContext
{
    public DignosUtangananContext()
    {
    }

    public DignosUtangananContext(DbContextOptions<DignosUtangananContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DignosUtanganan;TrustServerCertificate=true;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.ToTable("ClientInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Civil_Status");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOfFather)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOfMother)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
