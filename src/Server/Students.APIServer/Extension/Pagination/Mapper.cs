using Students.APIServer.DTO;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Extension.Pagination;

/// <summary>
/// Класс содержит методы для преобразования данных.
/// </summary>
public static class Mapper
{
  /// <summary>
  /// Преобразование вебхука в заявку на обучение.
  /// </summary>
  /// <param name="form">Данные, полученные из минцифры.</param>
  /// <param name="educationProgramRepository">Репозиторий образовательных программ.</param>
  /// <param name="statusRequestRepository">Репозиторий статусов заявок.</param>
  /// <returns>Заявка.</returns>
  public static async Task<Request> WebhookToRequest(RequestWebhook form,
    IGenericRepository<EducationProgram> educationProgramRepository,
    IGenericRepository<StatusRequest> statusRequestRepository)
  {
    return new Request
    {
      Id = Guid.NewGuid(),
      Email = form.Email,
      Phone = form.Phone,
      EducationProgramId = (await educationProgramRepository.GetOne(x => x.Name == form.Education))?.Id,
      StatusRequestId = (await statusRequestRepository.GetOne(x => x.Name == "новая заявка"))?.Id,
      Agreement = Convert.ToBoolean(Convert.ToInt32(form.Agreement))
    };
  }

  /// <summary>
  /// Преобразование вебхука (данных от минцифры) в студента. Подумать над RequestWebhook, возможно сделать 2 его варианта (второй, состоящий из слова test / test  для установки связи между минцифрой и нашим сервисом).
  /// </summary>
  /// <param name="form">Вебхук (данне от минцифры).</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  /// <param name="typeEducationRepository">Репозиторий типов образований.</param>
  /// <param name="scopeOfActivityRepository">Репозиторий сферы деятельности.</param>
  public static async Task<Student> WebhookToStudent(RequestWebhook form,
    IGenericRepository<TypeEducation> typeEducationRepository, IGenericRepository<ScopeOfActivity> scopeOfActivityRepository)
  {
    var fio = form.Name.Split(" ");
    return new Student
    {
      Address = form.Address,
      Family = fio.FirstOrDefault() ?? "",
      Name = fio.Length > 1
        ? fio[1]
        : "",
      Patron = fio.LastOrDefault() == fio.FirstOrDefault()
        ? ""
        : fio.LastOrDefault(),

      BirthDate = DateOnly.Parse(form.Birthday),
      IT_Experience = form.IT_Experience,
      Email = form.Email,
      Phone = form.Phone,
      TypeEducationId = (await typeEducationRepository.GetOne(x => x.Name == form.EducationLevel))?.Id,
      ScopeOfActivityLevelOneId =
        (await scopeOfActivityRepository.GetOne(x => x.NameOfScope == form.ScopeOfActivityLevelOneName))!.Id,
      ScopeOfActivityLevelTwoId = form.ScopeOfActivityLevelTwoName is null ? null :
        (await scopeOfActivityRepository.GetOne(x => x.NameOfScope == form.ScopeOfActivityLevelTwoName))!.Id,
      Sex = default
      //Добавить в вебхук список, недостающих параметров, тут вставлять при наличии заполнения данных
      //Speciality = form.
      //Не хватает поля в вебхуке
      //.Projects = form.
      //CreatedAt = DateTime.Now,
    };
  }

  /// <summary>
  /// Преобразование Request в DTO.
  /// </summary>
  /// <param name="form">Заявка.</param>
  /// <returns>DTO заявки.</returns>
  public static async Task<RequestsDTO> RequestToRequestDTO(Request form)
  {
    return new RequestsDTO
    {
      Id = form.Id,
      StudentId = form.Student?.Id,
      StudentFullName = form.Student?.FullName ?? "",
      family = form.Student?.Family,
      name = form.Student?.Name,
      patron = form.Student?.Patron,
      StatusRequest = form.Status?.Name,
      StatusRequestId = form.StatusRequestId,
      EducationProgram = form.EducationProgram?.Name,
      EducationProgramId = form.EducationProgramId,
      TypeEducation = form.Student?.TypeEducation?.Name,
      TypeEducationId = form.Student?.TypeEducationId,
      speciality = form.Student?.Speciality,
      IT_Experience = form.Student?.IT_Experience,
      projects = form.Student?.Projects,
      statusEntrancExams = form.StatusEntrancExams ?? 0,
      BirthDate = form.Student?.BirthDate,
      Age = form.Student?.Age,
      Address = form.Student?.Address,
      phone = form.Student?.Phone,
      Email = form.Student?.Email,
      ScopeOfActivityLevelOneId = form.Student?.ScopeOfActivityLevelOneId,
      ScopeOfActivityLevelTwoId = form.Student?.ScopeOfActivityLevelTwoId,
      agreement = form.Agreement,
      trained = form.Orders != null && form.Orders!.Any(x => x.KindOrder!.Name!.ToLower() == "О зачислении")
    };
  }

