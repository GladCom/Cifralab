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
        private readonly IGenericRepository<KindDocumentRiseQualification> _kindDocumentRiseQualificationRepository;
        private readonly IGenericRepository<FEAProgram> _FEAProgramFormRepository;
        private readonly IGenericRepository<StatusRequest> _StatusRequestRepository;
        private readonly IGenericRepository<FinancingType> _financingTypeRepository;
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<ScopeOfActivity> _scopeOfActivityRepository;
        private readonly IGenericRepository<StudentEducation> _studentEducationRepository;
        private readonly IGenericRepository<StudentStatus> _studentStatusRepository;

        public CSVReportRepository(
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
            IGenericRepository<StudentEducation> studentEducationRepository,
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
            _studentEducationRepository = studentEducationRepository;
            _studentStatusRepository = studentStatusRepository;
        }

        /// <summary>
        /// Записывает все сущности в csv и возвращает все данные.
        /// </summary>
        /// <returns>Mассив байт с архивом, содержащим все отчёты в формате csv.</returns>
        public async Task<byte[]> GetAll()
        {
            var reportMapping = new Dictionary<string, DataTable>()
            {
                { "StudentsReport.csv", await WriteOneDT(_studentRepository) },
                { "EducationFormReport.csv", await WriteOneDT(_educationFormRepository) },
                { "EducationProgramReport.csv", await WriteOneDT(_educationProgramRepository) },
                { "KindDocumentRiseQualification.csv", await WriteOneDT(_kindDocumentRiseQualificationRepository) },
                { "FEAProgramFormReport.csv", await WriteOneDT(_FEAProgramFormRepository) },
                { "StatusRequestReport.csv", await WriteOneDT(_StatusRequestRepository) },
                { "FinancingTypeReport.csv", await WriteOneDT(_financingTypeRepository) },
                { "GroupRepositoryReport.csv", await WriteOneDT(_groupRepository) },
                { "RequestReport.csv", await WriteOneDT(_requestRepository) },
                { "ScopeOfActivityReport.csv", await WriteOneDT(_scopeOfActivityRepository) },
                { "StudentEducationReport.csv", await WriteOneDT(_studentEducationRepository) },
                { "StudentStatusReport.csv", await WriteOneDT(_studentStatusRepository) }
            };
            var files = WriteCSVsTempPath(reportMapping);
            return GetZipWithAllFiles(files);
        }

        /// <summary>
        /// Записывает все файлы в zip архив.
        /// </summary>
        /// <param name="files">Лист путей до файлов.</param>
        /// <returns>Mассив байт с архивом, содержащим все файлы.</returns>
        private byte[] GetZipWithAllFiles(List<string> files)
        {
            var zipPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports.zip");
            var mode = File.Exists(zipPath) ? ZipArchiveMode.Update : ZipArchiveMode.Create;
            using (var zip = ZipFile.Open(zipPath, mode))
            {
                foreach (var file in files)
                {
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
        /// Записывает все сущности перечисленные в словаре в значении по пути указанному в ключе.
        /// </summary>
        /// <param name="reportMapping">Словарь. Ключ - путь к файлу, значение - таблица с данными.</param>
        /// <returns></returns>
        private List<string> WriteCSVsTempPath(Dictionary<string, DataTable> reportMapping)
        {
            var files = new List<string>();
            foreach (var mapping in reportMapping)
            {
                var filePath = Path.Combine(Path.GetTempPath(), mapping.Key);
                GetCSV(mapping.Value, filePath);
                files.Add(filePath);
            }
            return files;
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
