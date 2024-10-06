using Students.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Students.APIServer.DTO
{
    /// <summary>
    /// DTO заявок на страницу заявок
    /// </summary>
    public class RequestsDTO
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public required string StudentFullName {  get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// Адрес, по хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003
        /// экспорт из заявки
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Уровень образования
        /// экспорт из заявки,хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
        /// </summary>
        public string? TypeEducation { get; set; }

        /// <summary>
        /// Уровень образования
        /// экспорт из заявки,хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
        /// </summary>

        public Guid? TypeEducationId { get; set; }

        // <summary>
        /// Электронный адрес
        /// экспорт из заявки
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Id заявки, Как буд-то тут перебор необходимых данных
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Id Персона
        /// экспорт из заявки
        /// </summary>
        public Guid? StudentId { get; set; }

        /// <summary>
        ///  Id образовательной программы 
        /// </summary>
        public Guid?  EducationProgramId { get; set; }
        /// <summary>
        /// Образовательная программа
        /// </summary>
        public string? EducationProgram { get; set; }

        /// <summary>
    /// Статус заявки
    /// </summary>
        public string? StatusRequest { get; set; }

        /// <summary>
        /// Идентификатор статуса студента
        /// </summary>
        public Guid? StatusRequestId { get; set; }

    }
}
