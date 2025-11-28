using Students.Models.ReferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class FEAProgramSearch : Search<FEAProgram>
  {
    public override Predicate<FEAProgram> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
