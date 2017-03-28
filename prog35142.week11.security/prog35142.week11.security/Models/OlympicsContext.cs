namespace prog35142.week11.security.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OlympicsContext : DbContext
    {
        public OlympicsContext()
            : base("name=OlympicsContext")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Sports)
                .WithMany(e => e.Athletes)
                .Map(m => m.ToTable("AthleteSport").MapLeftKey("Athletes_AthleteId").MapRightKey("Sports_SportId"));

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);
        }
    }
}
