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
        public DbSet<UploadedFile> UploadedFiles { get; set; }

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

            // Seed data for Cabang Table
            modelBuilder.Entity<Cabang>().HasData(
                new Cabang { CabangID = 1, NamaCabang = "Kantor Pusat", Alamat = "Jl. Jend. Sudirman Kav. 52-53", Kota = "Jakarta Selatan", KodePos = "12190" },
                new Cabang { CabangID = 2, NamaCabang = "Cabang Bandung", Alamat = "Jl. Asia Afrika No. 1", Kota = "Bandung", KodePos = "40111" },
                new Cabang { CabangID = 3, NamaCabang = "Cabang Surabaya", Alamat = "Jl. Basuki Rahmat No. 129-131", Kota = "Surabaya", KodePos = "60271" },
                new Cabang { CabangID = 4, NamaCabang = "Cabang Medan", Alamat = "Jl. Imam Bonjol No. 17", Kota = "Medan", KodePos = "20112" },
                new Cabang { CabangID = 5, NamaCabang = "Cabang Makassar", Alamat = "Jl. Sultan Hasanuddin No. 5", Kota = "Makassar", KodePos = "90111" },
                new Cabang { CabangID = 6, NamaCabang = "Cabang Yogyakarta", Alamat = "Jl. Malioboro No. 60", Kota = "Yogyakarta", KodePos = "55213" },
                new Cabang { CabangID = 7, NamaCabang = "Cabang Semarang", Alamat = "Jl. Gajah Mada No. 1", Kota = "Semarang", KodePos = "50134" },
                new Cabang { CabangID = 8, NamaCabang = "Cabang Denpasar", Alamat = "Jl. Teuku Umar No. 220", Kota = "Denpasar", KodePos = "80114" },
                new Cabang { CabangID = 9, NamaCabang = "Cabang Palembang", Alamat = "Jl. Jend. Sudirman No. 123", Kota = "Palembang", KodePos = "30129" },
                new Cabang { CabangID = 10, NamaCabang = "Cabang Balikpapan", Alamat = "Jl. Jend. Sudirman No. 45", Kota = "Balikpapan", KodePos = "76114" }
            );

            // Seed data for Jabatan Table
            modelBuilder.Entity<Jabatan>().HasData(
                new Jabatan { JabatanID = 1, NamaJabatan = "Manager", Deskripsi = "Manages a team or department." },
                new Jabatan { JabatanID = 2, NamaJabatan = "Software Engineer", Deskripsi = "Designs, develops, and maintains software." },
                new Jabatan { JabatanID = 3, NamaJabatan = "Quality Assurance", Deskripsi = "Ensures the quality of software through testing." },
                new Jabatan { JabatanID = 4, NamaJabatan = "Human Resources", Deskripsi = "Manages employee relations and recruitment." },
                new Jabatan { JabatanID = 5, NamaJabatan = "Accountant", Deskripsi = "Manages financial records and transactions." },
                new Jabatan { JabatanID = 6, NamaJabatan = "Project Manager", Deskripsi = "Oversees projects from initiation to completion." },
                new Jabatan { JabatanID = 7, NamaJabatan = "Business Analyst", Deskripsi = "Analyzes business needs and processes." },
                new Jabatan { JabatanID = 8, NamaJabatan = "UI/UX Designer", Deskripsi = "Designs user interfaces and user experiences." },
                new Jabatan { JabatanID = 9, NamaJabatan = "DevOps Engineer", Deskripsi = "Manages infrastructure and deployment pipelines." },
                new Jabatan { JabatanID = 10, NamaJabatan = "Data Scientist", Deskripsi = "Analyzes and interprets complex data." }
            );

            // Seed data for Pegawai Table
            modelBuilder.Entity<Pegawai>().HasData(
                new Pegawai { PegawaiID = 1, NamaLengkap = "Budi Santoso", TanggalLahir = new DateTime(1985, 5, 10), Alamat = "Jl. Merdeka No. 10", NomorTelepon = "081234567890", Email = "budi.santoso@example.com", TanggalMasuk = new DateTime(2015, 1, 15), TanggalHabisKontrak = new DateTime(2025, 1, 15), StatusKontrak = "Permanent", CabangID = 1, JabatanID = 1 },
                new Pegawai { PegawaiID = 2, NamaLengkap = "Ani Yudhoyono", TanggalLahir = new DateTime(1990, 2, 20), Alamat = "Jl. Pahlawan No. 5", NomorTelepon = "081234567891", Email = "ani.yudhoyono@example.com", TanggalMasuk = new DateTime(2018, 3, 10), TanggalHabisKontrak = new DateTime(2028, 3, 10), StatusKontrak = "Permanent", CabangID = 1, JabatanID = 2 },
                new Pegawai { PegawaiID = 3, NamaLengkap = "Cici Paramida", TanggalLahir = new DateTime(1992, 8, 15), Alamat = "Jl. Kenanga No. 25", NomorTelepon = "081234567892", Email = "cici.paramida@example.com", TanggalMasuk = new DateTime(2019, 7, 20), TanggalHabisKontrak = new DateTime(2024, 7, 20), StatusKontrak = "Contract", CabangID = 2, JabatanID = 3 },
                new Pegawai { PegawaiID = 4, NamaLengkap = "Doni Kusuma", TanggalLahir = new DateTime(1988, 11, 30), Alamat = "Jl. Mawar No. 15", NomorTelepon = "081234567893", Email = "doni.kusuma@example.com", TanggalMasuk = new DateTime(2017, 6, 1), TanggalHabisKontrak = new DateTime(2027, 6, 1), StatusKontrak = "Permanent", CabangID = 3, JabatanID = 4 },
                new Pegawai { PegawaiID = 5, NamaLengkap = "Eka Sari", TanggalLahir = new DateTime(1995, 1, 25), Alamat = "Jl. Melati No. 30", NomorTelepon = "081234567894", Email = "eka.sari@example.com", TanggalMasuk = new DateTime(2020, 2, 18), TanggalHabisKontrak = new DateTime(2025, 2, 18), StatusKontrak = "Contract", CabangID = 4, JabatanID = 5 },
                new Pegawai { PegawaiID = 6, NamaLengkap = "Fajar Nugraha", TanggalLahir = new DateTime(1987, 7, 7), Alamat = "Jl. Anggrek No. 12", NomorTelepon = "081234567895", Email = "fajar.nugraha@example.com", TanggalMasuk = new DateTime(2016, 9, 11), TanggalHabisKontrak = new DateTime(2026, 9, 11), StatusKontrak = "Permanent", CabangID = 5, JabatanID = 6 },
                new Pegawai { PegawaiID = 7, NamaLengkap = "Gita Gutawa", TanggalLahir = new DateTime(1993, 4, 18), Alamat = "Jl. Cendana No. 8", NomorTelepon = "081234567896", Email = "gita.gutawa@example.com", TanggalMasuk = new DateTime(2021, 1, 5), TanggalHabisKontrak = new DateTime(2024, 1, 5), StatusKontrak = "Intern", CabangID = 6, JabatanID = 7 },
                new Pegawai { PegawaiID = 8, NamaLengkap = "Hadi Pranoto", TanggalLahir = new DateTime(1989, 12, 12), Alamat = "Jl. Flamboyan No. 3", NomorTelepon = "081234567897", Email = "hadi.pranoto@example.com", TanggalMasuk = new DateTime(2018, 8, 8), TanggalHabisKontrak = new DateTime(2028, 8, 8), StatusKontrak = "Permanent", CabangID = 7, JabatanID = 8 },
                new Pegawai { PegawaiID = 9, NamaLengkap = "Indah Permata", TanggalLahir = new DateTime(1996, 6, 6), Alamat = "Jl. Dahlia No. 21", NomorTelepon = "081234567898", Email = "indah.permata@example.com", TanggalMasuk = new DateTime(2022, 3, 15), TanggalHabisKontrak = new DateTime(2025, 3, 15), StatusKontrak = "Contract", CabangID = 8, JabatanID = 9 },
                new Pegawai { PegawaiID = 10, NamaLengkap = "Joko Widodo", TanggalLahir = new DateTime(1984, 3, 3), Alamat = "Jl. Istana No. 1", NomorTelepon = "081234567899", Email = "joko.widodo@example.com", TanggalMasuk = new DateTime(2014, 10, 20), TanggalHabisKontrak = new DateTime(2024, 10, 20), StatusKontrak = "Permanent", CabangID = 9, JabatanID = 10 },
                new Pegawai { PegawaiID = 11, NamaLengkap = "Kiki Amalia", TanggalLahir = new DateTime(1991, 9, 9), Alamat = "Jl. Bunga No. 9", NomorTelepon = "081234567880", Email = "kiki.amalia@example.com", TanggalMasuk = new DateTime(2019, 11, 11), TanggalHabisKontrak = new DateTime(2029, 11, 11), StatusKontrak = "Permanent", CabangID = 10, JabatanID = 1 }
            );
        }
    }
}
