using System.IO.Compression;

namespace Students.APIServer.Repository
{
    public interface IReportRepository
    {
        Task<byte[]> GetAllExcel();

        Task<byte[]> GetAllCSV();
    }
}
