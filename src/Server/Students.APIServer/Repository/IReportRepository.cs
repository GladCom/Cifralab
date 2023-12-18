namespace Students.APIServer.Repository
{
    public interface IReportRepository
    {
        Task<byte[]> GetAll();
    }
}
