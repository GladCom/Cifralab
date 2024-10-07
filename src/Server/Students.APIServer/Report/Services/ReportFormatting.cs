using ClosedXML.Excel;

namespace Students.APIServer.Report.Services
{
    /// <summary>
    /// Форматирование отчета.
    /// </summary>
    public class ReportFormatting
    {
        private readonly IXLWorksheet _xLWorksheet;

        /// <summary>
        /// Форматирование.
        /// </summary>
        /// <returns>Лист.</returns>
        public IXLWorksheet Formatting()
        {
            _xLWorksheet.Columns().AdjustToContents();

            return _xLWorksheet;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="xLWorksheet">Лист.</param>
        public ReportFormatting(IXLWorksheet xLWorksheet)
        {
            _xLWorksheet = xLWorksheet;
        }
    }
}
