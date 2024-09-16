using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.DBCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateRes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FEAPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    SourceName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancingTypes", x => x.Id);
                });

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
                name: "ScopesOfActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameOfScope = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScopesOfActivity", x => x.Id);
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
                name: "TypeEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEducation", x => x.Id);
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
                name: "EducationPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    HoursCount = table.Column<int>(type: "integer", nullable: false),
                    EducationFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    KindDocumentRiseQualificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsModularProgram = table.Column<bool>(type: "boolean", nullable: false),
                    FEAProgramId = table.Column<Guid>(type: "uuid", nullable: true),
                    FinancingTypeId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_EducationPrograms_FEAPrograms_FEAProgramId",
                        column: x => x.FEAProgramId,
                        principalTable: "FEAPrograms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationPrograms_FinancingTypes_FinancingTypeId",
                        column: x => x.FinancingTypeId,
                        principalTable: "FinancingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationPrograms_KindDocumentRiseQualification_KindDocumen~",
                        column: x => x.KindDocumentRiseQualificationId,
                        principalTable: "KindDocumentRiseQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Family = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Patron = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    SNILS = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Projects = table.Column<string>(type: "text", nullable: true),
                    IT_Experience = table.Column<string>(type: "text", nullable: false),
                    Disability = table.Column<bool>(type: "boolean", nullable: true),
                    TypeEducationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true),
                    FullNameDocument = table.Column<string>(type: "text", nullable: true),
                    DocumentSeries = table.Column<string>(type: "text", nullable: true),
                    DocumentNumber = table.Column<string>(type: "text", nullable: true),
                    DateTakeDiplom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScopeOfActivityLevelOneId = table.Column<Guid>(type: "uuid", nullable: true),
                    ScopeOfActivityLevelTwoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelOneId",
                        column: x => x.ScopeOfActivityLevelOneId,
                        principalTable: "ScopesOfActivity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_ScopesOfActivity_ScopeOfActivityLevelTwoId",
                        column: x => x.ScopeOfActivityLevelTwoId,
                        principalTable: "ScopesOfActivity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_TypeEducation_TypeEducationId",
                        column: x => x.TypeEducationId,
                        principalTable: "TypeEducation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EducationProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsNetworkProgram = table.Column<bool>(type: "boolean", nullable: false),
                    IsDOTProgram = table.Column<bool>(type: "boolean", nullable: false),
                    IsFullDOTProgram = table.Column<bool>(type: "boolean", nullable: false)
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
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    EducationProgramId = table.Column<Guid>(type: "uuid", nullable: true),
                    DocumentRiseQualificationId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataNumberDogovor = table.Column<string>(type: "text", nullable: true),
                    StatusRequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentStatusId = table.Column<Guid>(type: "uuid", nullable: true),
                    StatusEntrancExams = table.Column<int>(type: "integer", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_DocumentRiseQualification_DocumentRiseQualificatio~",
                        column: x => x.DocumentRiseQualificationId,
                        principalTable: "DocumentRiseQualification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_EducationPrograms_EducationProgramId",
                        column: x => x.EducationProgramId,
                        principalTable: "EducationPrograms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_StatusRequest_StatusRequestId",
                        column: x => x.StatusRequestId,
                        principalTable: "StatusRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_StudentStatuses_StudentStatusId",
                        column: x => x.StudentStatusId,
                        principalTable: "StudentStatuses",
                        principalColumn: "Id");
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
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.StudentsId, x.GroupsId });
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
                name: "IX_DocumentRiseQualification_KindDocumentRiseQualificationId",
                table: "DocumentRiseQualification",
                column: "KindDocumentRiseQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_EducationFormId",
                table: "EducationPrograms",
                column: "EducationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_FEAProgramId",
                table: "EducationPrograms",
                column: "FEAProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_FinancingTypeId",
                table: "EducationPrograms",
                column: "FinancingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPrograms_KindDocumentRiseQualificationId",
                table: "EducationPrograms",
                column: "KindDocumentRiseQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EducationProgramId",
                table: "Groups",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_GroupsId",
                table: "GroupStudent",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_KindOrderId",
                table: "Order",
                column: "KindOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RequestId",
                table: "Order",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DocumentRiseQualificationId",
                table: "Requests",
                column: "DocumentRiseQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EducationProgramId",
                table: "Requests",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentStatusId",
                table: "Requests",
                column: "StudentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScopeOfActivityLevelOneId",
                table: "Students",
                column: "ScopeOfActivityLevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScopeOfActivityLevelTwoId",
                table: "Students",
                column: "ScopeOfActivityLevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TypeEducationId",
                table: "Students",
                column: "TypeEducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "KindOrder");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "DocumentRiseQualification");

            migrationBuilder.DropTable(
                name: "EducationPrograms");

            migrationBuilder.DropTable(
                name: "StatusRequest");

            migrationBuilder.DropTable(
                name: "StudentStatuses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "EducationForms");

            migrationBuilder.DropTable(
                name: "FEAPrograms");

            migrationBuilder.DropTable(
                name: "FinancingTypes");

            migrationBuilder.DropTable(
                name: "KindDocumentRiseQualification");

            migrationBuilder.DropTable(
                name: "ScopesOfActivity");

            migrationBuilder.DropTable(
                name: "TypeEducation");
        }
    }
}
