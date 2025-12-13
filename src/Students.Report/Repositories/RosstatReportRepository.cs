using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.Filters.Filters;
using Students.Reports.Models;
using Students.Reports.Models.RosstatModelParts;
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
    var models = await FetchModel(filter.GetFilterPredicate());
    Console.Write("s");
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
    this.CalculateEducationProgramInfo(rosstatModel);
    this.CalculateStudentsInfo(rosstatModel);
    

    return rosstatModel;
  }

  /// <summary>
  /// Задать список групп, которые будут участвовать в расчете отчета.
  /// </summary>
  /// <param name="condition">Условие, по которому отбираются группы.</param>
  /// <returns>Список групп.</returns>
  private List<Group> SetReportGroups(Predicate<Group> condition)
  {
    var allGroups = this.Context.Groups
      .Include(group => group.EducationProgram)
      .ThenInclude(ep => ep.KindEducationProgram)
      .Include(group => group.Students)
      .ToList();
    
    return allGroups
      .Where(group => condition(group))
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
  /// <param name="groupCondition">Условие для групп.</param>
  /// <param name="studentCondition">Условие для студентов.</param>
  /// <returns>Количество студентов.</returns>
  private int GetStudentsInGroups(Func<Group, bool> groupCondition, Func<Student, bool>? studentCondition = null)
  {
    return this.ReportGroups
      .Where(groupCondition)
      .SelectMany(p => p.Students)
      .Count(s => studentCondition == null || studentCondition(s)); 
  }

  /// <summary>
  /// Флаг, что группа обучалась по программе повышения квалификации.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Является ли группой повышения квалификации.</returns>
  private bool IsAdvanced(Group group)
  {
    return group.EducationProgram?.KindEducationProgram?.Name == "Программа повышения квалификации";
  }

  /// <summary>
  /// Флаг, что группа обучалась по программе переподготовки.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Является ли группой переподготовки.</returns>
  private bool IsRetraining(Group group)
  {
    return group.EducationProgram?.KindEducationProgram?.Name == "Программа профессиональной переподготовки";
  }

  /// <summary>
  /// Флаг, что группа сетевая.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Является ли сетевой.</returns>
  private bool IsNetwork(Group group)
  {
    return group.EducationProgram?.IsNetworkProgram == true;
  }

  /// <summary>
  /// Флаг, что группа является модульной.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Является ли группа модульной.</returns>
  private bool IsModular(Group group)
  {
    return group.EducationProgram?.IsModularProgram == true;
  }

  private bool IsWoman(Student student)
  {
    return student.Sex == SexHuman.Woman;
  }
  
  /// <summary>
  /// Расчет сведений об образовательных прогрммах. 
  /// </summary>
  /// <param name="rosstatModel">Модель в которую будут записываться данные.</param>
  private void CalculateEducationProgramInfo(RosstatModel rosstatModel)
  {
    rosstatModel.EducationInfo.AdvancedTrainingProgramsCount = this.GetGroupsCount(this.IsAdvanced);
    rosstatModel.EducationInfo.ProfessionalRetrainingProgramsCount = this.GetGroupsCount(this.IsRetraining);
    
    rosstatModel.EducationInfo.AdvancedTrainingProgramStudentsCount = this.GetStudentsInGroups(this.IsAdvanced);
    rosstatModel.EducationInfo.ProfessionalRetrainingProgramStudentsCount = this.GetStudentsInGroups(this.IsRetraining);

    rosstatModel.EducationInfo.AdvancedTrainingProgramsNetworkCount =
      this.GetGroupsCount(g => this.IsAdvanced(g) && this.IsNetwork(g));
    rosstatModel.EducationInfo.ProfessionalRetrainingProgramNetworkCount =
      this.GetGroupsCount(g => this.IsRetraining(g) && this.IsNetwork(g));
    
    rosstatModel.EducationInfo.AdvancedTrainingProgramsNetworkStudentsCount =
      this.GetStudentsInGroups(g => this.IsAdvanced(g) && this.IsNetwork(g));
    rosstatModel.EducationInfo.ProfessionalRetrainingProgramNetworkStudentsCount =
      this.GetStudentsInGroups(g => this.IsRetraining(g) && this.IsNetwork(g));
  }

  /// <summary>
  /// Рассчитать данные студентов по модели.
  /// </summary>
  /// <param name="rosstatModel">Модель в которую будут записываться данные.</param>
  private void CalculateStudentsInfo(RosstatModel rosstatModel)
  {
    Type typeOfRosstatModel = rosstatModel.StudentsInfo.GetType();
    PropertyInfo[] studentTypes = typeOfRosstatModel.GetProperties();

    foreach (var studentType in studentTypes)
    {
      if (studentType.PropertyType == typeof(StudentProgramStats))
      {
        var studentTypeInfo = studentType.GetValue(rosstatModel.StudentsInfo) as StudentProgramStats;
        studentTypeInfo.Advanced = this.GetStudentsInGroups(this.IsAdvanced, studentTypeInfo.studentCondition);
        studentTypeInfo.Retraining = this.GetStudentsInGroups(this.IsRetraining, studentTypeInfo.studentCondition);
        studentTypeInfo.AdvancedModular =
          this.GetStudentsInGroups(g => this.IsAdvanced(g) && this.IsModular(g), studentTypeInfo.studentCondition);
        studentTypeInfo.RetrainingModular =
          this.GetStudentsInGroups(g => this.IsRetraining(g) && this.IsModular(g), studentTypeInfo.studentCondition);
        studentTypeInfo.Woman =
          this.GetStudentsInGroups(g => true, s => this.IsWoman(s) && studentTypeInfo.studentCondition(s));

      }
    }
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public RosstatReportRepository(StudentContext context) : base(context) { }
}