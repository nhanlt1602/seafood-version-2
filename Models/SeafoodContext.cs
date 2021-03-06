using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace seafood_version_2.Models
{
    public partial class SeafoodContext : DbContext
    {
        public SeafoodContext()
        {
        }

        public SeafoodContext(DbContextOptions<SeafoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SE140057-LONGNH;Initial Catalog=Seafood;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.ProTypeId)
                    .HasName("PK__Category__56F52A472ED66F8A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a4");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK__OrderDet__3724BD52984F15E8");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a3");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a5");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__Product__5BBBEEF5D69C35A7");

                entity.Property(e => e.ImgUrl).IsUnicode(false);

                entity.HasOne(d => d.ProType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
