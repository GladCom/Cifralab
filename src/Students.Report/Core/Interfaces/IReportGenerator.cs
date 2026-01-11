using ClosedXML.Excel;
using Students.Models.Filters.Filters;

namespace Students.Reports.Core.Interfaces
{
  public interface IReportGenerator
  {
    /// <summary>
    ///   Генерация отчета.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>Книга.</returns>
    Task<XLWorkbook?> ReportForExcelAsync(GroupFilter filter);
  }
}
