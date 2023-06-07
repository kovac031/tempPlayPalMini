using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PlayPalMini.DAL
{
    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=PlayPalMiniDatabase")
        {
        }

        public virtual DbSet<BoardGame> BoardGames { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardGame>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<BoardGame>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.Comment)
                .IsUnicode(false);
        }
    }
}
