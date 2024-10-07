using ClosedXML.Excel;
using ClosedXML.Report;
using Students.APIServer.Report.Interfaces;
using Students.APIServer.Report.Services;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using System.Reflection;

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
        /// Генератор отчетов для Росстата.
        /// </summary>
        /// <returns>Книга.</returns>
        public async Task<XLWorkbook?> GenerateRosstatReport()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("reportsettings.json", true, true).Build();

            var listReportData = await _reportRosstatRepository.Get() ?? throw new ArgumentNullException("Нет данных.");
            var template = new XLTemplate(config["ReportTemplate:RosstatReportTemplate"]);
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
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            CreateTitle(worksheet);
            FillingCells(worksheet, listReportData);

            return workbook;
        }

        /// <summary>
        /// Занесение названия колонок.
        /// </summary>
        /// <param name="xLWorksheet">Лист.</param>
        /// <returns>Лист.</returns>
        private IXLWorksheet CreateTitle(IXLWorksheet xLWorksheet)
        {
            int charCounter = 0;
            int cellCounter = 1;

            PropertyInfo[] titles = typeof(FRDOModel).GetProperties() ?? throw new ArgumentNullException("Нет данных.");

            foreach (var title in titles)
            {
                object[] attributes = title.GetCustomAttributes(false);

                if (attributes != null && attributes.Length > 0)
                {
                    if (attributes[0] is ColumnAttribute column)
                    {
                        xLWorksheet.Cell(ExcelMetadata.ExcelColumnName[charCounter].ToString() + cellCounter).Value = column.Name;
                        charCounter++;
                    }
                }
            }
            return xLWorksheet;
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
                PropertyInfo[] cells = row.GetType().GetProperties() ?? throw new ArgumentNullException("Нет данных.");
                foreach (PropertyInfo cell in cells)
                {
                    xLWorksheet.Cell(ExcelMetadata.ExcelColumnName[charCounter].ToString() + cellCounter).Value = cell.GetValue(row)!.ToString();
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