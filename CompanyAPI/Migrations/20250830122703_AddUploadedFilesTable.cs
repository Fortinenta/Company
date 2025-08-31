using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUploadedFilesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabang",
                columns: table => new
                {
                    CabangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaCabang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabang", x => x.CabangID);
                });

            migrationBuilder.CreateTable(
                name: "Jabatan",
                columns: table => new
                {
                    JabatanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaJabatan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jabatan", x => x.JabatanID);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    PegawaiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaLengkap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NomorTelepon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TanggalMasuk = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusKontrak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CabangID = table.Column<int>(type: "int", nullable: true),
                    JabatanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawai", x => x.PegawaiID);
                    table.ForeignKey(
                        name: "FK_Pegawai_Cabang_CabangID",
                        column: x => x.CabangID,
                        principalTable: "Cabang",
                        principalColumn: "CabangID");
                    table.ForeignKey(
                        name: "FK_Pegawai_Jabatan_JabatanID",
                        column: x => x.JabatanID,
                        principalTable: "Jabatan",
                        principalColumn: "JabatanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_CabangID",
                table: "Pegawai",
                column: "CabangID");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_JabatanID",
                table: "Pegawai",
                column: "JabatanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "Cabang");

            migrationBuilder.DropTable(
                name: "Jabatan");
        }
    }
}
