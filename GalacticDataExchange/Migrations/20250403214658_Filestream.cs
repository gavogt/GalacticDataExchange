using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GalacticDataExchange.Migrations
{
    /// <inheritdoc />
    public partial class Filestream : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataArtifactTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataArtifactTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataArtifacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawAlienText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptionKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataArtifactTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataArtifacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataArtifacts_DataArtifactTypes_DataArtifactTypeID",
                        column: x => x.DataArtifactTypeID,
                        principalTable: "DataArtifactTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataArtifactTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A cube that stores data in a holographic matrix.", "Holographic Memory Cube" },
                    { 2, "A sensor log that has been encrypted.", "Encrypted Sensor Log" },
                    { 3, "An image of a relic that has been digitized.", "Digital Relic Image" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataArtifacts_DataArtifactTypeID",
                table: "DataArtifacts",
                column: "DataArtifactTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataArtifacts");

            migrationBuilder.DropTable(
                name: "DataArtifactTypes");
        }
    }
}
