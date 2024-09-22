using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    /// дата приказа
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Вид приказа
    /// </summary>
    public Guid KindOrderId { get; set; }

    /// <summary>
    /// Вид приказа
    /// </summary>
    [Required]
    public required KindOrder KindOrder { get; set; }

    /// <summary>
    /// Id Заявка
    /// </summary>
    public Guid RequestId { get; set; }
    /// <summary>
    /// Заявка
    /// </summary>
    [JsonIgnore]
    [Required]
    public required Request Request { get; set; }
}