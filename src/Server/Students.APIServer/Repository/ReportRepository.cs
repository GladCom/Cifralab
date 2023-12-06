using FastExcel;
using Students.Models;

namespace Students.APIServer.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGenericRepository<EducationProgram> _educationProgramRepository;
        private readonly IGenericRepository<FEAProgram> _FEAProgramFormRepository;
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<ScopeOfActivity> _scopeOfActivityRepository;
        private readonly IGenericRepository<StudentDocument> _studentDocumentRepository;
        private readonly IGenericRepository<StudentEducation> _studentEducationRepository;
        private readonly IGenericRepository<StudentStatus> _studentStatusRepository;

        public ReportRepository(
            IStudentRepository studentRepository, 
            IGenericRepository<EducationProgram> educationProgramRepository, 
            IGenericRepository<FEAProgram> fEAProgramFormRepository, 
            IGenericRepository<Group> groupRepository, 
            IGenericRepository<Request> requestRepository, 
            IGenericRepository<ScopeOfActivity> scopeOfActivityRepository, 
            IGenericRepository<StudentDocument> studentDocumentRepository, 
            IGenericRepository<StudentEducation> studentEducationRepository, 
            IGenericRepository<StudentStatus> studentStatusRepository)
        {
            _studentRepository = studentRepository;
            _educationProgramRepository = educationProgramRepository;
            _FEAProgramFormRepository = fEAProgramFormRepository;
            _groupRepository = groupRepository;
            _requestRepository = requestRepository;
            _scopeOfActivityRepository = scopeOfActivityRepository;
            _studentDocumentRepository = studentDocumentRepository;
            _studentEducationRepository = studentEducationRepository;
            _studentStatusRepository = studentStatusRepository;
        }

        public async Task<byte[]> GetAll()
        {
            //start
            Console.WriteLine("start");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DataReport.xlsx");
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Template.xlsx");

            var fi = new FileInfo(path);
            var tfi = new FileInfo(templatePath);

            var studentsWorksheet = WriteOnePage(_studentRepository);
            var educationProgramWorksheet = WriteOnePage(_educationProgramRepository);
            var FEAProgramFormWorksheet = WriteOnePage(_FEAProgramFormRepository);
            var groupWorksheet = WriteOnePage(_groupRepository);
            var requestWorksheet = WriteOnePage(_requestRepository);
            var scopeOfActivityWorksheet = WriteOnePage(_scopeOfActivityRepository);
            var studentDocumentWorksheet = WriteOnePage(_studentDocumentRepository);
            var studentEducationWorksheet = WriteOnePage(_studentEducationRepository);
            var studentStatusWorksheet = WriteOnePage(_studentStatusRepository);

            //end
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(tfi, fi))
            {
                fastExcel.Write(await studentsWorksheet, "Студенты");
                fastExcel.Write(await educationProgramWorksheet, "Программы обучения");
                fastExcel.Write(await FEAProgramFormWorksheet, "FEAProgramForm");
                fastExcel.Write(await groupWorksheet, "Группы");
                fastExcel.Write(await requestWorksheet, "Обращения");
                fastExcel.Write(await scopeOfActivityWorksheet, "scopeOfActivity");
                fastExcel.Write(await studentDocumentWorksheet, "Документы студентов");
                fastExcel.Write(await studentEducationWorksheet, "Обучение студентов");
                fastExcel.Write(await studentStatusWorksheet, "Статус студентов");
            }
            return File.ReadAllBytes(path);
        }

        private async Task<Worksheet> WriteOnePage<T>(IGenericRepository<T> repository) where T : class
        {
            var data = await repository.Get();

            var worksheet = new Worksheet();

            var dataF = data.FirstOrDefault();
            if (dataF == null)
                throw new Exception("Entity is empty!");

            var properties = dataF.GetType().GetProperties().ToList();
            var celss = properties.Select(p => new Cell(properties.IndexOf(p) + 1, p.Name));
            var listData = data.ToList();

            var rows = new List<Row>()
            {
                new Row(1, celss)
            };

            for (int i = 0; i < listData.Count; i++)
            {
                var cells = new List<Cell>();
                for (int j = 0; j < properties.Count; j++)
                {
                    var cell = new Cell(j + 1, properties[j].GetValue(listData[i])?.ToString());
                    cells.Add(cell);
                }
                rows.Add(new Row(i + 2, cells));
            }

            worksheet.Rows = rows.ToArray();
            return worksheet;
        }
    }

}
