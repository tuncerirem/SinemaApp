using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biletler_Filmler_FilmId1",
                table: "Biletler");

            migrationBuilder.DropForeignKey(
                name: "FK_Biletler_Koltuklar_KoltukId",
                table: "Biletler");

            migrationBuilder.DropForeignKey(
                name: "FK_Biletler_Kullanicilar_KullaniciId1",
                table: "Biletler");

            migrationBuilder.DropForeignKey(
                name: "FK_Biletler_Seanslar_SeansId1",
                table: "Biletler");

            migrationBuilder.DropIndex(
                name: "IX_Biletler_FilmId1",
                table: "Biletler");

            migrationBuilder.DropIndex(
                name: "IX_Biletler_KullaniciId1",
                table: "Biletler");

            migrationBuilder.DropIndex(
                name: "IX_Biletler_SeansId1",
                table: "Biletler");

            migrationBuilder.DropColumn(
                name: "BiletId",
                table: "Koltuklar");

            migrationBuilder.DropColumn(
                name: "FilmId1",
                table: "Biletler");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Biletler");

            migrationBuilder.DropColumn(
                name: "SeansId1",
                table: "Biletler");

            migrationBuilder.AddForeignKey(
                name: "FK_Biletler_Koltuklar_KoltukId",
                table: "Biletler",
                column: "KoltukId",
                principalTable: "Koltuklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biletler_Koltuklar_KoltukId",
                table: "Biletler");

            migrationBuilder.AddColumn<int>(
                name: "BiletId",
                table: "Koltuklar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmId1",
                table: "Biletler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId1",
                table: "Biletler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeansId1",
                table: "Biletler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_FilmId1",
                table: "Biletler",
                column: "FilmId1");

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_KullaniciId1",
                table: "Biletler",
                column: "KullaniciId1");

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_SeansId1",
                table: "Biletler",
                column: "SeansId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Biletler_Filmler_FilmId1",
                table: "Biletler",
                column: "FilmId1",
                principalTable: "Filmler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Biletler_Koltuklar_KoltukId",
                table: "Biletler",
                column: "KoltukId",
                principalTable: "Koltuklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Biletler_Kullanicilar_KullaniciId1",
                table: "Biletler",
                column: "KullaniciId1",
                principalTable: "Kullanicilar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Biletler_Seanslar_SeansId1",
                table: "Biletler",
                column: "SeansId1",
                principalTable: "Seanslar",
                principalColumn: "Id");
        }
    }
}
