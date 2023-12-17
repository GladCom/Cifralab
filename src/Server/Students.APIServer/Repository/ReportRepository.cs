using FastExcel;
using Students.Models;
using System.Data;
using System.IO;
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

        public async Task<byte[]> GetAllExcel()
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

            GetCSV(await WriteOneDT(_studentRepository), studentsPath);
            GetCSV(await WriteOneDT(_educationProgramRepository), educationProgramPath);
            GetCSV(await WriteOneDT(_FEAProgramFormRepository), FEAProgramFormPath);
            GetCSV(await WriteOneDT(_groupRepository), groupRepositoryPath);
            GetCSV(await WriteOneDT(_requestRepository), requestPath);
            GetCSV(await WriteOneDT(_scopeOfActivityRepository), scopeOfActivityPath);
            GetCSV(await WriteOneDT(_studentDocumentRepository), studentDocumentPath);
            GetCSV(await WriteOneDT(_studentEducationRepository), studentEducationPath);
            GetCSV(await WriteOneDT(_studentStatusRepository), studentStatusPath);

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

        private async Task<DataTable> WriteOneDT<T>(IGenericRepository<T> repository) where T : class
        {
            var data = await repository.Get();

            DataTable table = new DataTable();

            var dataF = data.FirstOrDefault();
            if (dataF == null)
                throw new Exception("Entity is empty!");

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
