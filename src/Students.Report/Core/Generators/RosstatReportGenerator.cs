using ClosedXML.Excel;
using ClosedXML.Report;
using Students.Models.Filters.Filters;
using Students.Reports.Core.Interfaces;
using Students.Reports.Models;
using Students.Reports.Models.RosstatModelParts;
using Students.Reports.Repositories;

namespace Students.Reports.Core.Generators;

/// <summary>
///   Генератор отчета для Росстата.
/// </summary>
public class RosstatReportGenerator : BaseReportGenerator, IRosstatReportGenerator
{
  private readonly RosstatReportRepository _reportRepository;

  /// <summary>
  ///   Генерировать отчет для Росстата.
  /// </summary>
  /// <returns>Книга.</returns>
  public async Task<XLWorkbook?> ReportForExcelAsync(GroupFilter filter)
  {
    var listReportData = await this._reportRepository.Get(filter);
    var template = new XLTemplate(this.PathTemplate("Form1-PK.xlsx"));
    var rosstatModel = listReportData.FirstOrDefault();
    Type typeOfRosstatModel = typeof(RosstatModel);
    var properties = typeOfRosstatModel.GetProperties();
    foreach (var property in properties)
    {
      if (property.PropertyType == typeof(StudentsInfoRosstatModel<StudentProgramStats>))
      {
        var studentProgramStats = property.GetValue(rosstatModel) as StudentsInfoRosstatModel<StudentProgramStats>;
        foreach (var variable in studentProgramStats.Categories)
        {
          Type typeOfVariable = variable.GetType();
          var variableProperties = typeOfVariable.GetProperties();
          foreach (var variableProperty in variableProperties)
          {
            if (variableProperty.PropertyType == typeof(int))
            {
              var key = $"{variable.NameOfScope}_{variableProperty.Name}".Replace(" ", "_");
              Console.WriteLine(key);
              template.AddVariable(key, variableProperty.GetValue(variable));
            }
          }
        }
      }
    }
    template.Generate();
    return template.Workbook as XLWorkbook;
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="reportRepository">Репозиторий.</param>
  public RosstatReportGenerator(RosstatReportRepository reportRepository)
  {
    this._reportRepository = reportRepository;
  }
}