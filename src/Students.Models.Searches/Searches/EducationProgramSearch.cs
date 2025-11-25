using System;

namespace Students.Models.Searches.Searches
{
  public class EducationProgramSearch : Search<EducationProgram>
  {
    public override Predicate<EducationProgram> GetSearchPredicate()
    {
      if (string.IsNullOrWhiteSpace(this.Query))
        return _ => true;
      var lower = this.Query.Trim().ToLower();
      return (program) => program.Name.ToLower().Contains(lower);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public EducationProgramSearch()
    {
      this.SearchProperties = new List<string>
      {
        nameof(EducationProgram.Name)
      };
    }
  }
}
