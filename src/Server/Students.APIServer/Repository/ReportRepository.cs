using Students.Models;
using System.Data;
using System.IO.Compression;

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

        public async Task<byte[]> GetAllCSV()
        {
            var files = new List<string>();

            var studentsPath = Path.Combine(Directory.GetCurrentDirectory(), "StudentsReport.csv");
            var educationProgramPath = Path.Combine(Directory.GetCurrentDirectory(), "EducationProgramReport.csv");
            var FEAProgramFormPath = Path.Combine(Directory.GetCurrentDirectory(), "FEAProgramFormReport.csv");
            var groupRepositoryPath = Path.Combine(Directory.GetCurrentDirectory(), "GroupRepositoryReport.csv");
            var requestPath = Path.Combine(Directory.GetCurrentDirectory(), "RequestReport.csv");
            var scopeOfActivityPath = Path.Combine(Directory.GetCurrentDirectory(), "ScopeOfActivityReport.csv");
            var studentDocumentPath = Path.Combine(Directory.GetCurrentDirectory(), "StudentDocumentReport.csv");
            var studentEducationPath = Path.Combine(Directory.GetCurrentDirectory(), "StudentEducationReport.csv");
            var studentStatusPath = Path.Combine(Directory.GetCurrentDirectory(), "StudentStatusReport.csv");

            files.Add(studentsPath);
            files.Add(educationProgramPath);
            files.Add(FEAProgramFormPath);
            files.Add(groupRepositoryPath);
            files.Add(requestPath);
            files.Add(scopeOfActivityPath);
            files.Add(studentDocumentPath);
            files.Add(studentEducationPath);
            files.Add(studentStatusPath);

            GetCSV(FillDataTable(await _studentRepository.Get()), studentsPath);
            GetCSV(FillDataTable(await _educationProgramRepository.Get()), educationProgramPath);
            GetCSV(FillDataTable(await _FEAProgramFormRepository.Get()), FEAProgramFormPath);
            GetCSV(FillDataTable(await _groupRepository.Get()), groupRepositoryPath);
            GetCSV(FillDataTable(await _requestRepository.Get()), requestPath);
            GetCSV(FillDataTable(await _scopeOfActivityRepository.Get()), scopeOfActivityPath);
            GetCSV(FillDataTable(await _studentDocumentRepository.Get()), studentDocumentPath);
            GetCSV(FillDataTable(await _studentEducationRepository.Get()), studentEducationPath);
            GetCSV(FillDataTable(await _studentStatusRepository.Get()), studentStatusPath);

            var zipPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports.zip");
            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (var file in files)
                {
                    // Add the entry for each file
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
            }
            return File.ReadAllBytes(zipPath);
        }

        private DataTable FillDataTable<T>(IEnumerable<T> data) where T : class
        {
            DataTable table = new DataTable();

            var dataF = data.FirstOrDefault() ?? throw new Exception("Entity is empty!");
            var properties = dataF.GetType().GetProperties().ToList();
            var listData = data.ToList();

            foreach(var p in properties)
            {
                table.Columns.Add(p.Name);
            }
            for(int i = 0; i < listData.Count; i++)
            {
                object[] array = new object[properties.Count];
                for (int j = 0; j < properties.Count; j++)
                {
                    array[j] = properties[j].GetValue(listData[i])?.ToString();
                }
                table.Rows.Add(array);
            }
            return table;
        }

        public static void GetCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
