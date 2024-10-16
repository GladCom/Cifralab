using ClosedXML.Excel;
using ClosedXML.Report;
using Students.APIServer.Report.Interfaces;
using Students.APIServer.Report.Services;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using System.Reflection;
using Students.Models.ReportsModel;

namespace Students.APIServer.Report
{
    /// <summary>
    /// Генератор отчетов.
    /// </summary>
    public class GenerateReports : IReport<XLWorkbook>
    {
        private readonly IReportRepository<RosstatModel> _reportRosstatRepository;
        private readonly IReportRepository<FRDOModel> _reportPFDORepository;

        /// <summary>
        /// Генерировать отчет для Росстата.
        /// </summary>
        /// <returns>Книга.</returns>
        public async Task<XLWorkbook?> GenerateRosstatReport()
        {
            var listReportData = await _reportRosstatRepository.Get() ?? throw new ArgumentNullException("Нет данных.");
            var template = new XLTemplate(Directory.GetCurrentDirectory() + @"\Report\Templates\Form1-PK.xlsx");
            template.AddVariable(listReportData.FirstOrDefault());
            template.Generate();

            return template.Workbook as XLWorkbook;
        }

        /// <summary>
        /// Генерировать отчет ФРДО.
        /// </summary>
        /// <returns>Книга.</returns>
        public async Task<XLWorkbook?> GenerateFRDOReport()
        {
            var listReportData = await _reportPFDORepository.Get() ?? throw new ArgumentNullException("Нет данных.");
            var workbook = new XLWorkbook(Directory.GetCurrentDirectory() + @"\Report\Templates\FRDO.xlsx");
            var worksheet = workbook.Worksheet("Шаблон");
            FillingCells(worksheet, listReportData);

            return workbook;
        }

        /// <summary>
        /// Заполнение отчета ПФДО.
        /// </summary>
        /// <param name="xLWorksheet">Лист.</param>
        /// <param name="list">Список сущностей.</param>
        /// <returns>Лист.</returns>
        private IXLWorksheet FillingCells(IXLWorksheet xLWorksheet, List<FRDOModel> list)
        {
            int charCounter = 0;
            int cellCounter = 2;

            foreach (var row in list)
            {
                PropertyInfo[] cells = row.GetType().GetProperties();
                foreach (PropertyInfo cell in cells)
                {
                    var cellValue = cell.GetValue(row) is null ? string.Empty : cell.GetValue(row)!.ToString();
                    xLWorksheet.Cell(ExcelMetadata.ExcelColumnName[charCounter].ToString() + cellCounter).Value = cellValue;
                    charCounter++;
                }
                charCounter = 0;
                cellCounter++;
            }
            return xLWorksheet;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="reportPFDORepository">Репозиторий.</param>
        /// <param name="reportRosstatRepository">Репозиторий.</param>
        public GenerateReports(IReportRepository<FRDOModel> reportPFDORepository, IReportRepository<RosstatModel> reportRosstatRepository)
        {
            _reportRosstatRepository = reportRosstatRepository;
            _reportPFDORepository = reportPFDORepository;
        }
    }
}