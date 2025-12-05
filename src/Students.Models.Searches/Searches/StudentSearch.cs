using Students.Models.ReferenceModels;
using System;
using System.Collections.Generic;

namespace Students.Models.Searches.Searches
{
  /// <summary>
  /// Поиск студентов по фамилии, имени, отчеству и полному ФИО.
  /// </summary>
  /// <remarks>
  /// Данный класс реализует логику текстового поиска студентов по основным полям, связанным с ФИО.
  /// Используется в API для выборки студентов по частичному или полному совпадению текста.
  /// </remarks>
  public class StudentSearch : Search<Student>
  {
    /// <summary>
    /// Конструктор поиска студентов.
    /// Определяет свойства, по которым будет выполняться поиск.
    /// </summary>
    public StudentSearch()
    {
      SearchProperties = new()
      {
        nameof(Student.Surname),
        nameof(Student.Name),
        nameof(Student.Patron),
        nameof(Student.FullName)
      };
    }

    /// <summary>
    /// Возвращает предикат, выполняющий поиск студентов по фамилии, имени, отчеству и полному ФИО.
    /// </summary>
    /// <returns>
    /// Предикат, возвращающий <c>true</c>, если хотя бы одно из полей <see cref="Student.Surname"/>,
    /// <see cref="Student.Name"/>, <see cref="Student.Patron"/> или <see cref="Student.FullName"/>
    /// содержит строку, заданную в свойстве <see cref="Search{TEntity}.Query"/>; 
    /// иначе возвращается <c>false</c>.
    /// </returns>
    public override Predicate<Student> GetSearchPredicate()
    {
      if (string.IsNullOrWhiteSpace(Query))
        return _ => true;

      var lower = Query.Trim().ToLower();

      return s =>
        (s.Surname?.ToLower().Contains(lower) ?? false) ||
        (s.Name?.ToLower().Contains(lower) ?? false) ||
        (s.Patron?.ToLower().Contains(lower) ?? false) ||
        (s.FullName?.ToLower().Contains(lower) ?? false);
    }
  }
}
