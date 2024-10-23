using System.Text.Json.Serialization;
using Students.Models.ReferenceModels;

namespace Students.Models;

/// <summary>
/// Приказ
/// </summary>
public class Order
{
  /// <summary>
  /// Id приказа
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Номер приказа
  /// </summary>
  public string? Number { get; set; }

  /// <summary>
  /// Дата приказа
  /// </summary>
  public required DateTime Date { get; set; }

  /// <summary>
  /// Вид приказа
  /// </summary>
  public required Guid KindOrderId { get; set; }

  /// <summary>
  /// Id Заявка
  /// </summary>
  public required Guid RequestId { get; set; }
  
  /// <summary>
  /// Вид приказа
  /// </summary>
  [JsonIgnore]
  public virtual KindOrder? KindOrder { get; set; }

  /// <summary>
  /// Заявка
  /// </summary>
  [JsonIgnore]
  public virtual Request? Request { get; set; }
}