using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProcessor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrumentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageID = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleCategoryID = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    IndexWithinRole = table.Column<int>(type: "INTEGER", nullable: false),
                    InstrumentStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RapidControlStatusId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceStatuses_InstrumentStatuses_InstrumentStatusId",
                        column: x => x.InstrumentStatusId,
                        principalTable: "InstrumentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RapidControlStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CombinedStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceStatusId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapidControlStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RapidControlStatuses_DeviceStatuses_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CombinedStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleState = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    IsBusy = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsReady = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsError = table.Column<bool>(type: "INTEGER", nullable: false),
                    KeyLock = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Vial = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Volume = table.Column<int>(type: "INTEGER", nullable: true),
                    MaximumInjectionVolume = table.Column<int>(type: "INTEGER", nullable: true),
                    RackL = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    RackR = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Buzzer = table.Column<bool>(type: "INTEGER", nullable: true),
                    RackInf = table.Column<int>(type: "INTEGER", nullable: true),
                    Mode = table.Column<string>(type: "TEXT", nullable: true),
                    Flow = table.Column<int>(type: "INTEGER", nullable: true),
                    PercentB = table.Column<decimal>(type: "TEXT", nullable: true),
                    PercentC = table.Column<decimal>(type: "TEXT", nullable: true),
                    PercentD = table.Column<decimal>(type: "TEXT", nullable: true),
                    MinimumPressureLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    Pressure = table.Column<int>(type: "INTEGER", nullable: true),
                    PumpOn = table.Column<bool>(type: "INTEGER", nullable: true),
                    Channel = table.Column<int>(type: "INTEGER", nullable: true),
                    UseTemperatureControl = table.Column<bool>(type: "INTEGER", nullable: true),
                    OvenOn = table.Column<bool>(type: "INTEGER", nullable: true),
                    Temperature_Actual = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Temperature_Room = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    MaximumTemperatureLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    Valve_Position = table.Column<int>(type: "INTEGER", nullable: true),
                    Valve_Rotations = table.Column<int>(type: "INTEGER", nullable: true),
                    CombinedStatusType = table.Column<int>(type: "INTEGER", nullable: false),
                    RapidControlStatusId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinedStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CombinedStatuses_RapidControlStatuses_RapidControlStatusId",
                        column: x => x.RapidControlStatusId,
                        principalTable: "RapidControlStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CombinedStatuses_RapidControlStatusId",
                table: "CombinedStatuses",
                column: "RapidControlStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceStatuses_InstrumentStatusId",
                table: "DeviceStatuses",
                column: "InstrumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RapidControlStatuses_DeviceStatusId",
                table: "RapidControlStatuses",
                column: "DeviceStatusId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CombinedStatuses");

            migrationBuilder.DropTable(
                name: "RapidControlStatuses");

            migrationBuilder.DropTable(
                name: "DeviceStatuses");

            migrationBuilder.DropTable(
                name: "InstrumentStatuses");
        }
    }
}
