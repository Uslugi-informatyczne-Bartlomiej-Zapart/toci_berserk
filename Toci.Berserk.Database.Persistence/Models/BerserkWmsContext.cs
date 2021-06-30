using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class BerserkWmsContext : DbContext
    {
        public BerserkWmsContext()
        {
        }

        public BerserkWmsContext(DbContextOptions<BerserkWmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chemistry> Chemistries { get; set; }
        public virtual DbSet<Orderproduct> Orderproducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Berserk.Wms;Username=postgres;Password=beatka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idparent).HasColumnName("idparent");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("categories_idparent_fkey");
            });

            modelBuilder.Entity<Chemistry>(entity =>
            {
                entity.ToTable("chemistry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Chemistries)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("chemistry_idcategories_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Chemistries)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("chemistry_idproducts_fkey");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.ToTable("orderproducts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("orderproducts_idcategories_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("orderproducts_idproducts_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Reference).HasColumnName("reference");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
