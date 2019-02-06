using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingApp.API.Models
{
    public partial class DEMOContext : DbContext
    {
        public DEMOContext()
        {
        }

        public DEMOContext(DbContextOptions<DEMOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExaltUser> ExaltUser { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<User> User { get; set; }


        // Unable to generate entity type for table 'dbo.T1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.T2'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Age)
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExaltUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ExaltUse__206A9DF813C34DB9");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KnownAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastActive)
                    .HasMaxLength(200)
                    .IsUnicode(false);                

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.PhotoId).HasColumnName("Photo_id");

                entity.Property(e => e.DateAdded)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsMain).HasColumnName("isMain");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Photo__User_id__49C3F6B7");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("Tbl_User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PasswordHash).HasMaxLength(1000);

                entity.Property(e => e.PasswordSalt).HasMaxLength(1000);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
