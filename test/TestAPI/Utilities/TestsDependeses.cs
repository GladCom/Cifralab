using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.ReferenceModels;
using TestContext = Students.DBCore.Contexts.TestContext;

namespace TestAPI.Utilities;

internal static class TestsDepends
{
  public static StudentContext GetContext()
  {
    return new TestContext();
  }

  public static IGenericRepository<TEntity> GetGenericRepository<TEntity>(StudentContext context) where TEntity : class
  {
    return new GenericRepository<TEntity>(context);
  }

  public static Mapper GetMapper(StudentContext context)
  {
    return new Mapper(GetGenericRepository<EducationProgram>(context), GetGenericRepository<StatusRequest>(context),
      GetGenericRepository<TypeEducation>(context), GetGenericRepository<ScopeOfActivity>(context), GetStudentRepository(context));
  }

  public static IRequestRepository GetRequestRepository(StudentContext context)
  {
    return new RequestRepository(context, GetOrderRepository(context), GetStudentRepository(context),
      GetGenericRepository<PhantomStudent>(context), GetMapper(context));
  }

  public static IGroupRepository GetGroupRepository(StudentContext context)
  {
    return new GroupRepository(context, GetRequestRepository(context), GetGroupStudentRepository(context));
  }

  public static IGroupStudentRepository GetGroupStudentRepository(StudentContext context)
  {
    return new GroupStudentRepository(context);
  }

  public static IOrderRepository GetOrderRepository(StudentContext context)
  {
    return new OrderRepository(context);
  }

  public static IStudentRepository GetStudentRepository(StudentContext context)
  {
    return new StudentRepository(context, GetStudentHistoryRepository(context));
  }

  public static IStudentHistoryRepository GetStudentHistoryRepository(StudentContext context)
  {
    return new StudentHistoryRepository(context);
  }

  public static IEducationProgramRepository GetEducationProgramRepository(StudentContext context)
  {
    return new EducationProgramRepository(context);
  }

  public static IFEAProgramRepository GetFEAProgramRepository(StudentContext context)
  {
    return new FEAProgramRepository(context);
  }

  public static IFinancingTypeRepository GetFinancingTypeRepository(StudentContext context)
  {
    return new FinancingTypeRepository(context);
  }
}
