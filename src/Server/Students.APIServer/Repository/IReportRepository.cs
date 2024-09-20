namespace Students.APIServer.Repository
{
    /// <summary>
    /// Интерфейс репозитория отчетов
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Список всего
        /// </summary>
        /// <returns>Массив данных</returns>
        Task<byte[]> GetAll();
    }
}
