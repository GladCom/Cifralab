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
    public KindOrder Kind { get; set; }

    /// <summary>
    /// Id Заявка
    /// </summary>
    public Guid RequestId { get; set; }
    /// <summary>
    /// Заявка
    /// </summary>
    [JsonIgnore]
    public Request Request { get; set; }
}