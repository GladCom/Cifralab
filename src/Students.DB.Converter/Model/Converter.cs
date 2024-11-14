using System.Collections.ObjectModel;
using System.Windows;
using ClosedXML.Excel;
using NLog;
using Students.DB.Converter.Services;

namespace Students.DB.Converter.Model;

/// <summary>
/// Конвертер.
/// </summary>
public static class Converter
{
  #region 

  /// <summary>
  /// Логгер.
  /// </summary>
  private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

  #endregion Поля и свойства

  #region Методы

  /// <summary>
  /// Загрузить данные из файла эксель, выгруженные из тильды.
  /// </summary>
  /// <param name="filename">Имя файла.</param>
  /// <param name="page">Страница с данными тильды.</param>
  /// <param name="list">Загруженные данные.</param>
  private static void LoadInformationFromTilda(string filename, Page page, in ObservableCollection<StudentWithRequest> list)
  {
    // Открываем книгу
    using var workbook = new XLWorkbook(filename);
    var worksheet = workbook.Worksheets.Worksheet(page.Id);
    var rowCount = worksheet.RowsUsed().Count();

    // Перебираем диапазон нужных строк
    for(var row = 2; row <= rowCount; ++row)
    {
      // По каждой строке формируем объект
      var request = new StudentWithRequest
      {
        Family = worksheet.Cell(row, 2).GetValue<string>(),
        Name = worksheet.Cell(row, 3).GetValue<string>(),
        Patron = worksheet.Cell(row, 4).GetValue<string>(),
        BirthDate = worksheet.Cell(row, 5).GetValue<string>(),
        TypeEducation = worksheet.Cell(row, 6).GetValue<string>(),
        ItExperience = worksheet.Cell(row, 8).GetValue<string>(),
        Address = worksheet.Cell(row, 9).GetValue<string>(),
        Phone = worksheet.Cell(row, 10).GetValue<string>(),
        Email = worksheet.Cell(row, 11).GetValue<string>(),
        DateCreateRequest = worksheet.Cell(row, 16).GetValue<string>(),
        AgeCreateRequest = worksheet.Cell(row, 18).GetValue<string>(),
        StudentStatus = worksheet.Cell(row, 19).GetValue<string>(),
        StatusEntranceExams = worksheet.Cell(row, 20).GetValue<string>(),
        RequestStatus = worksheet.Cell(row, 21).GetValue<string>(),
        EducationProgram = worksheet.Cell(row, 22).GetValue<string>()
      };
      // И возвращаем его
      list.Add(request);
    }
  }

