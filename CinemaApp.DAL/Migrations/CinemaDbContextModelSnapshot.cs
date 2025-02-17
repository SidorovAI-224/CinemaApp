﻿// <auto-generated />
using System;
using CinemaApp.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.DAL.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("CinemaApp.DAL.Entities.Crewmate", b =>
                {
                    b.Property<int>("CrewmateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CrewmateID");

                    b.ToTable("Crewmates");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.CrewmatePositions", b =>
                {
                    b.Property<int>("CrewmateID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CrewmateID", "PositionID");

                    b.HasIndex("PositionID");

                    b.ToTable("CrewmatePositions");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.HallOne", b =>
                {
                    b.Property<int>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatID");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreID1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreID2")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreID3")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreID4")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PosterURL")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("TrailerURL")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID");

                    b.HasIndex("GenreID");

                    b.HasIndex("GenreID1");

                    b.HasIndex("GenreID2");

                    b.HasIndex("GenreID3");

                    b.HasIndex("GenreID4");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.MovieCrewmate", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CrewmateID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID", "CrewmateID");

                    b.HasIndex("CrewmateID");

                    b.HasIndex("PositionID");

                    b.ToTable("MovieCrewmate");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("PositionID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Session", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hall")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("SessionID");

                    b.HasIndex("MovieID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("HallOneSeatID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Seat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketID");

                    b.HasIndex("HallOneSeatID");

                    b.HasIndex("SessionID");

                    b.HasIndex("UserID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.CrewmatePositions", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.Crewmate", "Crewmate")
                        .WithMany("CrewmatePositions")
                        .HasForeignKey("CrewmateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Position", "Position")
                        .WithMany("CrewmatePositions")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crewmate");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Movie", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre1")
                        .WithMany()
                        .HasForeignKey("GenreID1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre2")
                        .WithMany()
                        .HasForeignKey("GenreID2")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre3")
                        .WithMany()
                        .HasForeignKey("GenreID3")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre4")
                        .WithMany()
                        .HasForeignKey("GenreID4")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Genre");

                    b.Navigation("Genre1");

                    b.Navigation("Genre2");

                    b.Navigation("Genre3");

                    b.Navigation("Genre4");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.MovieCrewmate", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.Crewmate", "Crewmate")
                        .WithMany("MoviesCrewmates")
                        .HasForeignKey("CrewmateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Movie", "Movie")
                        .WithMany("MovieCrewmates")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crewmate");

                    b.Navigation("Movie");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.MovieGenre", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Session", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Ticket", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.HallOne", "HallOne")
                        .WithMany("Tickets")
                        .HasForeignKey("HallOneSeatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallOne");

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CinemaApp.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Crewmate", b =>
                {
                    b.Navigation("CrewmatePositions");

                    b.Navigation("MoviesCrewmates");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Genre", b =>
                {
                    b.Navigation("MovieGenres");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.HallOne", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Movie", b =>
                {
                    b.Navigation("MovieCrewmates");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Position", b =>
                {
                    b.Navigation("CrewmatePositions");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.Session", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaApp.DAL.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
