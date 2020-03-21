using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reimsys
{
    public partial class ReimsysContext : DbContext
    {
        public ReimsysContext()
        {
        }

        public ReimsysContext(DbContextOptions<ReimsysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReimburseTypeLevel1> ReimburseTypeLevel1 { get; set; }
        public virtual DbSet<ReimburseTypeLevel2> ReimburseTypeLevel2 { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatus { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Reimsys;Username=postgres;Password=smashlab21");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReimburseTypeLevel1>(entity =>
            {
                entity.ToTable("reimburse_type_level_1", "ref");

                entity.Property(e => e.ReimburseTypeLevel1Id).HasColumnName("reimburse_type_level_1_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasMaxLength(512);

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<ReimburseTypeLevel2>(entity =>
            {
                entity.ToTable("reimburse_type_level_2", "ref");

                entity.Property(e => e.ReimburseTypeLevel2Id).HasColumnName("reimburse_type_level_2_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ReimburseTypeLevel1Id)
                    .HasColumnName("reimburse_type_level_1_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasMaxLength(512);

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasMaxLength(512);

                entity.HasOne(d => d.ReimburseTypeLevel1)
                    .WithMany(p => p.ReimburseTypeLevel2)
                    .HasForeignKey(d => d.ReimburseTypeLevel1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_level_1");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction", "transaction");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Evidence).HasColumnName("evidence");

                entity.Property(e => e.ReimburseTypeLevel2)
                    .HasColumnName("reimburse_type_level_2")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.ReimburseTypeLevel2Navigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.ReimburseTypeLevel2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_type");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.HasKey(e => e.Status)
                    .HasName("transaction_status_pkey");

                entity.ToTable("transaction_status", "ref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("status_code")
                    .HasMaxLength(255);

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("user_role_pkey");

                entity.ToTable("user_role", "user");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.RoleCode)
                    .HasColumnName("role_code")
                    .HasMaxLength(255);

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_pkey");

                entity.ToTable("users", "user");

                entity.HasComment("user login info, such as username and credentials");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("nextval('\"user\".user_user_id_seq'::regclass)");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PersonalNumber).HasColumnName("personal_number");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("nextval('\"user\".user_role_id_seq'::regclass)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
