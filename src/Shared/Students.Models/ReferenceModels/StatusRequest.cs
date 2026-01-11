using System.ComponentModel.DataAnnotations;

namespace Students.Models.ReferenceModels;

/// <summary>
/// статусы заявок
/// </summary>
public class StatusRequest
{
  /// <summary>
  /// Id статуса
  /// </summary>
  public Guid Id { get; set; }

    /// <summary>
    /// Имя статуса
    /// </summary>
    [RegularExpression("^(?=.*[А-Яа-яЁё])[А-Яа-яЁё\\s\\-]+$", ErrorMessage = "Статус заявки должен содержать только Кириллицу.")]
    public string? Name { get; set; }
}
