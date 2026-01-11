using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class OrderSearch : Search<Order>
  {
    public override Predicate<Order> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
