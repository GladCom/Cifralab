using Students.APIServer.Repository;
using Students.Models;

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
    public static Request WebhookToRequest(RequestWebhook form, IGenericRepository<Student> studentRepository, IGenericRepository<EducationProgram> educationProgramRepository)
    {
        var student = studentRepository.Get().Result.FirstOrDefault(x => x.FullName == form.Name && x.BirthDate.ToString() == form.Birthday && x.Email == form.Email);

        if (student == null)
        {
            student = new Student()
            {
                Address = form.Address,
                Family = form.Name.Split(" ").FirstOrDefault(),
                Name = form.Name.Split(" ")[1],
                Patron = form.Name.Split(" ").LastOrDefault(),
                BirthDate = DateOnly.Parse(form.Birthday),
                IT_Experience = form.IT_Experience,
                Email = form.Email
                //CreatedAt = DateTime.Now,
            };
        }

        return new Request
        {
            Id = Guid.NewGuid(),
            Email = form.Email,
            Phone = form.Phone,
            EducationProgramId = educationProgramRepository.Get().Result.FirstOrDefault(x => x.Name == form.Education)?.Id,
            StudentId = student?.Id
        };
    }
}