  /// <summary>
  /// Дополнить данные из тильды данными, введенными вручную в файл эксель.
  /// </summary>
  /// <param name="filename">Имя файла.</param>
  /// <param name="page">Страница с дополненными вручную данными.</param>
  /// <param name="list">Загруженные данные.</param>
  private static void LoadAdditionalInformation(string filename, Page page, in ObservableCollection<StudentWithRequest> list)
  {
    // Открываем книгу
    using var workbook = new XLWorkbook(filename);
    var worksheet = workbook.Worksheets.Worksheet(page.Id);
    var rowCount = worksheet.RowsUsed().Count();

    // Перебираем диапазон нужных строк
    for(var row = 2; row <= rowCount; ++row)
    {
      var family = worksheet.Cell(row, 3).GetValue<string>();
      var name = worksheet.Cell(row, 4).GetValue<string>();
      var patron = worksheet.Cell(row, 5).GetValue<string>();
      var birthDate = worksheet.Cell(row, 6).GetValue<string>();

      var item = list.FirstOrDefault(e => string.Equals(e.Name?.Trim(), name.Trim(), StringComparison.CurrentCultureIgnoreCase)
                                          && string.Equals(e.Family?.Trim(), family.Trim(), StringComparison.CurrentCultureIgnoreCase)
                                          && string.Equals(e.Patron?.Trim(), patron.Trim(), StringComparison.CurrentCultureIgnoreCase)
                                          && e.BirthDate?.Trim() == birthDate.Trim());

      if(item is not null)
      {
        item.StudentStatus = worksheet.Cell(row, 2).GetValue<string>();
        item.Sex = worksheet.Cell(row, 8).GetValue<string>();
        item.Snils = worksheet.Cell(row, 9).GetValue<string>();
        item.TypeEducation = worksheet.Cell(row, 10).GetValue<string>();
        item.FullNameDocument = worksheet.Cell(row, 11).GetValue<string>();
        item.DocumentSeries = worksheet.Cell(row, 12).GetValue<string>();
        item.DocumentNumber = worksheet.Cell(row, 13).GetValue<string>();
        item.Nationality = worksheet.Cell(row, 14).GetValue<string>();
        item.EducationProgram = worksheet.Cell(row, 15).GetValue<string>();
        item.HoursCount = worksheet.Cell(row, 16).GetValue<string>();
        item.StartDate = worksheet.Cell(row, 17).GetValue<string>();
        item.EndDate = worksheet.Cell(row, 18).GetValue<string>();
        item.EducationForm = worksheet.Cell(row, 19).GetValue<string>();
        item.FinancingType = worksheet.Cell(row, 20).GetValue<string>();
        item.DataNumberDogovor = worksheet.Cell(row, 21).GetValue<string>();
        item.GroupName = worksheet.Cell(row, 22).GetValue<string>();
        item.Cost = worksheet.Cell(row, 23).GetValue<string>();
        item.EnrollmentOrder = worksheet.Cell(row, 24).GetValue<string>();
        item.ExpulsionOrder = worksheet.Cell(row, 25).GetValue<string>();
        item.DocumentRiseQualificationType = worksheet.Cell(row, 26).GetValue<string>();
        item.DocumentRiseQualificationNumber = worksheet.Cell(row, 27).GetValue<string>();
        item.DocumentRiseQualificationDate = worksheet.Cell(row, 28).GetValue<string>();
        item.DocumentRiseQualificationRegistrationNumber = worksheet.Cell(row, 29).GetValue<string>();
        item.IsNetworkProgram = worksheet.Cell(row, 30).GetValue<string>();
        item.IsDotProgram = worksheet.Cell(row, 32).GetValue<string>();
        item.IsFullDotProgram = worksheet.Cell(row, 33).GetValue<string>();
        item.IsModularProgram = worksheet.Cell(row, 34).GetValue<string>();
        item.ScopeOfActivityLevelOne = worksheet.Cell(row, 35).GetValue<string>();
        item.ScopeOfActivityLevelTwo = worksheet.Cell(row, 36).GetValue<string>();
        item.FeaProgram = worksheet.Cell(row, 37).GetValue<string>();
        item.Disability = worksheet.Cell(row, 38).GetValue<string>();
      }
      else
      {
        // По каждой строке формируем объект
        var request = new StudentWithRequest
        {
          StudentStatus = worksheet.Cell(row, 2).GetValue<string>(),
          Family = family,
          Name = name,
          Patron = patron,
          BirthDate = birthDate,
          Sex = worksheet.Cell(row, 8).GetValue<string>(),
          Snils = worksheet.Cell(row, 9).GetValue<string>(),
          TypeEducation = worksheet.Cell(row, 10).GetValue<string>(),
          FullNameDocument = worksheet.Cell(row, 11).GetValue<string>(),
          DocumentSeries = worksheet.Cell(row, 12).GetValue<string>(),
          DocumentNumber = worksheet.Cell(row, 13).GetValue<string>(),
          Nationality = worksheet.Cell(row, 14).GetValue<string>(),
          EducationProgram = worksheet.Cell(row, 15).GetValue<string>(),
          HoursCount = worksheet.Cell(row, 16).GetValue<string>(),
          StartDate = worksheet.Cell(row, 17).GetValue<string>(),
          EndDate = worksheet.Cell(row, 18).GetValue<string>(),
          EducationForm = worksheet.Cell(row, 19).GetValue<string>(),
          FinancingType = worksheet.Cell(row, 20).GetValue<string>(),
          DataNumberDogovor = worksheet.Cell(row, 21).GetValue<string>(),
          GroupName = worksheet.Cell(row, 22).GetValue<string>(),
          Cost = worksheet.Cell(row, 23).GetValue<string>(),
          EnrollmentOrder = worksheet.Cell(row, 24).GetValue<string>(),
          ExpulsionOrder = worksheet.Cell(row, 25).GetValue<string>(),
          DocumentRiseQualificationType = worksheet.Cell(row, 26).GetValue<string>(),
          DocumentRiseQualificationNumber = worksheet.Cell(row, 27).GetValue<string>(),
          DocumentRiseQualificationDate = worksheet.Cell(row, 28).GetValue<string>(),
          DocumentRiseQualificationRegistrationNumber = worksheet.Cell(row, 29).GetValue<string>(),
          IsNetworkProgram = worksheet.Cell(row, 30).GetValue<string>(),
          IsDotProgram = worksheet.Cell(row, 32).GetValue<string>(),
          IsFullDotProgram = worksheet.Cell(row, 33).GetValue<string>(),
          IsModularProgram = worksheet.Cell(row, 34).GetValue<string>(),
          ScopeOfActivityLevelOne = worksheet.Cell(row, 35).GetValue<string>(),
          ScopeOfActivityLevelTwo = worksheet.Cell(row, 36).GetValue<string>(),
          FeaProgram = worksheet.Cell(row, 37).GetValue<string>(),
          Disability = worksheet.Cell(row, 38).GetValue<string>()
        };
        // И возвращаем его
        list.Add(request);
      }
    }
  }

