using Students.Models;

namespace Students.APIServer.Repository.Interfaces
{
  /// <summary>
  /// Репозиторий ВЭД программ.
  /// </summary>
  public interface IFEAProgramRepository : IGenericRepository<FEAProgram>
  {
    /// <summary>
    /// Заполнить БД первоначальными справочными данными.
    /// </summary>
    Task AddSeedData();
  }
}
