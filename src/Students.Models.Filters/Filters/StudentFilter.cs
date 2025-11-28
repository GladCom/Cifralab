namespace Students.Models.Filters.Filters;
public class StudentFilter : Filter<Student>
{
  /// <summary>
  /// Полное имя.
  /// </summary>
  public string? FullName { get; set; }
  
  /// <summary>
  /// Адрес.
  /// </summary>
  public string? Address { get; set; }
  
  /// <summary>
  /// Электронная почта.
  /// </summary>
  public string? Email { get; set; }
  
  /// <summary>
  /// Телефон.
  /// </summary>
  public string? Phone { get; set; }
  
  public override Predicate<Student> GetFilterPredicate()
  {
    return
      x => FilterByStringProperty(this.FullName, x.FullName) ||
           FilterByStringProperty(this.Address, x.Address) ||
           FilterByStringProperty(this.Email, x.Email) ||
           FilterByStringProperty(this.Phone, x.Phone);
  }
}