  /// <summary>
  /// Преобразование Student в DTO.
  /// </summary>
  /// <param name="student">Студент.</param>
  /// <returns>DTO студента.</returns>
  public static async Task<StudentDTO> StudentToStudentDTO(Student student)
  {
    var groupStudent = student.GroupStudent?.FirstOrDefault();
    return new StudentDTO
    {
      Id = student.Id,
      StudentFamily = student.Family,
      StudentName = student.Name,
      StudentPatron = student.Patron,
      StudentFullName = student.FullName,
      BirthDate = student.BirthDate,
      Address = student.Address,
      RequestId = groupStudent?.Request?.Id,
      StatusRequestId = groupStudent?.Request?.StatusRequestId,
      StatusRequestName = groupStudent?.Request?.Status?.Name,
      EducationProgramId = groupStudent?.Group?.EducationProgramId,
      ProgramName = groupStudent?.Group?.EducationProgram?.Name,
      GroupId = groupStudent?.Group?.Id,
      GroupName = groupStudent?.Group?.Name,
      GroupStartDate = groupStudent?.Group?.StartDate,
      GroupEndDate = groupStudent?.Group?.EndDate
    };
  }

  /// <summary>
  /// Преобразование Order в DTO.
  /// </summary>
  /// <param name="order">Приказ.</param>
  /// <returns>DTO приказа.</returns>
  public static async Task<OrderDTO> OrderToOrderDTO(Order order)
  {
    return new OrderDTO
    {
      Id = order.Id,
      Date = order.Date,
      Number = order.Number,
      StudentName = order.Request?.Student?.FullName,
      KindOrderName = order.KindOrder?.Name,
      Groups = order.Request?.Student?.Groups
    };
  }

  /// <summary>
  /// Преобразование NewRequestDTO в заявку.
  /// </summary>
  /// <param name="form">DTO новой заявки.</param>
  /// <param name="_statusRequestRepository">Репозиторий статусов заявок.</param>
  /// <returns>Заявка.</returns>
  public static async Task<Request> NewRequestDTOToRequest(NewRequestDTO form, IGenericRepository<StatusRequest> _statusRequestRepository)
  {
    return new Request
    {
      //Id = requestDTO.Id ?? default,
      //StudentId = requestDTO.StudentId,
      EducationProgramId = form.educationProgramId,
      //DocumentRiseQualificationId = requestDTO.
      StatusRequestId = (await _statusRequestRepository.GetOne(x => x.Name!.ToLower() == "новая заявка"))?.Id,
      StatusEntrancExams = (StatusEntrancExams)form.statusEntrancExams,
      Email = form.email,
      Phone = form.phone,
      Agreement = form.agreement
    };
  }

  /// <summary>
  /// Преобразование NewRequestDTO в студента.
  /// </summary>
  /// <param name="form">DTO новой заявки.</param>
  /// <returns>Студент.</returns>
  public static async Task<Student> NewRequestDTOToStudent(NewRequestDTO form)
  {
    return new Student
    {
      Address = form.address,
      Family = form.family ?? "",
      Name = form.name,
      Patron = form.patron,

      BirthDate = form.birthDate,
      IT_Experience = form.iT_Experience,
      Email = form.email,
      Phone = form.phone ?? "",
      Sex = SexHuman.Men,
      TypeEducationId = form.typeEducationId,
      ScopeOfActivityLevelOneId = form.scopeOfActivityLevelOneId,
      ScopeOfActivityLevelTwoId = form.scopeOfActivityLevelTwoId
    };
  }

  /// <summary>
  /// Преобразование RequestDTO в студента.
  /// </summary>
  /// <param name="form">DTO заявки.</param>
  /// <returns>Студент.</returns>
  public static async Task<Student> RequestDTOToStudent(RequestsDTO form)
  {
    return new Student
    {
      Family = form.family!,
      Name = form.name,
      Patron = form.patron,
      BirthDate = (DateOnly)form.BirthDate!,
      Sex = default,
      Address = form.Address!,
      Phone = form.phone!,
      Email = form.Email!,
      Projects = form.projects,
      IT_Experience = form.IT_Experience!,
      TypeEducationId = form.TypeEducationId,
      //Ебать-кололить
      ScopeOfActivityLevelOneId = Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34"),
      Speciality = form.speciality
    };
  }
}