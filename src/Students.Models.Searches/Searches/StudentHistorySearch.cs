using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class StudentHistorySearch : Search<StudentHistory>
  {
    public override Predicate<StudentHistory> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
