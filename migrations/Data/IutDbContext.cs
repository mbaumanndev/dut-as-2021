using Microsoft.EntityFrameworkCore;

namespace MBaumann.IUT.Migrations.Data
{
    public class IutDbContext : DbContext
    {
        public IutDbContext(DbContextOptions<IutDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Salle>(sb => {
                sb.HasKey(s => s.Id);

                sb.Property(s => s.Nom)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);
            });

            base.OnModelCreating(builder);
        }

        public DbSet<Salle> Salle { get; set; }
    }
}
