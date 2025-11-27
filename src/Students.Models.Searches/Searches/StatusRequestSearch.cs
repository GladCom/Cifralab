using Students.Models.ReferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class StatusRequestSearch : Search<StatusRequest>
  {
    public override Predicate<StatusRequest> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
