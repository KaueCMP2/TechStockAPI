using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechStockAPI.Domains;

namespace TechStockAPI.Context;

public partial class TechStockDbContext : DbContext
{
    public TechStockDbContext()
    {
    }

    public TechStockDbContext(DbContextOptions<TechStockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Produtos> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TechStockDb;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produtos>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProdutoId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
