using Students.Models;

namespace Students.APIServer.Repository.Interfaces
{
  /// <summary>
  /// Интерфейс репозитория типа финансирования.
  /// </summary>
  public interface IFinancingTypeRepository : IGenericRepository<FinancingType>
  {
    /// <summary>
    /// Заполнить БД данными.
    /// </summary>
    Task AddSeedData();
  }
}
