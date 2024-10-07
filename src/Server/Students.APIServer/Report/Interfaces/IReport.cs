using ClosedXML.Report;
using ClosedXML.Excel;

namespace Students.APIServer.Report.Interfaces
{
    /// <summary>
    /// Интерфейс.
    /// </summary>
    public interface IReport<T>
    {
        /// <summary>
        /// Генерирование отчета для Росстата.
        /// </summary>
        /// <returns>Книга.</returns>
        public Task<T?> GenerateRosstatReport();

        /// <summary>
        /// Генерирование отчета ПФДО.
        /// </summary>
        /// <returns>Книга.</returns>
        public Task<T?> GeneratePFDOReport();
    }
}
