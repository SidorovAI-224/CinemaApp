using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crewmates",
                columns: table => new
                {
                    CrewmateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crewmates", x => x.CrewmateID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "HallOne",
                columns: table => new
                {
                    SeatID = table.Column<int>(type: "INTEGER", nullable: false),
                    RowID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallOne", x => new { x.SeatID, x.RowID });
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PosterURL = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    TrailerURL = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreID1 = table.Column<int>(type: "INTEGER", nullable: true),
                    GenreID2 = table.Column<int>(type: "INTEGER", nullable: true),
                    GenreID3 = table.Column<int>(type: "INTEGER", nullable: true),
                    GenreID4 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID1",
                        column: x => x.GenreID1,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID2",
                        column: x => x.GenreID2,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID3",
                        column: x => x.GenreID3,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID4",
                        column: x => x.GenreID4,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewmatePositions",
                columns: table => new
                {
                    CrewmateID = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewmatePositions", x => new { x.CrewmateID, x.PositionID });
                    table.ForeignKey(
                        name: "FK_CrewmatePositions_Crewmates_CrewmateID",
                        column: x => x.CrewmateID,
                        principalTable: "Crewmates",
                        principalColumn: "CrewmateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewmatePositions_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCrewmate",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false),
                    CrewmateID = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCrewmate", x => new { x.MovieID, x.CrewmateID });
                    table.ForeignKey(
                        name: "FK_MovieCrewmate_Crewmates_CrewmateID",
                        column: x => x.CrewmateID,
                        principalTable: "Crewmates",
                        principalColumn: "CrewmateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCrewmate_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCrewmate_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Hall = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessionID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<string>(type: "TEXT", nullable: false),
                    SeatID = table.Column<int>(type: "INTEGER", nullable: true),
                    RowID = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_HallOne_SeatID_RowID",
                        columns: x => new { x.SeatID, x.RowID },
                        principalTable: "HallOne",
                        principalColumns: new[] { "SeatID", "RowID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HallOne",
                columns: new[] { "RowID", "SeatID", "IsBooked" },
                values: new object[,]
                {
                    { 1, 1, false },
                    { 2, 1, false },
                    { 3, 1, false },
                    { 4, 1, false },
                    { 5, 1, false },
                    { 6, 1, false },
                    { 7, 1, false },
                    { 8, 1, false },
                    { 9, 1, false },
                    { 10, 1, false },
                    { 1, 2, false },
                    { 2, 2, false },
                    { 3, 2, false },
                    { 4, 2, false },
                    { 5, 2, false },
                    { 6, 2, false },
                    { 7, 2, false },
                    { 8, 2, false },
                    { 9, 2, false },
                    { 10, 2, false },
                    { 1, 3, false },
                    { 2, 3, false },
                    { 3, 3, false },
                    { 4, 3, false },
                    { 5, 3, false },
                    { 6, 3, false },
                    { 7, 3, false },
                    { 8, 3, false },
                    { 9, 3, false },
                    { 10, 3, false },
                    { 1, 4, false },
                    { 2, 4, false },
                    { 3, 4, false },
                    { 4, 4, false },
                    { 5, 4, false },
                    { 6, 4, false },
                    { 7, 4, false },
                    { 8, 4, false },
                    { 9, 4, false },
                    { 10, 4, false },
                    { 1, 5, false },
                    { 2, 5, false },
                    { 3, 5, false },
                    { 4, 5, false },
                    { 5, 5, false },
                    { 6, 5, false },
                    { 7, 5, false },
                    { 8, 5, false },
                    { 9, 5, false },
                    { 10, 5, false },
                    { 1, 6, false },
                    { 2, 6, false },
                    { 3, 6, false },
                    { 4, 6, false },
                    { 5, 6, false },
                    { 6, 6, false },
                    { 7, 6, false },
                    { 8, 6, false },
                    { 9, 6, false },
                    { 10, 6, false },
                    { 1, 7, false },
                    { 2, 7, false },
                    { 3, 7, false },
                    { 4, 7, false },
                    { 5, 7, false },
                    { 6, 7, false },
                    { 7, 7, false },
                    { 8, 7, false },
                    { 9, 7, false },
                    { 10, 7, false },
                    { 1, 8, false },
                    { 2, 8, false },
                    { 3, 8, false },
                    { 4, 8, false },
                    { 5, 8, false },
                    { 6, 8, false },
                    { 7, 8, false },
                    { 8, 8, false },
                    { 9, 8, false },
                    { 10, 8, false },
                    { 1, 9, false },
                    { 2, 9, false },
                    { 3, 9, false },
                    { 4, 9, false },
                    { 5, 9, false },
                    { 6, 9, false },
                    { 7, 9, false },
                    { 8, 9, false },
                    { 9, 9, false },
                    { 10, 9, false },
                    { 1, 10, false },
                    { 2, 10, false },
                    { 3, 10, false },
                    { 4, 10, false },
                    { 5, 10, false },
                    { 6, 10, false },
                    { 7, 10, false },
                    { 8, 10, false },
                    { 9, 10, false },
                    { 10, 10, false },
                    { 1, 11, false },
                    { 2, 11, false },
                    { 3, 11, false },
                    { 4, 11, false },
                    { 5, 11, false },
                    { 6, 11, false },
                    { 7, 11, false },
                    { 8, 11, false },
                    { 9, 11, false },
                    { 10, 11, false },
                    { 1, 12, false },
                    { 2, 12, false },
                    { 3, 12, false },
                    { 4, 12, false },
                    { 5, 12, false },
                    { 6, 12, false },
                    { 7, 12, false },
                    { 8, 12, false },
                    { 9, 12, false },
                    { 10, 12, false },
                    { 1, 13, false },
                    { 2, 13, false },
                    { 3, 13, false },
                    { 4, 13, false },
                    { 5, 13, false },
                    { 6, 13, false },
                    { 7, 13, false },
                    { 8, 13, false },
                    { 9, 13, false },
                    { 10, 13, false },
                    { 1, 14, false },
                    { 2, 14, false },
                    { 3, 14, false },
                    { 4, 14, false },
                    { 5, 14, false },
                    { 6, 14, false },
                    { 7, 14, false },
                    { 8, 14, false },
                    { 9, 14, false },
                    { 10, 14, false },
                    { 1, 15, false },
                    { 2, 15, false },
                    { 3, 15, false },
                    { 4, 15, false },
                    { 5, 15, false },
                    { 6, 15, false },
                    { 7, 15, false },
                    { 8, 15, false },
                    { 9, 15, false },
                    { 10, 15, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewmatePositions_PositionID",
                table: "CrewmatePositions",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrewmate_CrewmateID",
                table: "MovieCrewmate",
                column: "CrewmateID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrewmate_PositionID",
                table: "MovieCrewmate",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreID",
                table: "MovieGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                table: "Movies",
                column: "GenreID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieID",
                table: "Sessions",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatID_RowID",
                table: "Tickets",
                columns: new[] { "SeatID", "RowID" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionID",
                table: "Tickets",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CrewmatePositions");

            migrationBuilder.DropTable(
                name: "MovieCrewmate");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Crewmates");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HallOne");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