  /// <summary>
  /// Загрузить данные из файла эксель, выгруженные из Excel 
  /// (со страницы тильды  и страницы с данными, введенными вручную).
  /// </summary>
  /// <param name="filename">Имя файла.</param>
  /// <param name="tildaPage">Страница с данными тильды.</param>
  /// <param name="dbPage">Страница с данными, заполненными вручную.</param>
  /// <param name="list">Загруженные данные.</param>
  public static void LoadInformation(string filename, Page? tildaPage, Page? dbPage, in ObservableCollection<StudentWithRequest> list)
  {
    list.Clear();

    if(tildaPage is not null)
      LoadInformationFromTilda(filename, tildaPage, list);

    if(dbPage is not null)
      LoadAdditionalInformation(filename, dbPage, list);
  }

  /// <summary>
  /// Загрузить список страниц из файла.
  /// </summary>
  /// <param name="filename">Имя файла.</param>
  /// <param name="pages">Список страниц.</param>
  public static void LoadPagesFromExcelFile(string filename, in ObservableCollection<Page> pages)
  {
    pages.Clear();

    // Открываем книгу
    using var workbook = new XLWorkbook(filename);
    var i = 1;
    foreach(var page in workbook.Worksheets.Select(item => new Page(i++, item.Name)))
    {
      pages.Add(page);
    }
  }

  /// <summary>
  /// Сохранить в БД.
  /// </summary>
  /// <param name="listRequest">Список записей из эксель.</param>
  /// <param name="messages">Сообщения с результатом записи в БД.</param>
  public static void SaveToDb(in ObservableCollection<StudentWithRequest> listRequest, in ObservableCollection<ConvertInformation> messages)
  {
    messages.Clear();

    try
    {
      using var dbService = new DbService(Logger);
      foreach(var item in listRequest)
      {
        try
        {
          string message;
          if(dbService.FindStudentRequest(item))
          {
            message = $"Данные по заявке студента {item.MainInfo} уже присутствуют в БД. Сохранение отменено.";
          }
          else
          {
            dbService.SaveToDb(item);
            message = $"Запись по студенту {item.MainInfo} - запись  успешно обработана.";
          }
          Logger.Trace(message);
          messages.Add(new ConvertInformation(false, message));
        }
        catch(Exception ex)
        {
          var message = $"Ошибка записи по студенту {item.MainInfo}: {ex.Message}.";
          Logger.Trace(message);
          messages.Add(new ConvertInformation(true, message));
        }
      }
    }
    catch(Exception ex)
    {
      MessageBox.Show(ex.Message);
    }
  }

  #endregion
}