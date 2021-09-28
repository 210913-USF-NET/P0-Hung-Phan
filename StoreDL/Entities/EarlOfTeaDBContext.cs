using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class EarlOfTeaDBContext : DbContext
    {
        public EarlOfTeaDBContext()
        {
        }

        public EarlOfTeaDBContext(DbContextOptions<EarlOfTeaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CPassword)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("C_Password");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__Order_De__F6868F7229DB83A1");

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDetailsId).HasColumnName("Order_Details_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Order_ID");

                entity.Property(e => e.PriceOfProduct).HasColumnName("Price_Of_Product");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductQty).HasColumnName("Product_Qty");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Store_Location");

                entity.Property(e => e.Total).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Customer_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Det__Produ__71D1E811");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.Category)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryLocation)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Inventory_Location");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
