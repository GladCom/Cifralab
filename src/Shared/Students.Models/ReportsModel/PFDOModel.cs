using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    /// <summary>
    /// Модель отчета.
    /// </summary>
    public class PFDOModel
    {
        //public string? TypeDocument {  get; set; }
        //public string? StatusDocument { get; set; }
        //public string? ConfirmationLoss { get; set; }
        //public string? ConfirmationExchange { get; set; }
        //public string? ConfirmationDestruction { get; set; }
        //public string? SeriesDocuments { get; set; }
        //public string? DocumentNumber { get; set; }
        //public string? DateOfIssueDocument { get; set; }
        //public string? RegistrationNumber { get; set; }
        //public string? AdditionalProfessionalProgram { get; set; }
        //public string? NameAdditionalProfessionalProgram { get; set; }
        //public string? NameFieldProfessionalActivity { get; set; }
        //public string? EnlargedGroupsSpecialties { get; set; }
        //public string? NameQualification { get; set; }
        //public string? LevelEducationHE { get; set; }
        //public string? SurnameIndicatedHE { get; set; }
        //public string? SeriesHE { get; set; }
        //public string? NumberHE { get; set; }
        //public string? YearBeginningTraining { get; set; }
        //public string? YearGraduation { get; set; }
        //public string? DurationTraining { get; set; }

        /// <summary>
        /// Фамилия получателя.
        /// </summary>
        [Column("Фамилия получателя")]
        public string? RecipientLastName { get; set; }

        /// <summary>
        /// Имя получателя.
        /// </summary>
        [Column("Имя получателя")]
        public string? RecipientName { get; set; }

        /// <summary>
        /// Отчество получателя.
        /// </summary>
        [Column("Отчество получателя")]
        public string? RecipientPatronymic { get; set; }

        /// <summary>
        /// Дата рождения получателя.
        /// </summary>
        [Column("Дата рождения получателя")]
        public DateOnly RecipientDateBirth { get; set; }

        //public string? RecipientGender { get; set; }
        //public string? SNILS { get; set; }
        //public string? FormEducation { get; set; }
        //public string? SourceFundingForTraining { get; set; }
        //public string? FormEducationAtTimeTerminationEducation { get; set; }
        //public string? RecipientCitizenship { get; set; }
        //public string? NameDocumentEducationOriginalDocument { get; set; }
        //public string? SeriesOriginalDocument { get; set; }
        //public string? NumberOriginalDocument { get; set; }
        //public string? RegistrationNumberOriginalDocument { get; set; }
        //public string? DateIssueOriginalDocument { get; set; }
        //public string? RecipientLastNameOriginalDocument { get; set; }
        //public string? RecipientNameOriginalDocument { get; set; }
        //public string? RecipientPatronymicOriginalDocument { get; set; }
        //public string? NumberDocumentToChange { get; set; }
    }
}
