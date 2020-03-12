using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevUtilitiesV2MVCApp.Models
{
    public partial class DevelopmentUtilitiesV2Context : DbContext
    {
        public DevelopmentUtilitiesV2Context()
        {
        }

        public DevelopmentUtilitiesV2Context(DbContextOptions<DevelopmentUtilitiesV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CodeBlocks> CodeBlocks { get; set; }
        public virtual DbSet<Commands> Commands { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Problems> Problems { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GIV9OCS;User ID=DevUtilitiesUser;Password=Password_21600681;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CodeBlocks>(entity =>
            {
                entity.Property(e => e.Block).IsRequired();

                entity.Property(e => e.Langue)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Commands>(entity =>
            {
                entity.Property(e => e.Command).IsRequired();

                entity.Property(e => e.ConsoleType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Exercise__3214EC0653CED8CB")
                    .IsUnique();

                entity.Property(e => e.Exercise).IsRequired();

                entity.Property(e => e.ExerciseLevel).HasMaxLength(50);

                entity.Property(e => e.ExpectedSolution).HasMaxLength(50);

                entity.Property(e => e.Langues).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.ProjectType).HasMaxLength(50);

                entity.Property(e => e.VarableData).HasMaxLength(50);
            });

            modelBuilder.Entity<Problems>(entity =>
            {
                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Resources>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__Resource__2CB664DC304E151E")
                    .IsUnique();

                entity.Property(e => e.Langues).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
