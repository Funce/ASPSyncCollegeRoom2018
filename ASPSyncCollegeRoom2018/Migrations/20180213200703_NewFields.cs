using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPSyncCollegeRoom2018.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ScheduleData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "ScheduleData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ScheduleData");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "ScheduleData");
        }
    }
}
