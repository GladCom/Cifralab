using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий истории студента.
/// </summary>
public class StudentHistoryRepository : GenericRepository<StudentHistory>, IStudentHistoryRepository
{
  #region Поля и свойства

  private readonly StudentContext _ctx;
  private IStudentRepository _studentRepository;

  #endregion

  #region Методы

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context"></param>
  /// <param name="studRep"></param>
  public StudentHistoryRepository(StudentContext context, IStudentRepository studRep) :
    base(context)
  {
    _ctx = context;
    _studentRepository = studRep;
  }

  #endregion
}

