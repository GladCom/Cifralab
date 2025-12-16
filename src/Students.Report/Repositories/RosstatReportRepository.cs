using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.Filters.Filters;
using Students.Models.ReferenceModels;
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
    return await this.FetchData(filter.GetFilterPredicate());
  }

  /// <summary>
  /// Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<RosstatModel>> FetchData(Predicate<Group> condition)
  {
    var dataList = new List<RosstatModel>();
    dataList.Add(await this.FetchModel(condition));
    return dataList;
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
    this.CalculateFundingSourcesInfo(rosstatModel);

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
      .Include(group => group.EducationProgram)
        .ThenInclude(ep => ep.FinancingType)
      .Include(group => group.Students)
      .AsSplitQuery()
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
    rosstatModel.EducationProgrammInfo = new StudentsInfoRosstatModel<EducationProgrammInfoRosstatModel>();
    List <EducationProgram> educationPrograms = this.Context.EducationPrograms.ToList();
    rosstatModel.EducationProgrammInfo.AddEducationalProgramCategory(educationPrograms);

    foreach (var category in rosstatModel.EducationProgrammInfo.Categories)
    {
      category.ProgramsCount = this.GetGroupsCount(category.EducationProgramCondition);
      category.StudentsCount = this.GetStudentsInGroups(category.EducationProgramCondition);
      category.ProgramsNetworkCount =
        this.GetGroupsCount(g => this.IsNetwork(g) && category.EducationProgramCondition(g));
      category.ProgramsNetworkStudentsCount =
        this.GetStudentsInGroups(g => this.IsNetwork(g) && category.EducationProgramCondition(g));
    }
  }

  /// <summary>
  /// Рассчитать данные студентов по модели.
  /// </summary>
  /// <param name="rosstatModel">Модель в которую будут записываться данные.</param>
  private void CalculateStudentsInfo(RosstatModel rosstatModel)
  {
    List<ScopeOfActivity> scopeOfActivities = this.Context.ScopesOfActivity.ToList();
    rosstatModel.StudentsInfo = new StudentsInfoRosstatModel<PartialProgramStats>();
    rosstatModel.StudentsInfo.AddScopeOfActivityCategory(scopeOfActivities);
    foreach (var category in rosstatModel.StudentsInfo.Categories)
    {
      category.Advanced = this.GetStudentsInGroups(this.IsAdvanced, category.ScopeOfActivityCondition);
      category.Retraining = this.GetStudentsInGroups(this.IsRetraining, category.ScopeOfActivityCondition);
      category.AdvancedModular =
        this.GetStudentsInGroups(g => this.IsAdvanced(g) && this.IsModular(g), category.ScopeOfActivityCondition);
      category.RetrainingModular =
        this.GetStudentsInGroups(g => this.IsRetraining(g) && this.IsModular(g), category.ScopeOfActivityCondition);
      category.Woman =
        this.GetStudentsInGroups(g => true, s => this.IsWoman(s) && category.ScopeOfActivityCondition(s));
    }
  }

  /// <summary>
  /// Расчет по источникам финансирования.
  /// </summary>
  /// <param name="rosstatModel"></param>
  private void CalculateFundingSourcesInfo(RosstatModel rosstatModel)
  {
    List<ScopeOfActivity> scopeOfActivities = this.Context.ScopesOfActivity.ToList();
    rosstatModel.FundingSourcesInfo = new StudentsInfoRosstatModel<FundingSources>();
    rosstatModel.FundingSourcesInfo.AddScopeOfActivityCategory(scopeOfActivities);
    
    bool IsFederalBudget(Group group) => group.EducationProgram.FinancingType.SourceName ==
                                         "За счет бюджетных ассигнований федерального бюджета";
    
    bool IsRegionalBudget(Group group)=> group.EducationProgram.FinancingType.SourceName ==
                                         "За счет бюджетных ассигнований бюджетов субъектов РФ";
    
    bool IsLocalBudget(Group group)=> group.EducationProgram.FinancingType.SourceName ==
                                         "За счет бюджетных ассигнований местных бюджетов";
    
    bool IsIndividualBudget(Group group)=> group.EducationProgram.FinancingType.SourceName ==
                                      "По договорам за счет средств физических лиц";
    
    bool IsCompanyBudget(Group group)=> group.EducationProgram.FinancingType.SourceName ==
                                           "По договорам за счет средств юридических лиц";
    
    bool IsSelfBudget(Group group)=> group.EducationProgram.FinancingType.SourceName ==
                                        "За счет собственных средств организации";
    
    foreach (var category in rosstatModel.FundingSourcesInfo.Categories)
    {
      category.FederalBudgetAdvanced = this.GetStudentsInGroups(g => this.IsAdvanced(g) && IsFederalBudget(g), category.ScopeOfActivityCondition);
      category.RegionalBudgetAdvanced = this.GetStudentsInGroups(g =>  this.IsAdvanced(g) && IsRegionalBudget(g), category.ScopeOfActivityCondition);
      category.LocalBudgetAdvanced = this.GetStudentsInGroups(g  => this.IsAdvanced(g) && IsLocalBudget(g), category.ScopeOfActivityCondition);
      category.IndividualBudgetAdvanced = this.GetStudentsInGroups(g => this.IsAdvanced(g) && IsIndividualBudget(g), category.ScopeOfActivityCondition);
      category.CompanyBudgetAdvanced = this.GetStudentsInGroups(g => this.IsAdvanced(g) && IsCompanyBudget(g), category.ScopeOfActivityCondition);
      category.SelfBudgetAdvanced = this.GetStudentsInGroups(g =>  this.IsAdvanced(g) && IsSelfBudget(g), category.ScopeOfActivityCondition);
      
      category.FederalBudgetRetraining = this.GetStudentsInGroups(g => this.IsRetraining(g) && IsFederalBudget(g), category.ScopeOfActivityCondition);
      category.RegionalBudgetAdvanced = this.GetStudentsInGroups(g => this.IsRetraining(g) && IsRegionalBudget(g), category.ScopeOfActivityCondition);
      category.LocalBudgetAdvanced = this.GetStudentsInGroups(g  => this.IsRetraining(g) && IsLocalBudget(g), category.ScopeOfActivityCondition);
      category.IndividualBudgetAdvanced = this.GetStudentsInGroups(g => this.IsRetraining(g) && IsIndividualBudget(g), category.ScopeOfActivityCondition);
      category.CompanyBudgetAdvanced = this.GetStudentsInGroups(g => this.IsRetraining(g) && IsCompanyBudget(g), category.ScopeOfActivityCondition);
      category.SelfBudgetAdvanced = this.GetStudentsInGroups(g =>  this.IsRetraining(g) && IsSelfBudget(g), category.ScopeOfActivityCondition);
    }
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public RosstatReportRepository(StudentContext context) : base(context) { }
}