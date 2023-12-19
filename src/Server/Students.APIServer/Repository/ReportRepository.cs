using Students.Models;
using System.Data;
using System.IO.Compression;

namespace Students.APIServer.Repository
{
    public class CSVReportRepository : IReportRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGenericRepository<EducationForm> _educationFormRepository;
        private readonly IGenericRepository<EducationProgram> _educationProgramRepository;
        private readonly IGenericRepository<EducationType> _educationTypeRepository;
        private readonly IGenericRepository<FEAProgram> _FEAProgramFormRepository;
        private readonly IGenericRepository<FinancingType> _financingTypeRepository;
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<ScopeOfActivity> _scopeOfActivityRepository;
        private readonly IGenericRepository<StudentDocument> _studentDocumentRepository;
        private readonly IGenericRepository<StudentEducation> _studentEducationRepository;
        private readonly IGenericRepository<StudentStatus> _studentStatusRepository;

        public CSVReportRepository(
            IStudentRepository studentRepository,
            IGenericRepository<EducationForm> educationFormRepository,
            IGenericRepository<EducationProgram> educationProgramRepository,
            IGenericRepository<EducationType> educationTypeRepository,
            IGenericRepository<FEAProgram> fEAProgramFormRepository,
            IGenericRepository<FinancingType> financingTypeRepository,
            IGenericRepository<Group> groupRepository,
            IGenericRepository<Request> requestRepository,
            IGenericRepository<ScopeOfActivity> scopeOfActivityRepository,
            IGenericRepository<StudentDocument> studentDocumentRepository,
            IGenericRepository<StudentEducation> studentEducationRepository,
            IGenericRepository<StudentStatus> studentStatusRepository)
        {
            _studentRepository = studentRepository;
            _educationFormRepository = educationFormRepository;
            _educationProgramRepository = educationProgramRepository;
            _educationTypeRepository = educationTypeRepository;
            _FEAProgramFormRepository = fEAProgramFormRepository;
            _financingTypeRepository = financingTypeRepository;
            _groupRepository = groupRepository;
            _requestRepository = requestRepository;
            _scopeOfActivityRepository = scopeOfActivityRepository;
            _studentDocumentRepository = studentDocumentRepository;
            _studentEducationRepository = studentEducationRepository;
            _studentStatusRepository = studentStatusRepository;
        }

        /// <summary>
        /// Создаёт csv всех таблиц и помещает их в zip архив.
        /// </summary>
        /// <returns>zip архив в виде byte[]</returns>
        public async Task<byte[]> GetAll()
        {
            var files = new List<string>();
            var directory = Path.GetTempPath();

            var studentsPath = Path.Combine(directory, "StudentsReport.csv");
            var educationFormPath = Path.Combine(directory, "EducationFormReport.csv");
            var educationProgramPath = Path.Combine(directory, "EducationProgramReport.csv");
            var educationTypePath = Path.Combine(directory, "EducationTypeReport.csv");
            var FEAProgramFormPath = Path.Combine(directory, "FEAProgramFormReport.csv");
            var financingTypePath = Path.Combine(directory  , "FinancingTypeReport.csv");
            var groupRepositoryPath = Path.Combine(directory, "GroupRepositoryReport.csv");
            var requestPath = Path.Combine(directory, "RequestReport.csv");
            var scopeOfActivityPath = Path.Combine(directory, "ScopeOfActivityReport.csv");
            var studentDocumentPath = Path.Combine(directory, "StudentDocumentReport.csv");
            var studentEducationPath = Path.Combine(directory, "StudentEducationReport.csv");
            var studentStatusPath = Path.Combine(directory, "StudentStatusReport.csv");

            files.Add(studentsPath);
            files.Add(educationFormPath);
            files.Add(educationProgramPath);
            files.Add(educationTypePath);
            files.Add(FEAProgramFormPath);
            files.Add(financingTypePath);
            files.Add(groupRepositoryPath);
            files.Add(requestPath);
            files.Add(scopeOfActivityPath);
            files.Add(studentDocumentPath);
            files.Add(studentEducationPath);
            files.Add(studentStatusPath);

            GetCSV(await WriteOneDT(_studentRepository), studentsPath);
            GetCSV(await WriteOneDT(_educationFormRepository), educationFormPath);
            GetCSV(await WriteOneDT(_educationProgramRepository), educationProgramPath);
            GetCSV(await WriteOneDT(_educationTypeRepository), educationTypePath);
            GetCSV(await WriteOneDT(_FEAProgramFormRepository), FEAProgramFormPath);
            GetCSV(await WriteOneDT(_financingTypeRepository), financingTypePath);
            GetCSV(await WriteOneDT(_groupRepository), groupRepositoryPath);
            GetCSV(await WriteOneDT(_requestRepository), requestPath);
            GetCSV(await WriteOneDT(_scopeOfActivityRepository), scopeOfActivityPath);
            GetCSV(await WriteOneDT(_studentDocumentRepository), studentDocumentPath);
            GetCSV(await WriteOneDT(_studentEducationRepository), studentEducationPath);
            GetCSV(await WriteOneDT(_studentStatusRepository), studentStatusPath);

            var zipPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports.zip");
            var mode = File.Exists(zipPath) ? ZipArchiveMode.Update : ZipArchiveMode.Create;
            using (var zip = ZipFile.Open(zipPath, mode))
            {
                foreach (var file in files)
                {
                    // Add the entry for each file
                    if (mode == ZipArchiveMode.Create)
                        zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);

                    if (mode == ZipArchiveMode.Update)
                    {
                        zip.GetEntry(Path.GetFileName(file))?.Delete();
                        zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                    }
                    File.Delete(file);
                }
            }
            return File.ReadAllBytes(zipPath);
        }

        /// <summary>
        /// Выгружает данные из репозитория и помещает их в datatable.
        /// </summary>
        /// <typeparam name="T">Сущность, которая будет выгружена.</typeparam>
        /// <param name="repository">Репозиторий, из которого будет выгружены данные.</param>
        /// <returns>Таблица с данными из репозитория.</returns>
        /// <exception cref="Exception">Возможная ошибка при выгрузке данных.</exception>
        private async Task<DataTable> WriteOneDT<T>(IGenericRepository<T> repository) where T : class
        {
            var data = await repository.Get();

            DataTable table = new DataTable();

            var dataF = data.FirstOrDefault();
            if (dataF == null)
                throw new Exception("Entity is empty!");

            var properties = dataF.GetType().GetProperties().ToList();
            var listData = data.ToList();

            foreach (var p in properties)
            {
                table.Columns.Add(p.Name);
            }
            for (int i = 0; i < listData.Count; i++)
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

        /// <summary>
        /// Помещает данные из таблицы в csv по указаному пути.
        /// </summary>
        /// <param name="dtDataTable">Таблица с данными для csv.</param>
        /// <param name="strFilePath">Строка местоположения файла csv.</param>
        private void GetCSV(DataTable dtDataTable, string strFilePath)
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
