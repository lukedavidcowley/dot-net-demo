using Microsoft.EntityFrameworkCore.Migrations;

namespace LukeCowley.Web.Migrations
{
    public partial class AddedSensorReadingsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorReading_Sols_SolId",
                table: "SensorReading");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorReading",
                table: "SensorReading");

            migrationBuilder.RenameTable(
                name: "SensorReading",
                newName: "SensorReadings");

            migrationBuilder.RenameIndex(
                name: "IX_SensorReading_SolId",
                table: "SensorReadings",
                newName: "IX_SensorReadings_SolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorReadings",
                table: "SensorReadings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorReadings_Sols_SolId",
                table: "SensorReadings",
                column: "SolId",
                principalTable: "Sols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorReadings_Sols_SolId",
                table: "SensorReadings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorReadings",
                table: "SensorReadings");

            migrationBuilder.RenameTable(
                name: "SensorReadings",
                newName: "SensorReading");

            migrationBuilder.RenameIndex(
                name: "IX_SensorReadings_SolId",
                table: "SensorReading",
                newName: "IX_SensorReading_SolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorReading",
                table: "SensorReading",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorReading_Sols_SolId",
                table: "SensorReading",
                column: "SolId",
                principalTable: "Sols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
