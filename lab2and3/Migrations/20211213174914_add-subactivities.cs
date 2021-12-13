using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab2and3.Migrations
{
    public partial class addsubactivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ActivityId1",
                table: "Activities",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityId1",
                table: "Activities",
                column: "ActivityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_ActivityId1",
                table: "Activities",
                column: "ActivityId1",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "Activities");
        }
    }
}
