using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourMovies.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCinemaCinemaCastAndCinemaCrew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_CinemaCast_CinemaCastId",
                table: "Cinema");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_CinemaCrew_CinemaCrewId",
                table: "Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_CinemaCastId",
                table: "Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_CinemaCrewId",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "CinemaCastId",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "CinemaCrewId",
                table: "Cinema");

            migrationBuilder.AddColumn<Guid>(
                name: "CinemaId",
                table: "CinemaCrew",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CinemaId",
                table: "CinemaCast",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CinemaCrew_CinemaId",
                table: "CinemaCrew",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaCast_CinemaId",
                table: "CinemaCast",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCast_Cinema_CinemaId",
                table: "CinemaCast",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCrew_Cinema_CinemaId",
                table: "CinemaCrew",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaCast_Cinema_CinemaId",
                table: "CinemaCast");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaCrew_Cinema_CinemaId",
                table: "CinemaCrew");

            migrationBuilder.DropIndex(
                name: "IX_CinemaCrew_CinemaId",
                table: "CinemaCrew");

            migrationBuilder.DropIndex(
                name: "IX_CinemaCast_CinemaId",
                table: "CinemaCast");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "CinemaCrew");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "CinemaCast");

            migrationBuilder.AddColumn<Guid>(
                name: "CinemaCastId",
                table: "Cinema",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CinemaCrewId",
                table: "Cinema",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_CinemaCastId",
                table: "Cinema",
                column: "CinemaCastId");

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_CinemaCrewId",
                table: "Cinema",
                column: "CinemaCrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_CinemaCast_CinemaCastId",
                table: "Cinema",
                column: "CinemaCastId",
                principalTable: "CinemaCast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_CinemaCrew_CinemaCrewId",
                table: "Cinema",
                column: "CinemaCrewId",
                principalTable: "CinemaCrew",
                principalColumn: "Id");
        }
    }
}
