using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий программ обучения.
/// </summary>
public class EducationProgramRepository : GenericRepository<EducationProgram>, IEducationProgramRepository
{
  #region Поля и свойства

  #endregion

  #region IEducationProgramRepository

  #endregion

  #region Базовый класс

  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="filter">Фильтр по которому происходит отбор.</param>
  /// <returns>Список сущностей.</returns>
  public override Task<IEnumerable<EducationProgram>> GetFiltered(Filter<EducationProgram> filter)
  {
    return this.Get(filter.GetFilterPredicate(), this.DbSet.Include(x => x.Requests));
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public EducationProgramRepository(StudentContext context) : base(context)
  {
  }

  #endregion
}