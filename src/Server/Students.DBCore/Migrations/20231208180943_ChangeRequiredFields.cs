using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRequiredFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_FinancingTypes_FinancingTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv1Id",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv2Id",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentDocuments_DocumentTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentEducations_StudentEducationId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentStatuses_StudentStatusId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentStatusId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentEducationId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLv2Id",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLv1Id",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "OrderOfAdmission",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "JobResult",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Interview",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancingTypeId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "EntranceExamination",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "EducationContract",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentTypeId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<bool>(
                name: "Disability",
                table: "Requests",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_FinancingTypes_FinancingTypeId",
                table: "Requests",
                column: "FinancingTypeId",
                principalTable: "FinancingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv1Id",
                table: "Requests",
                column: "ScopeOfActivityLv1Id",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv2Id",
                table: "Requests",
                column: "ScopeOfActivityLv2Id",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentDocuments_DocumentTypeId",
                table: "Requests",
                column: "DocumentTypeId",
                principalTable: "StudentDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentEducations_StudentEducationId",
                table: "Requests",
                column: "StudentEducationId",
                principalTable: "StudentEducations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentStatuses_StudentStatusId",
                table: "Requests",
                column: "StudentStatusId",
                principalTable: "StudentStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_FinancingTypes_FinancingTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv1Id",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv2Id",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentDocuments_DocumentTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentEducations_StudentEducationId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StudentStatuses_StudentStatusId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentStatusId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentEducationId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLv2Id",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ScopeOfActivityLv1Id",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderOfAdmission",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobResult",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Interview",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancingTypeId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntranceExamination",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationContract",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentTypeId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Disability",
                table: "Requests",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_FinancingTypes_FinancingTypeId",
                table: "Requests",
                column: "FinancingTypeId",
                principalTable: "FinancingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv1Id",
                table: "Requests",
                column: "ScopeOfActivityLv1Id",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv2Id",
                table: "Requests",
                column: "ScopeOfActivityLv2Id",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentDocuments_DocumentTypeId",
                table: "Requests",
                column: "DocumentTypeId",
                principalTable: "StudentDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentEducations_StudentEducationId",
                table: "Requests",
                column: "StudentEducationId",
                principalTable: "StudentEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StudentStatuses_StudentStatusId",
                table: "Requests",
                column: "StudentStatusId",
                principalTable: "StudentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
