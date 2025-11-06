using Students.Models.ReferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class FinancingTypeSearch : Search<FinancingType>
  {
    public override Predicate<FinancingType> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
