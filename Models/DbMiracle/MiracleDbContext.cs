using Microsoft.EntityFrameworkCore;

namespace Cinema_Info_Viewer.Models.DbMiracle
{
    public class MiracleDbContext : DbContext
    {
        public MiracleDbContext(DbContextOptions<MiracleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Content table configuration
            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("content");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("short_name")
                    .HasMaxLength(255);

                entity.Property(e => e.DistributorId)
                    .HasColumnName("distributor_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date");

                entity.Property(e => e.ContentFormat)
                    .HasColumnName("content_format");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration");
            });
        }
    }
}
