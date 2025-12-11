using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;
using Students.Reports.Models;
using Students.Reports.Repositories.Abstracts;

namespace Students.Reports.Repositories;

/// <summary>
///   Репозиторий отчета Росстат.
/// </summary>
public class RosstatReportRepository : BaseReportRepository<RosstatModel>
{
  /// <summary>
  /// Группы для вычисления отчета.
  /// </summary>
  private List<Group> ReportGroups {get; set;}
  
  /// <summary>
  ///   Формирование данных для отчета.
  /// </summary>
  /// <param name="filter">Фильтр</param>
  /// <returns>Данные.</returns>
  public async Task<List<RosstatModel>> Get(GroupFilter filter)
  {
    return await this.FetchData(filter.GetFilterPredicate());
  }

  /// <summary>
  /// Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<RosstatModel>> FetchData(Predicate<Group> condition)
  {
    throw new NotImplementedException();
  }
  
  /// <summary>
  /// Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected async Task<RosstatModel> FetchModel(Predicate<Group> condition)
  {
    var rosstatModel = new RosstatModel();
    this.ReportGroups = this.SetReportGroups(condition);
    

      
    
    

    return rosstatModel;
  }

  /// <summary>
  /// Задать список групп, которые будут участвовать в расчете отчета.
  /// </summary>
  /// <param name="condition">Условие, по которому отбираются группы.</param>
  /// <returns>Список групп.</returns>
  private List<Group> SetReportGroups(Predicate<Group> condition)
  {
    return this.Context.Groups.Where(g => condition(g))
      .Include(group => group.EducationProgram)
      .ThenInclude(ep => ep.KindEducationProgram)
      .Include(group => group.Students)
      .ToList();
  }

  /// <summary>
  /// Получить количество групп по условию.
  /// </summary>
  /// <param name="condition">Условие.</param>
  /// <returns>Количество групп.</returns>
  private int GetGroupsCount(Func<Group, bool> condition)
  {
    return this.ReportGroups
      .Count(condition);
  }

  /// <summary>
  /// Получить количество студентов в группах.
  /// </summary>
  /// <param name="condition">Условие.</param>
  /// <returns>Количество студентов.</returns>
  private int GetStudentsInGroups(Func<Group, bool> condition)
  {
    return this.ReportGroups
      .Where(condition)
      .SelectMany(p => p.Students)
      .Count(); 
  }

  private void CalculateEducationProgramInfo(RosstatModel rosstatModel)
  {
    bool IsThisTypeProgramm(Group group, string programKindName)
    {
      return group.EducationProgram?.KindEducationProgram?.Name == programKindName;
    }

    rosstatModel.AdvancedTrainingProgramsCount =
      this.GetGroupsCount(g => IsThisTypeProgramm(g, "Программа повышения квалификации"));

    rosstatModel.ProfessionalRetrainingProgramsCount =
      this.GetGroupsCount(g => IsThisTypeProgramm(g, "Программа профессиональной переподготовки"));

    bool IsStudentLearnedOnThisCourse(Group group, string courseName)
    {
      return group.EducationProgram?.KindEducationProgram?.Name == courseName;
    }
    
    rosstatModel.AdvancedTrainingProgramStudentsCount =
      this.GetStudentsInGroups(g => IsStudentLearnedOnThisCourse(g, ""));
    rosstatModel.AdvancedTrainingProgramsNetworkCount =
      this.GetGroupsCount(group => group.EducationProgram?.IsNetworkProgram == true &&
                                   group.EducationProgram?.KindEducationProgram?.Name==
                                   "Программа повышения квалификации");
      
    

    rosstatModel.ProfessionalRetrainingProgramStudentsCount =
      this.GetStudentsInGroups(p => p.EducationProgram?.KindEducationProgram?.Name ==
                                    "Программа профессиональной переподготовки");
    rosstatModel.ProfessionalRetrainingProgramNetworkCount =
      this.GetGroupsCount(group => group.EducationProgram?.IsNetworkProgram == true &&
      group.EducationProgram?.KindEducationProgram?.Name==
      "Программа профессиональной переподготовки");
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public RosstatReportRepository(StudentContext context) : base(context) { }
}