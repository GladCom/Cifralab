using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Документ повышения квалификации
/// </summary>
public class DocumentRiseQualification
{
    /// <summary>
    /// Id документа
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    public int KindDocumentRiseQualificationId { get; set; }
    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    [JsonIgnore]
    public KindDocumentRiseQualification kindDocumentRiseQualification { get; set; }
    /// <summary>
    /// Имя программы
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Дата выдачи удостоверения назовите это нормально
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Номер выдачи удостоверения назовите это нормально
    /// </summary>
    public string Number { get; set; }
}