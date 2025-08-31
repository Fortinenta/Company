using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataWithTanggalHabisKontrak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 1,
                column: "TanggalHabisKontrak",
                value: new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 2,
                column: "TanggalHabisKontrak",
                value: new DateTime(2028, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 3,
                column: "TanggalHabisKontrak",
                value: new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 4,
                column: "TanggalHabisKontrak",
                value: new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 5,
                column: "TanggalHabisKontrak",
                value: new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 6,
                column: "TanggalHabisKontrak",
                value: new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 7,
                column: "TanggalHabisKontrak",
                value: new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 8,
                column: "TanggalHabisKontrak",
                value: new DateTime(2028, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 9,
                column: "TanggalHabisKontrak",
                value: new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 10,
                column: "TanggalHabisKontrak",
                value: new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 11,
                column: "TanggalHabisKontrak",
                value: new DateTime(2029, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 1,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 2,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 3,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 4,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 5,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 6,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 7,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 8,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 9,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 10,
                column: "TanggalHabisKontrak",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pegawai",
                keyColumn: "PegawaiID",
                keyValue: 11,
                column: "TanggalHabisKontrak",
                value: null);
        }
    }
}
