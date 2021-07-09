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
        public virtual DbSet<Chemistrypop> Chemistrypops { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Deliverycompany> Deliverycompanies { get; set; }
        public virtual DbSet<Metric> Metrics { get; set; }
        public virtual DbSet<Metrichistory> Metrichistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderproduct> Orderproducts { get; set; }
        public virtual DbSet<Predictedorder> Predictedorders { get; set; }
        public virtual DbSet<Predictedorderquantity> Predictedorderquantities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productscode> Productscodes { get; set; }
        public virtual DbSet<Productshistory> Productshistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_Poland.1250");

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

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Chemistries)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("chemistry_idproducts_fkey");
            });

            modelBuilder.Entity<Chemistrypop>(entity =>
            {
                entity.ToTable("chemistrypop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Chemistrypops)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("chemistrypop_idproducts_fkey");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Chemistrypops)
                    .HasForeignKey(d => d.Idusers)
                    .HasConstraintName("chemistrypop_idusers_fkey");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("delivery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iddeliverycompany).HasColumnName("iddeliverycompany");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IddeliverycompanyNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.Iddeliverycompany)
                    .HasConstraintName("delivery_iddeliverycompany_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("delivery_idproducts_fkey");
            });

            modelBuilder.Entity<Deliverycompany>(entity =>
            {
                entity.ToTable("deliverycompanies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Metric>(entity =>
            {
                entity.ToTable("metrics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Algorithm).HasColumnName("algorithm");

                entity.Property(e => e.Metric1).HasColumnName("metric");
            });

            modelBuilder.Entity<Metrichistory>(entity =>
            {
                entity.ToTable("metrichistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idmetrics).HasColumnName("idmetrics");

                entity.Property(e => e.Metric).HasColumnName("metric");

                entity.HasOne(d => d.IdmetricsNavigation)
                    .WithMany(p => p.Metrichistories)
                    .HasForeignKey(d => d.Idmetrics)
                    .HasConstraintName("metrichistory_idmetrics_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Iddeliverycompany).HasColumnName("iddeliverycompany");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IddeliverycompanyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Iddeliverycompany)
                    .HasConstraintName("fk_dodelivery");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.ToTable("orderproducts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idorder)
                    .HasConstraintName("orderproducts_idorder_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("orderproducts_idproducts_fkey");
            });

            modelBuilder.Entity<Predictedorder>(entity =>
            {
                entity.ToTable("predictedorder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.Predictedorders)
                    .HasForeignKey(d => d.Idorder)
                    .HasConstraintName("predictedorder_idorder_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Predictedorders)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("predictedorder_idproducts_fkey");
            });

            modelBuilder.Entity<Predictedorderquantity>(entity =>
            {
                entity.ToTable("predictedorderquantity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idmetric).HasColumnName("idmetric");

                entity.Property(e => e.Idpredictedorder).HasColumnName("idpredictedorder");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdmetricNavigation)
                    .WithMany(p => p.Predictedorderquantities)
                    .HasForeignKey(d => d.Idmetric)
                    .HasConstraintName("predictedorderquantity_idmetric_fkey");

                entity.HasOne(d => d.IdpredictedorderNavigation)
                    .WithMany(p => p.Predictedorderquantities)
                    .HasForeignKey(d => d.Idpredictedorder)
                    .HasConstraintName("predictedorderquantity_idpredictedorder_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Reference).HasColumnName("reference");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("products_idcategories_fkey");
            });

            modelBuilder.Entity<Productscode>(entity =>
            {
                entity.ToTable("productscodes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Productscodes)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("productscodes_idproducts_fkey");
            });

            modelBuilder.Entity<Productshistory>(entity =>
            {
                entity.ToTable("productshistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Dateofdeletion)
                    .HasColumnName("dateofdeletion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Iddeletedproduct).HasColumnName("iddeletedproduct");

                entity.Property(e => e.Iddeletedproductscodes).HasColumnName("iddeletedproductscodes");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Reference).HasColumnName("reference");

                entity.HasOne(d => d.IddeletedproductNavigation)
                    .WithMany(p => p.Productshistories)
                    .HasForeignKey(d => d.Iddeletedproduct)
                    .HasConstraintName("productshistory_iddeletedproduct_fkey");

                entity.HasOne(d => d.IddeletedproductscodesNavigation)
                    .WithMany(p => p.Productshistories)
                    .HasForeignKey(d => d.Iddeletedproductscodes)
                    .HasConstraintName("productshistory_iddeletedproductscodes_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
