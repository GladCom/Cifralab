namespace Students.Models
{
    /// <summary>
    /// Модель отчета.
    /// </summary>
    public class FRDOModel
    {
        /// <summary>
        /// Имя получателя.
        /// </summary>
        public string? TypeDocument { get; set; }

        /// <summary>
        /// Статус документа.
        /// </summary>
        public string? StatusDocument { get; set; }

        /// <summary>
        /// Подтверждение утраты.
        /// </summary>
        public string? ConfirmationLoss { get; set; }

        /// <summary>
        /// Подтверждение обмена.
        /// </summary>
        public string? ConfirmationExchange { get; set; }

        /// <summary>
        /// Подтверждение уничтожения.
        /// </summary>
        public string? ConfirmationDestruction { get; set; }

        /// <summary>
        /// Серия документа.
        /// </summary>
        public string? SeriesDocuments { get; set; }

        /// <summary>
        /// Номер документа.
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа.
        /// </summary>
        public string? DateOfIssueDocument { get; set; }

        /// <summary>
        /// Регистрационный номер.
        /// </summary>
        public string? RegistrationNumber { get; set; }

        /// <summary>
        /// Дополнительная профессиональная программа (повышение квалификации/ профессиональная переподготовка).
        /// </summary>
        public string? AdditionalProfessionalProgram { get; set; }

        /// <summary>
        /// Наименование дополнительной профессиональной программы.
        /// </summary>
        public string? NameAdditionalProfessionalProgram { get; set; }

        /// <summary>
        /// Наименование области профессиональной деятельности.
        /// </summary>
        public string? NameFieldProfessionalActivity { get; set; }

        /// <summary>
        /// Укрупненные группы специальностей.
        /// </summary>
        public string? EnlargedGroupsSpecialties { get; set; }

        /// <summary>
        /// Наименование  квалификации, профессии, специальности.
        /// </summary>
        public string? NameQualification { get; set; }

        /// <summary>
        /// Уровень образования ВО/СПО.
        /// </summary>
        public string? LevelEducationHE { get; set; }

        /// <summary>
        /// Фамилия указанная в дипломе о ВО или СПО.
        /// </summary>
        public string? SurnameIndicatedHE { get; set; }

        /// <summary>
        /// Серия документа о ВО/СПО.
        /// </summary>
        public string? SeriesHE { get; set; }

        /// <summary>
        /// Номер документа о ВО/СПО.
        /// </summary>
        public string? NumberHE { get; set; }

        /// <summary>
        /// Год начала обучения (для документа о квалификации).
        /// </summary>
        public string? YearBeginningTraining { get; set; }

        /// <summary>
        /// Год окончания обучения (для документа о квалификации).
        /// </summary>
        public string? YearGraduation { get; set; }

        /// <summary>
        /// Срок обучения,часов  (для документа о квалификации).
        /// </summary>
        public string? DurationTraining { get; set; }

        /// <summary>
        /// Фамилия получателя.
        /// </summary>
        public string? RecipientLastName { get; set; }

        /// <summary>
        /// Имя получателя.
        /// </summary>
        public string? RecipientName { get; set; }

        /// <summary>
        /// Отчество получателя.
        /// </summary>
        public string? RecipientPatronymic { get; set; }

        /// <summary>
        /// Дата рождения получателя.
        /// </summary>
        public DateOnly RecipientDateBirth { get; set; }

        /// <summary>
        /// Пол получателя.
        /// </summary>
        public string? RecipientGender { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        public string? RecipientSNILS { get; set; }

        /// <summary>
        /// Форма обучения.
        /// </summary>
        public string? FormEducation { get; set; }

        /// <summary>
        /// Источник финансирования обучения.
        /// </summary>
        public string? SourceFundingForTraining { get; set; }

        /// <summary>
        /// Форма получения образования на момент прекращения образовательных отношений.
        /// </summary>
        public string? FormEducationAtTimeTerminationEducation { get; set; }

        /// <summary>
        /// Гражданство получателя (код страны по ОКСМ).
        /// </summary>
        public string? RecipientCitizenship { get; set; }

        /// <summary>
        /// Наименование документа об образовании (оригинала).
        /// </summary>
        public string? NameDocumentEducationOriginalDocument { get; set; }

        /// <summary>
        /// Серия (оригинала).
        /// </summary>
        public string? SeriesOriginalDocument { get; set; }

        /// <summary>
        /// Номер (оригинала).
        /// </summary>
        public string? NumberOriginalDocument { get; set; }

        /// <summary>
        /// Регистрационный N (оригинала).
        /// </summary>
        public string? RegistrationNumberOriginalDocument { get; set; }

        /// <summary>
        /// Дата выдачи (оригинала).
        /// </summary>
        public string? DateIssueOriginalDocument { get; set; }

        /// <summary>
        /// Фамилия получателя (оригинала).
        /// </summary>
        public string? RecipientLastNameOriginalDocument { get; set; }

        /// <summary>
        /// Имя получателя (оригинала).
        /// </summary>
        public string? RecipientNameOriginalDocument { get; set; }

        /// <summary>
        /// Отчество получателя (оригинала).
        /// </summary>
        public string? RecipientPatronymicOriginalDocument { get; set; }

        /// <summary>
        /// Номер документа для изменения.
        /// </summary>
        public string? NumberDocumentToChange { get; set; }
    }
}
