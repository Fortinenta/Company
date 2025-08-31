using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTanggalHabisKontrakToPegawai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalHabisKontrak",
                table: "Pegawai",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cabang",
                columns: new[] { "CabangID", "Alamat", "KodePos", "Kota", "NamaCabang" },
                values: new object[,]
                {
                    { 1, "Jl. Jend. Sudirman Kav. 52-53", "12190", "Jakarta Selatan", "Kantor Pusat" },
                    { 2, "Jl. Asia Afrika No. 1", "40111", "Bandung", "Cabang Bandung" },
                    { 3, "Jl. Basuki Rahmat No. 129-131", "60271", "Surabaya", "Cabang Surabaya" },
                    { 4, "Jl. Imam Bonjol No. 17", "20112", "Medan", "Cabang Medan" },
                    { 5, "Jl. Sultan Hasanuddin No. 5", "90111", "Makassar", "Cabang Makassar" },
                    { 6, "Jl. Malioboro No. 60", "55213", "Yogyakarta", "Cabang Yogyakarta" },
                    { 7, "Jl. Gajah Mada No. 1", "50134", "Semarang", "Cabang Semarang" },
                    { 8, "Jl. Teuku Umar No. 220", "80114", "Denpasar", "Cabang Denpasar" },
                    { 9, "Jl. Jend. Sudirman No. 123", "30129", "Palembang", "Cabang Palembang" },
                    { 10, "Jl. Jend. Sudirman No. 45", "76114", "Balikpapan", "Cabang Balikpapan" }
                });

            migrationBuilder.InsertData(
                table: "Jabatan",
                columns: new[] { "JabatanID", "Deskripsi", "NamaJabatan" },
                values: new object[,]
                {
                    { 1, "Manages a team or department.", "Manager" },
                    { 2, "Designs, develops, and maintains software.", "Software Engineer" },
                    { 3, "Ensures the quality of software through testing.", "Quality Assurance" },
                    { 4, "Manages employee relations and recruitment.", "Human Resources" },
                    { 5, "Manages financial records and transactions.", "Accountant" },
                    { 6, "Oversees projects from initiation to completion.", "Project Manager" },
                    { 7, "Analyzes business needs and processes.", "Business Analyst" },
                    { 8, "Designs user interfaces and user experiences.", "UI/UX Designer" },
                    { 9, "Manages infrastructure and deployment pipelines.", "DevOps Engineer" },
                    { 10, "Analyzes and interprets complex data.", "Data Scientist" }
                });

            migrationBuilder.InsertData(
                table: "Pegawai",
                columns: new[] { "PegawaiID", "Alamat", "CabangID", "Email", "JabatanID", "NamaLengkap", "NomorTelepon", "StatusKontrak", "TanggalHabisKontrak", "TanggalLahir", "TanggalMasuk" },
                values: new object[,]
                {
                    { 1, "Jl. Merdeka No. 10", 1, "budi.santoso@example.com", 1, "Budi Santoso", "081234567890", "Permanent", null, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Jl. Pahlawan No. 5", 1, "ani.yudhoyono@example.com", 2, "Ani Yudhoyono", "081234567891", "Permanent", null, new DateTime(1990, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Jl. Kenanga No. 25", 2, "cici.paramida@example.com", 3, "Cici Paramida", "081234567892", "Contract", null, new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Jl. Mawar No. 15", 3, "doni.kusuma@example.com", 4, "Doni Kusuma", "081234567893", "Permanent", null, new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Jl. Melati No. 30", 4, "eka.sari@example.com", 5, "Eka Sari", "081234567894", "Contract", null, new DateTime(1995, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Jl. Anggrek No. 12", 5, "fajar.nugraha@example.com", 6, "Fajar Nugraha", "081234567895", "Permanent", null, new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Jl. Cendana No. 8", 6, "gita.gutawa@example.com", 7, "Gita Gutawa", "081234567896", "Intern", null, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Jl. Flamboyan No. 3", 7, "hadi.pranoto@example.com", 8, "Hadi Pranoto", "081234567897", "Permanent", null, new DateTime(1989, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Jl. Dahlia No. 21", 8, "indah.permata@example.com", 9, "Indah Permata", "081234567898", "Contract", null, new DateTime(1996, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Jl. Istana No. 1", 9, "joko.widodo@example.com", 10, "Joko Widodo", "081234567899", "Permanent", null, new DateTime(1984, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Jl. Bunga No. 9", 10, "kiki.amalia@example.com", 1, "Kiki Amalia", "081234567880", "Permanent", null, new DateTime(1991, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cabang",
                keyColumn: "CabangID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jabatan",
                keyColumn: "JabatanID",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "TanggalHabisKontrak",
                table: "Pegawai");
        }
    }
}
