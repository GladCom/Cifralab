using Students.Models.ReferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.Searches.Searches
{
  public class TypeEducationSearch : Search<TypeEducation>
  {
    public override Predicate<TypeEducation> GetSearchPredicate()
    {
      throw new NotImplementedException();
    }
  }
}
