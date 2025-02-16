using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Tickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "TrailerURL",
                table: "Movies",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "PosterURL",
                table: "Movies",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "TEXT",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "GenreID1",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreID2",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreID3",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreID4",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID1",
                table: "Movies",
                column: "GenreID1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID2",
                table: "Movies",
                column: "GenreID2");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID3",
                table: "Movies",
                column: "GenreID3");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID4",
                table: "Movies",
                column: "GenreID4");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID1",
                table: "Movies",
                column: "GenreID1",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID2",
                table: "Movies",
                column: "GenreID2",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID3",
                table: "Movies",
                column: "GenreID3",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID4",
                table: "Movies",
                column: "GenreID4",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID1",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID2",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID3",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID4",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreID1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreID2",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreID3",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreID4",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreID1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreID2",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreID3",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreID4",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrailerURL",
                table: "Movies",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PosterURL",
                table: "Movies",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
