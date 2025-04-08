using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GalacticDataExchange.Shared.Migrations
{
    /// <inheritdoc />
    public partial class SeedSensor : Migration
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
                name: "Sensors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.ID);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorReadings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SensorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorReadings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SensorReadings_Sensors_SensorID",
                        column: x => x.SensorID,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataArtifactTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A cube that stores data in a holographic matrix.", "Holographic Memory Cube" },
                    { 2, "A sensor log that has been encrypted.", "Encrypted Sensor Log" },
                    { 3, "An image of a relic that has been digitized.", "Digital Relic Image" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Bridge of the Starfleet", "Thermo-1", "Temperature" },
                    { 2, "Engineering Deck on the D'Vorik", "Baro-1", "Pressure" },
                    { 3, "Cargo Bay of the Nebulon", "Hygro-1", "Humidity" },
                    { 4, "Observation Deck of the Helix", "Lumina-1", "Light" },
                    { 5, "Propulsion Chamber, Quasar Wing", "Vibro-1", "Vibration" },
                    { 6, "Navigational Bridge, Delta Sector", "Motion-1", "Motion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataArtifacts_DataArtifactTypeID",
                table: "DataArtifacts",
                column: "DataArtifactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SensorReadings_SensorID",
                table: "SensorReadings",
                column: "SensorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataArtifacts");

            migrationBuilder.DropTable(
                name: "SensorReadings");

            migrationBuilder.DropTable(
                name: "DataArtifactTypes");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
