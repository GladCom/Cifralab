using System.Text.Json;
using Students.Models.Filters.Filters;
using Students.Models.ReferenceModels;

namespace Students.Models.Filters;

/// <summary>
/// Класс интерпретатор для фильтров.
/// </summary>
public static class FiltersSerializer
{
  /// <summary>
  /// Преобразование строки с фильтром в фильтр.
  /// </summary>
  /// <param name="filter">Json строка с фильтром.</param>
  /// <typeparam name="T">Тип данных фильтра.</typeparam>
  /// <returns>Фильтр.</returns>
  public static Filter<T>? FilterToTypedFilter<T>(string filter) where T : class
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    Filter<T>? result;

    try
    {
      result = typeof(T).Name switch
      {
        nameof(DocumentRiseQualification) => JsonSerializer.Deserialize<DocumentRiseQualificationFilter>(filter,
          options) as Filter<T>,
        nameof(EducationForm) => JsonSerializer.Deserialize<EducationFormFilter>(filter, options) as Filter<T>,
        nameof(EducationProgram) => JsonSerializer.Deserialize<EducationProgramFilter>(filter, options) as Filter<T>,
        nameof(FEAProgram) => JsonSerializer.Deserialize<FEAProgramFilter>(filter, options) as Filter<T>,
        nameof(FinancingType) => JsonSerializer.Deserialize<FinancingTypeFilter>(filter, options) as Filter<T>,
        nameof(Group) => JsonSerializer.Deserialize<GroupFilter>(filter, options) as Filter<T>,
        nameof(KindDocumentRiseQualification) => JsonSerializer.Deserialize<KindDocumentRiseQualificationFilter>(filter,
          options) as Filter<T>,
        nameof(KindOrder) => JsonSerializer.Deserialize<KindOrderFilter>(filter, options) as Filter<T>,
        nameof(Order) => JsonSerializer.Deserialize<OrderFilter>(filter, options) as Filter<T>,
        nameof(Request) => JsonSerializer.Deserialize<RequestFilter>(filter, options) as Filter<T>,
        nameof(ScopeOfActivityFilter) =>
          JsonSerializer.Deserialize<ScopeOfActivityFilter>(filter, options) as Filter<T>,
        nameof(StatusRequest) => JsonSerializer.Deserialize<StatusRequestFilter>(filter, options) as Filter<T>,
        nameof(Student) => JsonSerializer.Deserialize<StudentFilter>(filter, options) as Filter<T>,
        nameof(StudentStatus) => JsonSerializer.Deserialize<StudentStatusFilter>(filter, options) as Filter<T>,
        nameof(TypeEducation) => JsonSerializer.Deserialize<TypeEducationFilter>(filter, options) as Filter<T>,
        nameof(StudentHistory) => JsonSerializer.Deserialize<StudentHistoryFilter>(filter, options) as Filter<T>,
        _ => null
      };
    }
    catch(JsonException)
    {
      return null;
    }

    return result;
  }
}
