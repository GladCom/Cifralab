using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationForms", x => x.Id);
                });

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
                name: "FEAPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEAPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScopesOfActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameOfScope = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScopesOfActivity", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "StudentEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SNILS = table.Column<string>(type: "text", nullable: false),
                    FullNameDocument = table.Column<string>(type: "text", nullable: true),
                    DocumentSeries = table.Column<string>(type: "text", nullable: false),
                    DocumentNumber = table.Column<string>(type: "text", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HoursCount = table.Column<int>(type: "integer", nullable: false),
                    EducationTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsNetworkProgram = table.Column<bool>(type: "boolean", nullable: false),
                    IsDOTProgram = table.Column<bool>(type: "boolean", nullable: false),
                    IsModularProgram = table.Column<bool>(type: "boolean", nullable: false),
                    FEAProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCollegeProgram = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationPrograms_EducationForms_EducationFormId",
                        column: x => x.EducationFormId,
                        principalTable: "EducationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationPrograms_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                        column: x => x.FEAProgramId,
                        principalTable: "FEAPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EducationProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_EducationPrograms_EducationProgramId",
                        column: x => x.EducationProgramId,
                        principalTable: "EducationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EducationProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntranceExamination = table.Column<string>(type: "text", nullable: false),
                    Interview = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentEducationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    FinancingTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderOfAdmission = table.Column<string>(type: "text", nullable: false),
                    OrderOfExpulsion = table.Column<string>(type: "text", nullable: true),
                    ScopeOfActivityLv1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScopeOfActivityLv2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Disability = table.Column<bool>(type: "boolean", nullable: false),
                    JobResult = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<string>(type: "text", nullable: false),
                    JobCV = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    EducationContract = table.Column<string>(type: "text", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_EducationPrograms_EducationProgramId",
                        column: x => x.EducationProgramId,
                        principalTable: "EducationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_FinancingTypes_FinancingTypeId",
                        column: x => x.FinancingTypeId,
                        principalTable: "FinancingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv1Id",
                        column: x => x.ScopeOfActivityLv1Id,
                        principalTable: "ScopesOfActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_ScopesOfActivity_ScopeOfActivityLv2Id",
                        column: x => x.ScopeOfActivityLv2Id,
                        principalTable: "ScopesOfActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_StudentDocuments_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "StudentDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_StudentEducations_StudentEducationId",
                        column: x => x.StudentEducationId,
                        principalTable: "StudentEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_StudentStatuses_StudentStatusId",
                        column: x => x.StudentStatusId,
                        principalTable: "StudentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.GroupsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_EducationFormId",
                table: "EducationPrograms",
                column: "EducationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_EducationTypeId",
                table: "EducationPrograms",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_FEAProgramId",
                table: "EducationPrograms",
                column: "FEAProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EducationProgramId",
                table: "Groups",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DocumentTypeId",
                table: "Requests",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EducationProgramId",
                table: "Requests",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FinancingTypeId",
                table: "Requests",
                column: "FinancingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ScopeOfActivityLv1Id",
                table: "Requests",
                column: "ScopeOfActivityLv1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ScopeOfActivityLv2Id",
                table: "Requests",
                column: "ScopeOfActivityLv2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentEducationId",
                table: "Requests",
                column: "StudentEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentStatusId",
                table: "Requests",
                column: "StudentStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "FinancingTypes");

            migrationBuilder.DropTable(
                name: "ScopesOfActivity");

            migrationBuilder.DropTable(
                name: "StudentDocuments");

            migrationBuilder.DropTable(
                name: "StudentEducations");

            migrationBuilder.DropTable(
                name: "StudentStatuses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "EducationPrograms");

            migrationBuilder.DropTable(
                name: "EducationForms");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "FEAPrograms");
        }
    }
}
