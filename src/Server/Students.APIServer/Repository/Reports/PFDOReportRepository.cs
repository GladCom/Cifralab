using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Repository.Reports
{
    /// <summary>
    /// Отчет ПФДО.
    /// </summary>
    public class PFDOReportRepository : IReportRepository<FRDOModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGenericRepository<EducationForm> _educationFormRepository;
        private readonly IGenericRepository<EducationProgram> _educationProgramRepository;
        private readonly IGenericRepository<KindDocumentRiseQualification> _kindDocumentRiseQualificationRepository;
        private readonly IGenericRepository<FEAProgram> _FEAProgramFormRepository;
        private readonly IGenericRepository<StatusRequest> _StatusRequestRepository;
        private readonly IGenericRepository<FinancingType> _financingTypeRepository;
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<ScopeOfActivity> _scopeOfActivityRepository;
        private readonly IGenericRepository<TypeEducation> _typeEducationRepository;
        private readonly IGenericRepository<StudentStatus> _studentStatusRepository;

        /// <summary>
        /// Данные для формирования отчета.
        /// </summary>
        /// <returns>Список данных.</returns>
        public async Task<List<FRDOModel>> Get()
        {
            var listStudents = await _studentRepository.Get();
            var pfdoModel = new List<FRDOModel>();
            foreach(var student in listStudents)
            {
                pfdoModel.Add(new FRDOModel()
                {
                    RecipientLastName = student.Family,
                    RecipientName = student.Name,
                    RecipientPatronymic = student.Patron,
                    RecipientDateBirth = student.BirthDate
                });
            }
            return pfdoModel;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="studentRepository">Репозиторий студентов.</param>
        /// <param name="educationFormRepository">Репозиторий форм обучения.</param>
        /// <param name="educationProgramRepository">Репозиторий образовательных программ.</param>
        /// <param name="kindDocumentRiseQualificationRepository">Репозиторий видов документов повышения квалификации.</param>
        /// <param name="fEAProgramFormRepository">Репозиторий ВЭД программ.</param>
        /// <param name="fStatusRequestRepository">Репозиторий статусов заявок.</param>
        /// <param name="financingTypeRepository">Репозиторрий типов финансирования.</param>
        /// <param name="groupRepository">Репозитоорий групп.</param>
        /// <param name="requestRepository">Репозиторий заявок.</param>
        /// <param name="scopeOfActivityRepository">Репозиторий сфер деятельности.</param>
        /// <param name="typeEducationRepository">Репозиторий типов образования.</param>
        /// <param name="studentStatusRepository">Репозиторий статусов студента.</param>
        public PFDOReportRepository(
            IStudentRepository studentRepository,
            IGenericRepository<EducationForm> educationFormRepository,
            IGenericRepository<EducationProgram> educationProgramRepository,
            IGenericRepository<KindDocumentRiseQualification> kindDocumentRiseQualificationRepository,
            IGenericRepository<FEAProgram> fEAProgramFormRepository,
            IGenericRepository<StatusRequest> fStatusRequestRepository,
            IGenericRepository<FinancingType> financingTypeRepository,
            IGenericRepository<Group> groupRepository,
            IGenericRepository<Request> requestRepository,
            IGenericRepository<ScopeOfActivity> scopeOfActivityRepository,
            IGenericRepository<TypeEducation> typeEducationRepository,
            IGenericRepository<StudentStatus> studentStatusRepository)
        {
            _studentRepository = studentRepository;
            _educationFormRepository = educationFormRepository;
            _educationProgramRepository = educationProgramRepository;
            _kindDocumentRiseQualificationRepository = kindDocumentRiseQualificationRepository;
            _FEAProgramFormRepository = fEAProgramFormRepository;
            _StatusRequestRepository = fStatusRequestRepository;
            _financingTypeRepository = financingTypeRepository;
            _groupRepository = groupRepository;
            _requestRepository = requestRepository;
            _scopeOfActivityRepository = scopeOfActivityRepository;
            _typeEducationRepository = typeEducationRepository;
            _studentStatusRepository = studentStatusRepository;
        }
    }
}
