namespace Students.Reports.Models;

/// <summary>
///   Модель отчета (на основе таблицы слушателей).
/// </summary>
public class RosstatModel
{
    // --- Колонка 1 ---
    /// <summary>
    ///   Ф.И.О. слушателя.
    /// </summary>
    public string? FullName { get; set; }

    // --- Колонка 2 ---
    /// <summary>
    ///   Статус (Обучается, Отчислен и т.д.).
    /// </summary>
    public string? Status { get; set; }

    // --- Колонка 3 ---
    /// <summary>
    ///   Дата рождения.
    /// </summary>
    public string? BirthDate { get; set; }

    // --- Колонка 4 ---
    /// <summary>
    ///   Возраст.
    /// </summary>
    public string? Age { get; set; }

    // --- Колонка 5 ---
    /// <summary>
    ///   Пол (Муж/Жен).
    /// </summary>
    public string? Gender { get; set; }

    // --- Колонка 6 ---
    /// <summary>
    ///   Образование (Студент СПО, Высшее и т.д.).
    /// </summary>
    public string? EducationLevel { get; set; }

    // --- Колонка 7 ---
    /// <summary>
    ///   Гражданство (РФ и т.д.).
    /// </summary>
    public string? Citizenship { get; set; }

    // --- Колонка 8 ---
    /// <summary>
    ///   Наименование программы.
    /// </summary>
    public string? ProgramName { get; set; }

    // --- Колонка 9 ---
    /// <summary>
    ///   Количество часов.
    /// </summary>
    public string? HoursCount { get; set; }

    // --- Колонка 10 ---
    /// <summary>
    ///   Дата начала обучения.
    /// </summary>
    public string? StartDate { get; set; }

    // --- Колонка 11 ---
    /// <summary>
    ///   Дата окончания обучения (или отчисления).
    /// </summary>
    public string? EndDate { get; set; }

    // --- Колонка 12 ---
    /// <summary>
    ///   Форма обучения (Очная, Очно-заочная...).
    /// </summary>
    public string? StudyForm { get; set; }

    // --- Колонка 13 ---
    /// <summary>
    ///   Источник финансирования.
    /// </summary>
    public string? FundingSource { get; set; }

    // --- Колонка 14 ---
    /// <summary>
    ///   Группа.
    /// </summary>
    public string? GroupName { get; set; }

    // --- Колонка 15 ---
    /// <summary>
    ///   Вид выданного документа о квалификации.
    /// </summary>
    public string? DocumentType { get; set; }

    // --- Колонка 16 ---
    /// <summary>
    ///   Сетевая форма (Да/Нет).
    /// </summary>
    public string? IsNetworkForm { get; set; }

    // --- Колонка 17 ---
    /// <summary>
    ///   Применение электронного обучения (Да/Нет).
    /// </summary>
    public string? UseELearning { get; set; }

    // --- Колонка 18 ---
    /// <summary>
    ///   Применение ДОТ (Да/Нет).
    /// </summary>
    public string? UseDistanceTech { get; set; }

    // --- Колонка 19 ---
    /// <summary>
    ///   Применение ДОТ полностью (Да/Нет).
    /// </summary>
    public string? UseFullDistanceTech { get; set; }

    // --- Колонка 20 ---
    /// <summary>
    ///   Модульная программа (Да/Нет).
    /// </summary>
    public string? IsModularProgram { get; set; }

    // --- Колонка 21 ---
    /// <summary>
    ///   Сфера деятельности ур. 1.
    /// </summary>
    public string? ScopeOfActivityLevel1 { get; set; }

    // --- Колонка 22 ---
    /// <summary>
    ///   Сфера деятельности ур. 2.
    /// </summary>
    public string? ScopeOfActivityLevel2 { get; set; }

    // --- Колонка 23 ---
    /// <summary>
    ///   ВЭД программы (Деятельность в области...).
    /// </summary>
    public string? ProgramActivityArea { get; set; }

    // --- Колонка 24 ---
    /// <summary>
    ///   ОВЗ (Инвалидность) (Да/Нет).
    /// </summary>
    public string? HasDisability { get; set; }
}