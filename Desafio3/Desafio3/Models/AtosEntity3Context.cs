using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Desafio3.Models;

public partial class AtosEntity3Context : DbContext
{
    public AtosEntity3Context()
    {
    }

    public AtosEntity3Context(DbContextOptions<AtosEntity3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesProduto> ClientesProdutos { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        
        optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=AtosEntity3;User ID=AtosEntity3;password=Atos_Entity_3;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F49DB0D77");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<ClientesProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83FB7A757A0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdProduto).HasColumnName("idProduto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClientesProdutos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientesP__idCli__3F466844");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ClientesProdutos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientesP__idPro__403A8C7D");
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forneced__3213E83FF5DDF2D1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3213E83F7F3AA663");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produtos__idForn__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
