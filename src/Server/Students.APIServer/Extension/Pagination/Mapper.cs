using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;
using Students.Models.WebModels;

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
  public static Request WebhookToRequest(RequestWebhook form,
    IGenericRepository<EducationProgram> educationProgramRepository,
    IGenericRepository<StatusRequest> statusRequestRepository)
  {
    var status = statusRequestRepository.Get().Result.FirstOrDefault(x => x?.Name?.ToLower() == "новая");

    return new Request
    {
      Id = Guid.NewGuid(),
      Email = form.Email,
      Phone = form.Phone,
      EducationProgramId = educationProgramRepository.Get().Result.FirstOrDefault(x => x.Name == form.Education)?.Id,
      StatusRequestId = status?.Id,
      Status = status,
      Agreement = Convert.ToBoolean(form.Agreement)
    };
  }


  /// <summary>
  /// Преобразование вебхука (данных от минцифры) в студента. Подумать над RequestWebhook, возможно сделать 2 его варианта (второй, состоящий из слова test / test  для установки связи между минцифрой и нашим сервисом).
  /// </summary>
  /// <param name="form">Вебхук (данне от минцифры).</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  /// <param name="typeEducationRepository">Репозиторий типов образований.</param>
  /// <returns>Студент.</returns>
  public static Student WebhookToStudent(RequestWebhook form, IGenericRepository<Student> studentRepository,
    IGenericRepository<TypeEducation> typeEducationRepository)
  {
    var fio = form.Name!.Split(" ");
    return new Student
    {
      Address = form.Address!,
      Family = fio!.FirstOrDefault() ?? "",
      Name = fio!.Count() > 1 ? fio[1] : "",
      Patron = fio!.LastOrDefault() == fio!.FirstOrDefault() ? "" : fio!.LastOrDefault(),

      BirthDate = DateOnly.Parse(form.Birthday),
      IT_Experience = form.IT_Experience!,
      Email = form.Email!,
      Phone = form.Phone!,
      Sex = SexHuman.Men,
      TypeEducation = typeEducationRepository.Get().Result.FirstOrDefault(x => x.Name == form.EducationLevel),
      ScopeOfActivityLevelOneId = default,
      //Добавить в вебхук список, недостающих параметров, тут вставлять при наличии заполнения данных
      //Speciality = form.
      //Не хватает поля в вебхуке
      //.Projects = form.
      //CreatedAt = DateTime.Now,
    };
  }
}