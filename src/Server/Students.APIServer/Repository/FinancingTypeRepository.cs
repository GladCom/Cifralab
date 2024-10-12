using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
  /// <summary>
  /// Репозиторий репозиторий типов финансирования.
  /// </summary>
  public class FinancingTypeRepository : GenericRepository<FinancingType>, IFinancingTypeRepository
  {
    #region Поля и свойства

    private readonly StudentContext _context;

    #endregion

    #region Методы

    /// <summary>
    /// Заполнить БД данными.
    /// </summary>
    public async Task AddSeedData()
    {
      var financingTypes = new List<FinancingType>
      {
        new FinancingType { Id = Guid.NewGuid(), SourceName = "За счет бюджетных ассигнований федерального бюджета" },
        new FinancingType { Id = Guid.NewGuid(), SourceName = "За счет бюджетных ассигнований бюджетов субъектов РФ" },
        new FinancingType { Id = Guid.NewGuid(), SourceName = "За счет бюджетных ассигнований местных бюджетов" },
        new FinancingType { Id = Guid.NewGuid(), SourceName = "По договорам за счет средств физических лиц" },
        new FinancingType { Id = Guid.NewGuid(), SourceName = "По договорам за счет средств юридических лиц " },
        new FinancingType { Id = Guid.NewGuid(), SourceName = "За счет собственных средств организации" }
      };

      await _context.FinancingTypes.AddRangeAsync(financingTypes);
      await _context.SaveChangesAsync();
      
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context"></param>
    public FinancingTypeRepository(StudentContext context) : base(context)
    {
      _context = context;
    }

    #endregion
  }
}
