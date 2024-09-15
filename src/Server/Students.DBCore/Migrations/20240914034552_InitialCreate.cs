using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_EducationTypes_EducationTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_EducationPrograms_EducationProgramId",
                table: "Requests");

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
                name: "FK_Requests_TypeEducation_StudentEducationId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "StudentDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DocumentTypeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_FinancingTypeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ScopeOfActivityLv1Id",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeEducation",
                table: "TypeEducation");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Disability",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EducationContract",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EntranceExamination",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FinancingTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Interview",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "JobCV",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "JobResult",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ScopeOfActivityLv1Id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsDOTProgram",
                table: "EducationPrograms");

            migrationBuilder.DropColumn(
                name: "IsNetworkProgram",
                table: "EducationPrograms");

            migrationBuilder.RenameTable(
                name: "TypeEducation",
                newName: "StudentEducations");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Students",
                newName: "IT_Experience");

            migrationBuilder.RenameColumn(
                name: "StudentEducationId",
                table: "Requests",
                newName: "StatusRequestId");

            migrationBuilder.RenameColumn(
                name: "ScopeOfActivityLv2Id",
                table: "Requests",
                newName: "DocumentRiseQualificationId");

            migrationBuilder.RenameColumn(
                name: "OrderOfExpulsion",
                table: "Requests",
                newName: "RegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "OrderOfAdmission",
                table: "Requests",
                newName: "DataNumberDogovor");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_StudentEducationId",
                table: "Requests",
                newName: "IX_Requests_StatusRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ScopeOfActivityLv2Id",
                table: "Requests",
                newName: "IX_Requests_DocumentRiseQualificationId");

            migrationBuilder.RenameColumn(
                name: "EducationTypeId",
                table: "EducationPrograms",
                newName: "KindDocumentRiseQualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_EducationPrograms_EducationTypeId",
                table: "EducationPrograms",
                newName: "IX_EducationPrograms_KindDocumentRiseQualificationId");

            migrationBuilder.AlterColumn<string>(
                name: "SNILS",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentSeries",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTakeDiplom",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disability",
                table: "Students",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patron",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Projects",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScopeOfActivityLevelOneId",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScopeOfActivityLevelTwoId",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfScope",
                table: "ScopesOfActivity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationProgramId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "StatusEntrancExams",
                table: "Requests",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.AlterColumn<string>(
                name: "SourceName",
                table: "FinancingTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FEAPrograms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationPrograms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "FEAProgramId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "EducationPrograms",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "FinancingTypeId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationForms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent",
                columns: new[] { "StudentsId", "GroupsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEducations",
                table: "StudentEducations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KindDocumentRiseQualification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindDocumentRiseQualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KindOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRiseQualification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KindDocumentRiseQualificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRiseQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentRiseQualification_KindDocumentRiseQualification_Kin~",
                        column: x => x.KindDocumentRiseQualificationId,
                        principalTable: "KindDocumentRiseQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KindOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_KindOrder_KindOrderId",
                        column: x => x.KindOrderId,
                        principalTable: "KindOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScopeOfActivityLevelOneId",
                table: "Students",
                column: "ScopeOfActivityLevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScopeOfActivityLevelTwoId",
                table: "Students",
                column: "ScopeOfActivityLevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_GroupsId",
                table: "GroupStudent",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_FinancingTypeId",
                table: "EducationPrograms",
                column: "FinancingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRiseQualification_KindDocumentRiseQualificationId",
                table: "DocumentRiseQualification",
                column: "KindDocumentRiseQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_KindOrderId",
                table: "Order",
                column: "KindOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RequestId",
                table: "Order",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                table: "EducationPrograms",
                column: "FEAProgramId",
                principalTable: "FEAPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms",
                column: "FinancingTypeId",
                principalTable: "FinancingTypes",
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
                name: "FK_Requests_DocumentRiseQualification_DocumentRiseQualificatio~",
                table: "Requests",
                column: "DocumentRiseQualificationId",
                principalTable: "DocumentRiseQualification",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_EducationPrograms_EducationProgramId",
                table: "Requests",
                column: "EducationProgramId",
                principalTable: "EducationPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StatusRequest_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId",
                principalTable: "StatusRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students",
                column: "ScopeOfActivityLevelOneId",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelTwoId",
                table: "Students",
                column: "ScopeOfActivityLevelTwoId",
                principalTable: "ScopesOfActivity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationPrograms_KindDocumentRiseQualification_KindDocumen~",
                table: "EducationPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_DocumentRiseQualification_DocumentRiseQualificatio~",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_EducationPrograms_EducationProgramId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StatusRequest_StatusRequestId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelTwoId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DocumentRiseQualification");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "StatusRequest");

            migrationBuilder.DropTable(
                name: "KindDocumentRiseQualification");

            migrationBuilder.DropTable(
                name: "KindOrder");

            migrationBuilder.DropIndex(
                name: "IX_Students_ScopeOfActivityLevelOneId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ScopeOfActivityLevelTwoId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudent_GroupsId",
                table: "GroupStudent");

            migrationBuilder.DropIndex(
                name: "IX_EducationPrograms_FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEducations",
                table: "StudentEducations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateTakeDiplom",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Disability",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Patron",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Projects",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ScopeOfActivityLevelOneId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ScopeOfActivityLevelTwoId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StatusEntrancExams",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsDOTProgram",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsFullDOTProgram",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsNetworkProgram",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "EducationPrograms");

            migrationBuilder.DropColumn(
                name: "FinancingTypeId",
                table: "EducationPrograms");

            migrationBuilder.RenameTable(
                name: "StudentEducations",
                newName: "TypeEducation");

            migrationBuilder.RenameColumn(
                name: "IT_Experience",
                table: "Students",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "StatusRequestId",
                table: "Requests",
                newName: "StudentEducationId");

            migrationBuilder.RenameColumn(
                name: "RegistrationNumber",
                table: "Requests",
                newName: "OrderOfExpulsion");

            migrationBuilder.RenameColumn(
                name: "DocumentRiseQualificationId",
                table: "Requests",
                newName: "ScopeOfActivityLv2Id");

            migrationBuilder.RenameColumn(
                name: "DataNumberDogovor",
                table: "Requests",
                newName: "OrderOfAdmission");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_StatusRequestId",
                table: "Requests",
                newName: "IX_Requests_StudentEducationId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_DocumentRiseQualificationId",
                table: "Requests",
                newName: "IX_Requests_ScopeOfActivityLv2Id");

            migrationBuilder.RenameColumn(
                name: "KindDocumentRiseQualificationId",
                table: "EducationPrograms",
                newName: "EducationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EducationPrograms_KindDocumentRiseQualificationId",
                table: "EducationPrograms",
                newName: "IX_EducationPrograms_EducationTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "SNILS",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentSeries",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfScope",
                table: "ScopesOfActivity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationProgramId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Requests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Requests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Disability",
                table: "Requests",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "Requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationContract",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntranceExamination",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FinancingTypeId",
                table: "Requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Interview",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCV",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobResult",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScopeOfActivityLv1Id",
                table: "Requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SourceName",
                table: "FinancingTypes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FEAPrograms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationPrograms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FEAProgramId",
                table: "EducationPrograms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDOTProgram",
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationForms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent",
                columns: new[] { "GroupsId", "StudentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeEducation",
                table: "TypeEducation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocuments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DocumentTypeId",
                table: "Requests",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FinancingTypeId",
                table: "Requests",
                column: "FinancingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ScopeOfActivityLv1Id",
                table: "Requests",
                column: "ScopeOfActivityLv1Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_EducationTypes_EducationTypeId",
                table: "EducationPrograms",
                column: "EducationTypeId",
                principalTable: "EducationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                table: "EducationPrograms",
                column: "FEAProgramId",
                principalTable: "FEAPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_EducationPrograms_EducationProgramId",
                table: "Requests",
                column: "EducationProgramId",
                principalTable: "EducationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Requests_TypeEducation_StudentEducationId",
                table: "Requests",
                column: "StudentEducationId",
                principalTable: "TypeEducation",
                principalColumn: "Id");
        }
    }
}
