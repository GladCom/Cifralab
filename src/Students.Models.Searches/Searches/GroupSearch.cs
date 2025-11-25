using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class GroupSearch : Search<Group>
  {
    public override Predicate<Group> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
