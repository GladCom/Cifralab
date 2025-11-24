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

      var lower = Query.Trim().ToLower();

      return r =>
      {
        if (r.Student != null &&
            ((r.Student.Family?.ToLower().Contains(lower) ?? false) ||
             (r.Student.Name?.ToLower().Contains(lower) ?? false) ||
             (r.Student.Patron?.ToLower().Contains(lower) ?? false) ||
             (r.Student.FullName?.ToLower().Contains(lower) ?? false)))
          return true;

        return
          (r.RegistrationNumber?.ToLower().Contains(lower) ?? false) ||
          (r.Email?.ToLower().Contains(lower) ?? false) ||
          (r.Phone?.ToLower().Contains(lower) ?? false);
      };
    }
  }
}
