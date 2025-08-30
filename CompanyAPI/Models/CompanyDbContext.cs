using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Pegawai> Pegawai { get; set; }
        public DbSet<Cabang> Cabang { get; set; }
        public DbSet<Jabatan> Jabatan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Pegawai>()
                .HasOne(p => p.Cabang)
                .WithMany(c => c.Pegawai)
                .HasForeignKey(p => p.CabangID);

            modelBuilder.Entity<Pegawai>()
                .HasOne(p => p.Jabatan)
                .WithMany(j => j.Pegawai)
                .HasForeignKey(p => p.JabatanID);

            // Seed data can be added here if not using SQL scripts
        }
    }
}
