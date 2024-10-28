using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceFieldsFromGroupToProgramEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_EducationForms_EducationFormId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StatusRequest_StatusRequestId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusRequest",
                table: "StatusRequest");

            migrationBuilder.DropColumn(
                name: "IsDOTProgram",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsFullDOTProgram",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsNetworkProgram",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "StatusRequest",
                newName: "StatusRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeEducationId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KindDocumentRiseQualificationId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancingTypeId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationFormId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "IsDOTProgram",
                table: "EducationPrograms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullDOTProgram",
                table: "EducationPrograms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNetworkProgram",
                table: "EducationPrograms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusRequests",
                table: "StatusRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_EducationForms_EducationFormId",
                table: "EducationPrograms",
                column: "EducationFormId",
                principalTable: "EducationForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms",
                column: "FinancingTypeId",
                principalTable: "FinancingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms",
                column: "KindDocumentRiseQualificationId",
                principalTable: "KindDocumentRiseQualifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StatusRequests_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId",
                principalTable: "StatusRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students",
                column: "TypeEducationId",
                principalTable: "TypeEducation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_EducationForms_EducationFormId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StatusRequests_StatusRequestId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusRequests",
                table: "StatusRequests");

            migrationBuilder.DropColumn(
                name: "IsDOTProgram",
                table: "EducationPrograms");

            migrationBuilder.DropColumn(
                name: "IsFullDOTProgram",
                table: "EducationPrograms");

            migrationBuilder.DropColumn(
                name: "IsNetworkProgram",
                table: "EducationPrograms");

            migrationBuilder.RenameTable(
                name: "StatusRequests",
                newName: "StatusRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeEducationId",
                table: "Students",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "IsDOTProgram",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullDOTProgram",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNetworkProgram",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "KindDocumentRiseQualificationId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancingTypeId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationFormId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusRequest",
                table: "StatusRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_EducationForms_EducationFormId",
                table: "EducationPrograms",
                column: "EducationFormId",
                principalTable: "EducationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms",
                column: "FinancingTypeId",
                principalTable: "FinancingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms",
                column: "KindDocumentRiseQualificationId",
                principalTable: "KindDocumentRiseQualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StatusRequest_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId",
                principalTable: "StatusRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students",
                column: "TypeEducationId",
                principalTable: "TypeEducation",
                principalColumn: "Id");
        }
    }
}
