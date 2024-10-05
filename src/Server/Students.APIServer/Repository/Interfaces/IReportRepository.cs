namespace Students.APIServer.Repository.Interfaces
{
    /// <summary>
    /// Репозиторий отчетов.
    /// </summary>
    public interface IReportRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Полуичть список сущностей.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        public Task<List<TEntity>> Get();
    }
}
