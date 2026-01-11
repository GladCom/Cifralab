using Students.DBCore.Contexts;
using Students.Models;
using Students.Reports.Core.Services.Constants;
using Students.Reports.Models;
using Students.Reports.Repositories.Abstracts;

namespace Students.Reports.Repositories;

/// <summary>
///   Репозиторий сводного отчета закончивших обучение.
/// </summary>
public class FinishingStudiesReportRepository : BaseSummaryReportRepository<FinishingStudiesSummaryModel>
{
  /// <summary>
  ///   Инициализация свойств объекта.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Сущность.</returns>
  protected override FinishingStudiesSummaryModel InitializeObject(Group group)
  {
    var groupStudent = group.GroupStudent;
    var studentCounter = groupStudent.Count(gs =>
      RequestStatus(gs, SummaryConstants.Training) ||
      RequestStatus(gs, SummaryConstants.Expelled));
    var studentEducationCounter = groupStudent.Count(gs => RequestStatus(gs, SummaryConstants.Training));
    var graduatesWithDiploma = groupStudent.Count(gs =>
      DocumentStatus(gs, SummaryConstants.CertificateOfProfessionalDevelopment) ||
      DocumentStatus(gs, SummaryConstants.DiplomaOfProfessionalRetraining));
    var graduatesWithCertificate = groupStudent.Count(gs =>
      DocumentStatus(gs, SummaryConstants.Certificate));

    return new FinishingStudiesSummaryModel
    {
      NameProgram = group.EducationProgram!.Name,
      HoursCount = group.EducationProgram.HoursCount.ToString(),
      Group = group.Name,
      StartDate = group.StartDate.ToString(),
      EndDate = group.EndDate.ToString(),
      NumbersOfStudents = studentCounter,
      GraduatesEverything = studentEducationCounter,
      GraduatesWithDiploma = graduatesWithDiploma,
      GraduatesWithCertificate = graduatesWithCertificate,
      Dropout = studentCounter != 0 && studentCounter != studentEducationCounter
        ? studentCounter / studentEducationCounter * 100 : 0
    };
  }

  /// <summary>
  ///   Проверка статуса заявки.
  /// </summary>
  /// <param name="groupStudent">Сущность.</param>
  /// <param name="status">Статус.</param>
  /// <returns></returns>
  private static bool RequestStatus(GroupStudent groupStudent, string status)
  {
    return groupStudent.Request?.Status?.Name == status;
  }

  /// <summary>
  ///   Проверка статуса документа квалификации.
  /// </summary>
  /// <param name="groupStudent">Сущность.</param>
  /// <param name="status">Статус.</param>
  /// <returns></returns>
  private static bool DocumentStatus(GroupStudent groupStudent, string status)
  {
    return groupStudent.Request?.DocumentRiseQualification?.KindDocumentRiseQualification?.Name == status;
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public FinishingStudiesReportRepository(StudentContext context) : base(context) { }
}