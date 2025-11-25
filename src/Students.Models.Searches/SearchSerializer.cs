using Students.Models.ReferenceModels;
using Students.Models.Searches.Searches;
using System.Text.Json;

namespace Students.Models.Searches
{
  /// <summary>
  /// Класс интерпретатор для поисков.
  /// </summary>
  public static class SearchSerializer
  {
    /// <summary>
    /// Преобразует строку JSON с поиском в типизированный объект поиска.
    /// </summary>
    /// <typeparam name="T">Тип сущности, к которой относится поиск.</typeparam>
    /// <param name="search">Строка JSON с параметрами поиска.</param>
    /// <returns>Объект поиска или <c>null</c>, если преобразование не удалось.</returns>
    public static Search<T>? SearchToTypedSearch<T>(string search) where T : class
    {
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };

      Search<T>? result;

      try
      {
        result = typeof(T).Name switch
        {
          nameof(DocumentRiseQualification) => JsonSerializer.Deserialize<DocumentRiseQualificationSearch>(search, options) as Search<T>,
          nameof(EducationForm) => JsonSerializer.Deserialize<EducationFormSearch>(search, options) as Search<T>,
          nameof(EducationProgram) => JsonSerializer.Deserialize<EducationProgramSearch>(search, options) as Search<T>,
          nameof(FEAProgram) => JsonSerializer.Deserialize<FEAProgramSearch>(search, options) as Search<T>,
          nameof(FinancingType) => JsonSerializer.Deserialize<FinancingTypeSearch>(search, options) as Search<T>,
          nameof(Group) => JsonSerializer.Deserialize<GroupSearch>(search, options) as Search<T>,
          nameof(KindDocumentRiseQualification) => JsonSerializer.Deserialize<KindDocumentRiseQualificationSearch>(search, options) as Search<T>,
          nameof(KindOrder) => JsonSerializer.Deserialize<KindOrderSearch>(search, options) as Search<T>,
          nameof(Order) => JsonSerializer.Deserialize<OrderSearch>(search, options) as Search<T>,
          nameof(Request) => JsonSerializer.Deserialize<RequestSearch>(search, options) as Search<T>,
          nameof(ScopeOfActivity) => JsonSerializer.Deserialize<ScopeOfActivitySearch>(search, options) as Search<T>,
          nameof(StatusRequest) => JsonSerializer.Deserialize<StatusRequestSearch>(search, options) as Search<T>,
          nameof(Student) => JsonSerializer.Deserialize<StudentSearch>(search, options) as Search<T>,
          nameof(StudentStatus) => JsonSerializer.Deserialize<StudentStatusSearch>(search, options) as Search<T>,
          nameof(TypeEducation) => JsonSerializer.Deserialize<TypeEducationSearch>(search, options) as Search<T>,
          nameof(StudentHistory) => JsonSerializer.Deserialize<StudentHistorySearch>(search, options) as Search<T>,
          _ => null
        };
      }
      catch (JsonException)
      {
        return null;
      }

      return result;
    }
  }
}
