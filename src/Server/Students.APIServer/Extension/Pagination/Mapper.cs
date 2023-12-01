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
    public static Request WebhookToRequest(RequestWebhook form)
    {
        return new Request
        {
            Id = Guid.NewGuid(),
           FullName = form.Name,
            Email = form.Email,
            Phone = form.Phone,
            CreatedAt = DateTime.Now,
            BirthDate = DateOnly.Parse(form.Birthday),
            JobCV = form.IT_Experience,
            Address = form.Address,
            // TODO: Необходим поиск по типу образования
            StudentEducationId = form.EducationLevel switch
            {
                "Высшее образование" => new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
                "Среднее профессиональное образование" => new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                _ => throw new ArgumentException("Неверный уровень образования")
            },
            
            
            
        };
    }
}