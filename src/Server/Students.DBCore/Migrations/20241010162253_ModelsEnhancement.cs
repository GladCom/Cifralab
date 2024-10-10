using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class ModelsEnhancement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLevelOneId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students",
                column: "ScopeOfActivityLevelOneId",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLevelOneId",
                table: "Students",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students",
                column: "ScopeOfActivityLevelOneId",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id");
        }
    }
}
