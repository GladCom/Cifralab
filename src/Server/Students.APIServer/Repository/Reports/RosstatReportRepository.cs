using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Repository.Reports
{
    /// <summary>
    /// Репозиторий.
    /// </summary>
    public class RosstatReportRepository : IReportRepository<RosstatModel>
    {
        private readonly IStudentRepository _studentRepository;
        /// <summary>
        /// Получить список сущностей.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        public async Task<List<RosstatModel>> Get()
        {
            var listStudents = await _studentRepository.Get();
            return new List<RosstatModel>() { new RosstatModel() { StudentCount = listStudents.Count() } };
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="studentRepository">Репозиторий студентов.</param>
        public RosstatReportRepository(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
    }
}
