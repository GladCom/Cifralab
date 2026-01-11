using Students.DBCore.Contexts;
using Students.Models;
using Students.Reports.Core.Services.Constants;
using Students.Reports.Models;
using Students.Reports.Repositories.Abstracts;

namespace Students.Reports.Repositories;

/// <summary>
///   Репозиторий сводного отчета продолжающих обучение.
/// </summary>
public class CurrentlyStudyingReportRepository : BaseSummaryReportRepository<CurrentlyStudyingSummaryModel>
{
  /// <summary>
  ///   Инициализация свойств объекта.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Сущность.</returns>
  protected override CurrentlyStudyingSummaryModel InitializeObject(Group group)
  {
    var groupStudent = group.GroupStudent;
    var studentCounter = groupStudent.Count(gs =>
      RequestStatus(gs, SummaryConstants.Training) ||
      RequestStatus(gs, SummaryConstants.Expelled));
    var studentEducationCounter = groupStudent.Count(gs => RequestStatus(gs, SummaryConstants.Training));

    return new CurrentlyStudyingSummaryModel
    {
      NameProgram = group.EducationProgram!.Name,
      HoursCount = group.EducationProgram.HoursCount.ToString(),
      Group = group.Name,
      StartDate = group.StartDate.ToString(),
      EndDate = group.EndDate.ToString(),
      NumbersOfStudents = studentCounter,
      GraduatesEverything = studentEducationCounter,
      Dropout = studentCounter != 0 ? studentCounter / studentEducationCounter * 100 : 0
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
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public CurrentlyStudyingReportRepository(StudentContext context) : base(context) { }
}