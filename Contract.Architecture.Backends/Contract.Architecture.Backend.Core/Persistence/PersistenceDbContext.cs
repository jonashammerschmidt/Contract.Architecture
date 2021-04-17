using Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contract.Architecture.Backend.Core.Persistence
{
    public partial class PersistenceDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PersistenceDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private PersistenceDbContext(DbContextOptions<PersistenceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfEmailUser> EmailUsers { get; set; }

        public virtual DbSet<EfEmailUserPasswordResetToken> EmailUserPasswordResetTokens { get; set; }

        public virtual DbSet<EfSession> Sessions { get; set; }

        public virtual DbSet<EfBank> Banken { get; set; }

        public virtual DbSet<EfKunde> Kunden { get; set; }

        public static PersistenceDbContext CustomInstantiate(DbContextOptions<PersistenceDbContext> options)
        {
            return new PersistenceDbContext(options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("Contract.Architecture.Backend.Core.Database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfEmailUserPasswordResetToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_EmailUserPasswordResetToken_Token");

                entity.Property(e => e.Token).HasMaxLength(64);

                entity.Property(e => e.EmailUserId).IsRequired();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.HasOne(d => d.EmailUser)
                    .WithMany(p => p.EmailUserPasswordResetTokens)
                    .HasForeignKey(d => d.EmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserPasswordResetToken_EmailUserId");
            });

            modelBuilder.Entity<EfEmailUser>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("EmailUsersEmailUnique")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(88);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(54);
            });

            modelBuilder.Entity<EfSession>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_Sessions_Token");

                entity.Property(e => e.Token).HasMaxLength(64);

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfBank>(entity =>
            {
                entity.ToTable("Banken");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<EfKunde>(entity =>
            {
                entity.ToTable("Kunden");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(256);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Kunden)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Kunden_BankId");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}