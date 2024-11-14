using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер истории студента.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentHistoryController : GenericAPiController<StudentHistory>
{
  #region Поля и свойства

  private readonly IStudentHistoryRepository _studentHistoryRepository;

  #endregion

  #region Методы

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="studentHistoryRepository"></param>
  /// <param name="logger"></param>
  public StudentHistoryController(IStudentHistoryRepository studentHistoryRepository, ILogger<StudentHistory> logger) : base(studentHistoryRepository, logger)
  {
    this._studentHistoryRepository = studentHistoryRepository;
  }

  #endregion
}

