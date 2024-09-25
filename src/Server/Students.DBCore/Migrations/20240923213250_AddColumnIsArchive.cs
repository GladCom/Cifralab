using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentRiseQualification_KindDocumentRiseQualification_Kin~",
                table: "DocumentRiseQualification");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualification_KindDocumen~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_KindOrder_KindOrderId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KindOrder",
                table: "KindOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KindDocumentRiseQualification",
                table: "KindDocumentRiseQualification");

            migrationBuilder.RenameTable(
                name: "KindOrder",
                newName: "KindOrders");

            migrationBuilder.RenameTable(
                name: "KindDocumentRiseQualification",
                newName: "KindDocumentRiseQualifications");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "EducationPrograms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KindDocumentRiseQualifications",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KindOrders",
                table: "KindOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KindDocumentRiseQualifications",
                table: "KindDocumentRiseQualifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentRiseQualification_KindDocumentRiseQualifications_Ki~",
                table: "DocumentRiseQualification",
                column: "KindDocumentRiseQualificationId",
                principalTable: "KindDocumentRiseQualifications",
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
                name: "FK_Order_KindOrders_KindOrderId",
                table: "Order",
                column: "KindOrderId",
                principalTable: "KindOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentRiseQualification_KindDocumentRiseQualifications_Ki~",
                table: "DocumentRiseQualification");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualifications_KindDocume~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_KindOrders_KindOrderId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KindOrders",
                table: "KindOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KindDocumentRiseQualifications",
                table: "KindDocumentRiseQualifications");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "EducationPrograms");

            migrationBuilder.RenameTable(
                name: "KindOrders",
                newName: "KindOrder");

            migrationBuilder.RenameTable(
                name: "KindDocumentRiseQualifications",
                newName: "KindDocumentRiseQualification");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KindDocumentRiseQualification",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KindOrder",
                table: "KindOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KindDocumentRiseQualification",
                table: "KindDocumentRiseQualification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentRiseQualification_KindDocumentRiseQualification_Kin~",
                table: "DocumentRiseQualification",
                column: "KindDocumentRiseQualificationId",
                principalTable: "KindDocumentRiseQualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualification_KindDocumen~",
                table: "EducationPrograms",
                column: "KindDocumentRiseQualificationId",
                principalTable: "KindDocumentRiseQualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_KindOrder_KindOrderId",
                table: "Order",
                column: "KindOrderId",
                principalTable: "KindOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
