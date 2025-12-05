using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий истории студента.
/// </summary>
public class StudentHistoryRepository : GenericRepository<StudentHistory>, IStudentHistoryRepository
{
  #region Поля и свойства

  #endregion

  #region IStudentHistoryRepository

  /// <summary>
  /// Сравнить студентов по ключевым полям и при наличии различий добавить их в историю.
  /// </summary>
  /// <param name="oldStudent">Старый студент.</param>
  /// <param name="newStudent">Новый студент.</param>
  /// <returns>История изменений студента.</returns>
  public async Task<StudentHistory?> CreateStudentHistory(Student oldStudent, Student newStudent)
  {
    if(oldStudent.Surname == newStudent.Surname && oldStudent.Name == newStudent.Name)
      return null;

    var studentHistory = new StudentHistory
    {
      StudentId = oldStudent.Id,
      Family = oldStudent.Surname != newStudent.Surname ? oldStudent.Surname : null,
      Name = oldStudent.Name != newStudent.Name ? oldStudent.Name : null,
      ChangeDate = DateTime.Now,
    };

    return await this.Create(studentHistory);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context"></param>
  public StudentHistoryRepository(StudentContext context) :
    base(context)
  {
  }

  #endregion
}

