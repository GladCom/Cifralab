namespace Students.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public enum StatusRequest
{
	/// <summary>
	/// Заявка
	/// </summary>
	Request,
	/// <summary>
	/// обучается
	/// </summary>
	Studing,
    /// <summary>
    /// Отчислен досрочно
    /// </summary>
    ExpelledEarly,
    /// <summary>
    /// завершил обучение
    /// </summary>
    CompletedTraining,
    /// <summary>
    /// не соответсвует требованиям
    /// </summary>
    DoesNotMeetConditions,
    /// <summary>
    /// дубликат для формироваия рассылок
    /// </summary>
    DublicateForGeneratingMailings
}
