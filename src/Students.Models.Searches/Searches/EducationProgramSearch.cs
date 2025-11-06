using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class EducationProgramSearch : Search<EducationProgram>
  {
    public override Predicate<EducationProgram> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
