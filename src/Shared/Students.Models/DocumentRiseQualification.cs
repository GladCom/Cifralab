using System.Text.Json.Serialization;
using Students.Models.ReferenceModels;

namespace Students.Models;

/// <summary>
/// Документ повышения квалификации
/// </summary>
public class DocumentRiseQualification
{
    /// <summary>
    /// Id документа
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    public required Guid KindDocumentRiseQualificationId { get; set; }

    /// <summary>
    /// Дата выдачи удостоверения назовите это нормально
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Номер выдачи удостоверения назовите это нормально
    /// </summary>
    public required string Number { get; set; } = string.Empty;

    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    [JsonIgnore]
    public virtual KindDocumentRiseQualification? KindDocumentRiseQualification { get; set; }
}