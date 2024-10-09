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
                name: "FK_EducationPrograms_EducationForms_EducationFormId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeEducationId",
                table: "Students",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students",
                column: "TypeEducationId",
                principalTable: "TypeEducation",
                principalColumn: "Id");
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
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students");

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
                name: "FK_Students_TypeEducation_TypeEducationId",
                table: "Students",
                column: "TypeEducationId",
                principalTable: "TypeEducation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
