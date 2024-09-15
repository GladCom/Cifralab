using Students.APIServer.Repository;
using Students.Models;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Students.APIServer.Extension.Pagination;

/// <summary>
/// Класс содержит методы для преобразования данных
/// </summary>
public class Mapper
{
    /// <summary>
    /// Преобразование вебхука в заявку на обучение
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static Request WebhookToRequest(RequestWebhook form, 
            IGenericRepository<EducationProgram> educationProgramRepository, IGenericRepository<StatusRequest> statusRequestRepository)
    {
        var status = statusRequestRepository.Get().Result.FirstOrDefault(x => x?.Name.ToLower() == "новая");

        return new Request
        {
            Id = Guid.NewGuid(),
            Email = form.Email,
            Phone = form.Phone,
            EducationProgramId = educationProgramRepository.Get().Result.FirstOrDefault(x => x.Name == form.Education)?.Id,
            StatusRequestId = status?.Id,
            Status = status
        };
    }

    /// <summary>
    /// Преобразование вебхука в студента
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static Student WebhookToStudent(RequestWebhook form, IGenericRepository<Student> studentRepository, IGenericRepository<TypeEducation> typeEducationRepository)
    {
        var fio = form.Name.Split(" ");
        return new Student()
        {
            Address = form.Address,
            Family = fio.FirstOrDefault(),
            Name = fio.Count() > 1 ? fio[1] : "",
            Patron = fio.LastOrDefault() == fio.FirstOrDefault() ? "" : fio.LastOrDefault(),

            BirthDate = DateOnly.Parse(form.Birthday),
            IT_Experience = form.IT_Experience,
            Email = form.Email,
            Phone = form.Phone,
            Sex = SexHuman.Men,
            TypeEducation = typeEducationRepository.Get().Result.Where(x => x.Name == form.EducationLevel).FirstOrDefault(),
            //Speciality = form.
            //Не хватает поля в вебхуке
            //.Projects = form.
            //CreatedAt = DateTime.Now,
        };
    }
}