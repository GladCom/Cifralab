using Students.Models;
using System;
using System.Collections.Generic;

namespace Students.Models.Searches.Searches
{
  /// <summary>
  /// Поиск заявок по данным студента и реквизитам заявки.
  /// </summary>
  /// <remarks>
  /// Выполняет поиск по ФИО студента, а также по регистрационному номеру,
  /// телефону и электронной почте, указанным в заявке. 
  /// Если объект <see cref="Request.Student"/> не загружен, используется доступ к связанному Id.
  /// </remarks>
  public class RequestSearch : Search<Request>
  {
    /// <summary>
    /// Конструктор поиска заявок.
    /// Определяет свойства, по которым выполняется поиск.
    /// </summary>
    public RequestSearch()
    {
      SearchProperties = new()
      {
        nameof(Request.RegistrationNumber),
        nameof(Request.Email),
        nameof(Request.Phone),
        nameof(Request.Student)
      };
    }

    /// <inheritdoc />
    public override Predicate<Request> GetSearchPredicate()
    {
      if (string.IsNullOrWhiteSpace(Query))
        return _ => true;

      var normalizedQuery = Query.Trim().ToLower();

      return r =>
      {
        if (r.Student != null && 
            ((r.Student.FullName != null && r.Student.FullName.ToLower().Contains(normalizedQuery)) ||
             (r.RegistrationNumber != null && r.RegistrationNumber.ToLower().Contains(normalizedQuery)) ||
             (r.Email != null && r.Email.ToLower().Contains(normalizedQuery)) ||
             (r.Phone != null && r.Phone.ToLower().Contains(normalizedQuery))))
        {
          return true;
        }

        if (r.PhantomStudent != null && 
            ((r.PhantomStudent.FullName != null && r.PhantomStudent.FullName.ToLower().Contains(normalizedQuery)) ||
             (r.RegistrationNumber != null && r.RegistrationNumber.ToLower().Contains(normalizedQuery)) ||
             (r.Email != null && r.Email.ToLower().Contains(normalizedQuery)) ||
             (r.Phone != null && r.Phone.ToLower().Contains(normalizedQuery))))
        {
          return true;
        }

        return false;
      };
    }
  }
}
