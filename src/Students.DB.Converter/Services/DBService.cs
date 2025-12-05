using Microsoft.EntityFrameworkCore;
using NLog;
using Students.DB.Converter.DBContext;
using Students.DB.Converter.Model;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.DB.Converter.Services;

/// <summary>
/// Сервис для работы с БД.
/// </summary>
public class DbService : IDisposable
{
  #region Поля и свойства

  /// <summary>
  /// Контекст БД.
  /// </summary>
  private readonly PgContext _pgContext;

  /// <summary>
  /// Логгер.
  /// </summary>
  private readonly ILogger _logger;

  #endregion

  #region IDisposable

  public void Dispose()
  {
    this._pgContext.Dispose();
  }

  #endregion

  #region Методы

  /// <summary>
  /// Найти статус заявки в справочнике заявок по наименованию статуса.
  /// </summary>
  /// <param name="name">Наименование статуса заявки.</param>
  /// <returns>Идентификатор найденного статуса заявки.</returns>
  private Guid? FindStatusRequest(string name)
  {
    name = name.Trim().ToLower();
    if(name == string.Empty)
    {
      return null;
    }
    var statusRequest = this._pgContext.StatusRequests.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == name);
    return statusRequest?.Id;
  }

  /// <summary>
  /// Найти программу обучения в справочнике по наименованию.
  /// </summary>
  /// <param name="name">Наименование программы обучения.</param>
  /// <returns>Идентификатор найденной программы обучения.</returns>
  private Guid? FindEducationProgram(string name)
  {
    name = name.Trim().ToLower();
    if(name == string.Empty)
    {
      return null;
    }
    var educationProgram = this._pgContext.EducationPrograms.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == name);
    return educationProgram?.Id;
  }

  /// <summary>
  /// Найти заявку по идентификатору студента.
  /// </summary>
  /// <param name="studentId">Идентификатор студента</param>
  /// <returns></returns>
  private bool FindRequestByStudentId(Guid studentId)
  {
    return this._pgContext.Requests.Any(e => e.StudentId == studentId);
  }

  #region Получение справочных данных (сохранение при остутствии в справочнике).

  /// <summary>
  /// Сохранить ВЭД программу, если ее нет в БД.
  /// </summary>
  /// <param name="nameFeaProgram">ВЭД программа.</param>
  /// <returns>Идентификатор ВЭД программы.</returns>
  private Guid? SaveFeaProgramToDb(string? nameFeaProgram)
  {
    if(string.IsNullOrEmpty(nameFeaProgram))
    {
      return null;
    }
    nameFeaProgram = nameFeaProgram.Trim().ToLower();

    var feaProgram = this._pgContext.FEAPrograms.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == nameFeaProgram);

    if(feaProgram is not null)
    {
      this._logger.Trace($"Найдена ВЭД программа по наименованию '{nameFeaProgram}': id={feaProgram.Id}.");
    }
    else
    {
      feaProgram = new FEAProgram
      {
        Id = Guid.NewGuid(),
        Name = nameFeaProgram
      };
      this._pgContext.FEAPrograms.Add(feaProgram);
      this._logger.Trace($"Создана ВЭД программы '{nameFeaProgram}': id='{feaProgram.Id}'.");
    }
    return feaProgram.Id;
  }

  /// <summary>
  /// Сохранить тип финансирования, если его нет в БД.
  /// </summary>
  /// <param name="nameFinancingType">Тип финансирования.</param>
  /// <returns>Идентификатор типа финансирования.</returns>
  /// <exception cref="Exception">Исключение возникает, если не задан тип финансирования программы.</exception>
  private Guid SaveFinancingTypeToDb(string nameFinancingType)
  {
    if(string.IsNullOrEmpty(nameFinancingType))
    {
      throw new Exception("Не задан тип финансирования программы.");
    }
    nameFinancingType = nameFinancingType.Trim().ToLower();

    var financingType = this._pgContext.FinancingTypes.FirstOrDefault(e => e.SourceName != null && e.SourceName.ToLower().Trim() == nameFinancingType);

    if(financingType is not null)
    {
      this._logger.Trace($"Найден тип финансирования по наименованию '{nameFinancingType}': id={financingType.Id}.");
    }
    else
    {
      financingType = new FinancingType
      {
        Id = Guid.NewGuid(),
        SourceName = nameFinancingType
      };
      this._pgContext.FinancingTypes.Add(financingType);
      this._logger.Trace($"Создан тип финансирования '{nameFinancingType}': id='{financingType.Id}'.");
    }
    return financingType.Id;
  }

  /// <summary>
  /// Сохранить форму обучения, если ее нет в БД.
  /// </summary>
  /// <param name="nameEducationForm">Форма обучения.</param>
  /// <returns>Идентификатор формы обучения.</returns>
  /// <exception cref="Exception">Исключение возникает, если не задана форма обучения.</exception>
  private Guid SaveEducationFormToDb(string nameEducationForm)
  {
    if(string.IsNullOrEmpty(nameEducationForm))
    {
      throw new Exception("Не задана форма обучения.");
    }
    nameEducationForm = nameEducationForm.Trim().ToLower();

    var educationForm = this._pgContext.EducationForms.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == nameEducationForm);

    if(educationForm is not null)
    {
      this._logger.Trace($"Найдена форма обучения по наименованию '{nameEducationForm}': id={educationForm.Id}.");
      return educationForm.Id;
    }
    else
    {
      educationForm = new EducationForm
      {
        Id = Guid.NewGuid(),
        Name = nameEducationForm
      };
      this._pgContext.EducationForms.Add(educationForm);
      this._logger.Trace($"Создана форма обучения '{nameEducationForm}': id='{educationForm.Id}'.");
      return educationForm.Id;
    }
  }

  /// <summary>
  /// Сохранить статус заявки, если его нет в БД.
  /// </summary>
  /// <param name="nameStatusRequest">Статус заявки.</param>
  /// <returns>Идентификатор статуса заявки.</returns>
  private Guid? SaveRequestStatusToDb(string nameStatusRequest)
  {
    nameStatusRequest = nameStatusRequest.Trim().ToLower();
    if(nameStatusRequest == string.Empty)
    {
      return null;
    }

    var statusRequest = this._pgContext.StatusRequests.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == nameStatusRequest);

    if(statusRequest is not null)
    {
      this._logger.Trace($"Найден статус заявки по наименованию '{nameStatusRequest}': id={statusRequest.Id}.");
      return statusRequest.Id;
    }
    else
    {
      statusRequest = new StatusRequest
      {
        Id = Guid.NewGuid(),
        Name = nameStatusRequest
      };
      this._pgContext.StatusRequests.Add(statusRequest);
      this._logger.Trace($"Создан статус заявки '{nameStatusRequest}': id='{statusRequest.Id}'.");
      return statusRequest.Id;
    }
  }

  /// <summary>
  /// Сохранить статус студента, если его нет в БД.
  /// </summary>
  /// <param name="nameStudentStatus">Статус студента.</param>
  /// <returns>Идентификатор статуса студента.</returns>
  private Guid? SaveStudentStatusToDb(string nameStudentStatus)
  {
    nameStudentStatus = nameStudentStatus.Trim().ToLower();
    if(nameStudentStatus == string.Empty)
    {
      return null;
    }

    var studentStatus = this._pgContext.StudentStatuses.FirstOrDefault(e => e.Name.ToLower().Trim() == nameStudentStatus);

    if(studentStatus is not null)
    {
      this._logger.Trace($"Найден статус студента по наименованию '{nameStudentStatus}': id={studentStatus.Id}.");
    }
    else
    {
      studentStatus = new StudentStatus
      {
        Id = Guid.NewGuid(),
        Name = nameStudentStatus
      };
      this._pgContext.StudentStatuses.Add(studentStatus);
      this._logger.Trace($"Создан статус студента '{nameStudentStatus}': id='{studentStatus.Id}'.");
    }
    return studentStatus.Id;
  }

  /// <summary>
  /// Сохранить уровень образования, если его нет в БД.
  /// </summary>
  /// <param name="nameTypeEducation">Уровень образования.</param>
  /// <returns>Идентификатор уровня образования.</returns>
  /// <exception cref="Exception">Исключение возникает, если не задан уровень образования.</exception>
  private Guid SaveTypeEducationToDb(string nameTypeEducation)
  {
    nameTypeEducation = nameTypeEducation.Trim().ToLower();
    if(nameTypeEducation == string.Empty)
    {
      throw new Exception("Не задан уровень образования.");
    }

    var typeEducation = this._pgContext.TypeEducation.FirstOrDefault(e => e.Name.ToLower().Trim() == nameTypeEducation);

    if(typeEducation is not null)
    {
      this._logger.Trace($"Найден уровень образования по наименованию '{nameTypeEducation}': id={typeEducation.Id}.");
    }
    else
    {
      typeEducation = new TypeEducation
      {
        Id = Guid.NewGuid(),
        Name = nameTypeEducation
      };
      this._pgContext.TypeEducation.Add(typeEducation);
      this._logger.Trace($"Создан уровень образования '{nameTypeEducation}': id='{typeEducation.Id}'.");
    }
    return typeEducation.Id;
  }

  /// <summary>
  /// Сохранить вид документа повышения квалификации, если его нет в БД.
  /// </summary>
  /// <param name="nameKindDocumentRiseQualification">Вид документа повышения квалификации.</param>
  /// <returns>Идентификатор вида документа повышения квалификации.</returns>
  private Guid? SaveKindDocumentRiseQualificationToDb(string? nameKindDocumentRiseQualification)
  {
    if(nameKindDocumentRiseQualification is null)
    {
      return null;
    }
    nameKindDocumentRiseQualification = nameKindDocumentRiseQualification.Trim().ToLower();
    if(nameKindDocumentRiseQualification is "" or "-")
    {
      return null;
    }

    var kindDocumentRiseQualification = this._pgContext.KindDocumentRiseQualifications
      .FirstOrDefault(e => e.Name.ToLower().Trim() == nameKindDocumentRiseQualification);

    if(kindDocumentRiseQualification is not null)
    {
      this._logger.Trace($"Найден вид документа повышения квалификации по наименованию '{nameKindDocumentRiseQualification}': id={kindDocumentRiseQualification.Id}.");
      return kindDocumentRiseQualification.Id;
    }
    else
    {
      kindDocumentRiseQualification = new KindDocumentRiseQualification
      {
        Id = Guid.NewGuid(),
        Name = nameKindDocumentRiseQualification
      };
      this._pgContext.KindDocumentRiseQualifications.Add(kindDocumentRiseQualification);
      this._logger.Trace($"Создан вид документа повышения квалификации '{nameKindDocumentRiseQualification}': id='{kindDocumentRiseQualification.Id}'.");
      return kindDocumentRiseQualification.Id;
    }
  }

  /// <summary>
  /// Сохранить вид документа повышения квалификации, если его нет в БД.
  /// </summary>
  /// <param name="nameKindDocumentRiseQualification">Вид документа повышения квалификации.</param>
  /// <returns>Идентификатор вида документа повышения квалификации.</returns>
  private Guid? SaveKindEducationProgramToDb(string? nameKindEducationProgram)
  {
    if(nameKindEducationProgram is null)
    {
      return null;
    }
    nameKindEducationProgram = nameKindEducationProgram.Trim().ToLower();
    if(nameKindEducationProgram is "" or "-")
    {
      return null;
    }

    var kindEducationProgram = this._pgContext.KindEducationPrograms
      .FirstOrDefault(e => e.Name.ToLower().Trim() == nameKindEducationProgram);

    if(kindEducationProgram is not null)
    {
      this._logger.Trace($"Найден вид документа повышения квалификации по наименованию '{nameKindEducationProgram}': id={kindEducationProgram.Id}.");
      return kindEducationProgram.Id;
    }
    else
    {
      kindEducationProgram = new KindEducationProgram
      {
        Id = Guid.NewGuid(),
        Name = nameKindEducationProgram
      };
      this._pgContext.KindEducationPrograms.Add(kindEducationProgram);
      this._logger.Trace($"Создан вид документа повышения квалификации '{nameKindEducationProgram}': id='{kindEducationProgram.Id}'.");
      return kindEducationProgram.Id;
    }
  }

  /// <summary>
  /// Сохранить сферу деятельности, если ее нет в БД.
  /// </summary>
  /// <param name="item">Сфера деятельности.</param>
  /// <param name="level">Уровень.</param>
  /// <returns>Идентификатор сферы деятельности.</returns>
  /// <exception cref="Exception">Исключение возникает, если не указана сфера деятельности 1 ур.</exception>
  private Guid? SaveScopeOfActivityToDb(StudentWithRequest item, ScopeOfActivityLevel level)
  {
    switch(level)
    {
      case ScopeOfActivityLevel.Level1 when item.ScopeOfActivityLevelOne is null || item.ScopeOfActivityLevelOne.Trim() == string.Empty:
        throw new Exception("Не указана сфера деятельности 1 ур.");
      case ScopeOfActivityLevel.Level2 when item.ScopeOfActivityLevelTwo is null || item.ScopeOfActivityLevelTwo.Trim() == string.Empty:
        return null;
    }

    var nameScopeOfActivity = level == ScopeOfActivityLevel.Level1 ?
      item.ScopeOfActivityLevelOne?.Trim().ToLower() :
      item.ScopeOfActivityLevelTwo?.Trim().ToLower();

    var scopeOfActivity = this._pgContext.ScopesOfActivity
      .FirstOrDefault(e => e.NameOfScope != null && e.NameOfScope.ToLower().Trim() == nameScopeOfActivity
                                                 && e.Level == level);

    if(scopeOfActivity is not null)
    {
      this._logger.Trace($"Найдена сфера деятельности по наименованию '{nameScopeOfActivity}': id={scopeOfActivity.Id}.");
      return scopeOfActivity.Id;
    }

    scopeOfActivity = new ScopeOfActivity
    {
      Id = Guid.NewGuid(),
      NameOfScope = item.ScopeOfActivityLevelOne,
      Level = level
    };
    this._pgContext.ScopesOfActivity.Add(scopeOfActivity);
    this._logger.Trace($"Создана сфера деятельности '{nameScopeOfActivity}': id={scopeOfActivity.Id}.");
    return scopeOfActivity.Id;
  }

  #endregion

  /// <summary>
  /// Преобразовать строку в bool.
  /// </summary>
  /// <param name="str">Строка.</param>
  /// <returns>Булево значение.</returns>
  /// <exception cref="Exception">Исключение возникает, если не удалось преобразовать значение.</exception>
  private static bool StringToBool(string? str)
  {
    str = str?.Trim().ToLower();
    return str switch
    {
      "true" or "да" or "1" => true,
      "false" or "нет" or "0" => false,
      _ => throw new Exception($"Ошибка преобразования значения '{str}' в bool.")
    };
  }

  /// <summary>
  /// Сохранить программу обучения, если она не найдена в БД.
  /// (понять откуда записывать IsCollegeProgram, 
  /// IsArchive -записываю false так как нет данных,
  /// KindDocumentRiseQualificationId - вид документа повышения квалификации - если нет записи в экселе по полученному документу, 
  /// то информации по виду документа нет, 
  /// поэтому записываю по умолчанию "Удостоверение о повышении квалификации", так как это свойство обязательно к заполнению у программы обучения)
  /// Так как документ по умолчанию "Удостоверение о повышении квалификации" ти программы по умолчанию - "Программа повышения квалификации"
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="educationFormId">Идентификатор формы обучения.</param>
  /// <param name="kindDocumentRiseQualificationId">Идентификатор вида документа повышения квалификации.</param>
  /// <param name="kindEducationProgramId">Тип образовательной программы.</param>
  /// <param name="feaProgramId">Идентификатор ВЭД программы.</param>
  /// <param name="financingTypeId">Идентификатор типа финансирования.</param>
  /// <returns>Идентификатор программы обучения.</returns>
  /// <exception cref="Exception">Исключение возникает, если возникла ошибка преобразования значения стоимости программы обучения
  /// или количества часов программы обучения в числовой тип.</exception>
  private Guid? SaveEducationProgramToDb(StudentWithRequest item,
    Guid educationFormId,
    Guid? kindDocumentRiseQualificationId,
    Guid? kindEducationProgramId,
    Guid? feaProgramId,
    Guid financingTypeId)
  {
    var nameEducationProgram = item.EducationProgram?.Trim().ToLower();
    if(string.IsNullOrEmpty(nameEducationProgram))
    {
      return null;
    }
    if(!double.TryParse(item.Cost, out var cost))
    {
      cost = item.Cost is null || item.Cost.Trim() == string.Empty || item.Cost.Trim() == "-"
        ? 0
        : throw new Exception($"Ошибка преобразования значения стоимости программы обучения '{item.Cost}' в числовой тип.");
    }
    if(!int.TryParse(item.HoursCount, out var hoursCount))
    {
      throw new Exception($"Ошибка преобразования количества часов программы обучения '{item.HoursCount}' в числовой тип.");
    }

    kindDocumentRiseQualificationId ??= this.SaveKindDocumentRiseQualificationToDb("Удостоверение о повышении квалификации");
    if(kindDocumentRiseQualificationId is null)
    {
      throw new Exception("Ошибка записи типа документа о повышении квалификации.");
    }

    kindEducationProgramId ??=
      this._pgContext.KindEducationPrograms
        .FirstOrDefault(k => k.Name.Contains("Программа повышения квалификации"))?
        .Id;
    if (kindEducationProgramId is null)
      throw new ArgumentException("Не удалось заполнить тип образовательной программы");

    var educationProgram = this._pgContext.EducationPrograms.FirstOrDefault(e => e.Name != null && e.Name.ToLower().Trim() == nameEducationProgram);
    

    if(educationProgram is not null)
    {
      this._logger.Trace($"Найдена программа обучения по наименованию '{nameEducationProgram}': id={educationProgram.Id}.");
    }
    else
    {
      educationProgram = new EducationProgram
      {
        Id = Guid.NewGuid(),
        Name = item.EducationProgram,
        Cost = cost,
        HoursCount = hoursCount,
        EducationFormId = educationFormId,
        KindDocumentRiseQualificationId = kindDocumentRiseQualificationId.Value,
        KindEducationProgramId = kindEducationProgramId.Value,
        IsModularProgram = StringToBool(item.IsModularProgram),
        FEAProgramId = feaProgramId,
        FinancingTypeId = financingTypeId,
        IsCollegeProgram = false,
        IsArchive = false,
        IsNetworkProgram = StringToBool(item.IsNetworkProgram),
        IsDOTProgram = StringToBool(item.IsDotProgram),
        IsFullDOTProgram = StringToBool(item.IsFullDotProgram),
        QualificationName = item.QualificationName ?? string.Empty
      };
      this._pgContext.EducationPrograms.Add(educationProgram);
      this._logger.Trace($"Создана программа обучения '{nameEducationProgram}': id={educationProgram.Id}.");
    }
    return educationProgram.Id;
  }

  /// <summary>
  /// Записать документ повышения квалификации при его отсутствии.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="idKind">Идентификатор типа документа.</param>
  /// <returns>Идентификатор документа.</returns>
  /// <exception cref="Exception">Исключение возникает при ошибке преобразования строки в дату.</exception>
  private Guid SaveDocumentRiseQualificationToDb(StudentWithRequest item, Guid idKind)
  {
    if(!DateTime.TryParse(item.DocumentRiseQualificationDate, out var datetime))
    {
      throw new Exception($"Ошибка преобразования строки {item.DocumentRiseQualificationDate} в дату.");
    }

    var documentRiseQualification = this._pgContext.DocumentRiseQualifications.
      FirstOrDefault(e => e.KindDocumentRiseQualificationId == idKind &&
                          e.Number == item.DocumentRiseQualificationNumber);

    if(documentRiseQualification is not null)
    {
      this._logger.Trace($"Найден документ повышения квалификации  '{documentRiseQualification.Number}': id={documentRiseQualification.Id}.");
    }
    else
    {
      documentRiseQualification = new DocumentRiseQualification
      {
        Id = Guid.NewGuid(),
        KindDocumentRiseQualificationId = idKind,
        Date = datetime,
        Number = item.DocumentRiseQualificationNumber ?? string.Empty
      };
      this._pgContext.DocumentRiseQualifications.Add(documentRiseQualification);
      this._logger.Trace($"Создан документ повышения квалификации  '{documentRiseQualification.Number}': id={documentRiseQualification.Id}.");
    }
    return documentRiseQualification.Id;
  }

  /// <summary>
  /// Записать группу обучения.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="educationProgramId">Идентификатор программы обучения.</param>
  /// <returns>Идентификатор группы.</returns>
  /// <exception cref="Exception">Исключение возникает при ошибке преобразования строки в дату.</exception>
  private Guid SaveGroupToDb(StudentWithRequest item, Guid educationProgramId)
  {
    if(!DateTime.TryParse(item.StartDate, out var startDatetime))
    {
      throw new Exception($"Ошибка преобразования строки '{item.StartDate}' в дату. Введите корректную дату начала обучения.");
    }
    var startDate = DateOnly.FromDateTime(startDatetime);

    if(!DateTime.TryParse(item.EndDate, out var endDatetime))
    {
      throw new Exception($"Ошибка преобразования строки '{item.EndDate}' в дату. Введите корректную дату конца обучения.");
    }
    var endDate = DateOnly.FromDateTime(endDatetime);

    var group = this._pgContext.Groups.
      FirstOrDefault(e => e.EducationProgramId == educationProgramId &&
                          e.Name == item.GroupName &&
                          e.StartDate == startDate && e.EndDate == endDate);

    if(group is not null)
    {
      this._logger.Trace($"Найдена группа обучения '{group.Name}': id={group.Id}.");
    }
    else
    {
      group = new Group
      {
        Id = Guid.NewGuid(),
        Name = item.GroupName,
        EducationProgramId = educationProgramId,
        StartDate = startDate,
        EndDate = endDate
      };
      this._pgContext.Groups.Add(group);
      this._logger.Trace($"Создана группа обучения '{group.Name}': id={group.Id}.");
    }
    return group.Id;
  }

  /// <summary>
  /// Записать группу обучения.
  /// </summary>
  /// <param name="groupId">Идентификатор группы обучения.</param>
  /// <param name="requestId">Идентификатор заявки.</param>
  /// <param name="studentId">Идентификатор студента.</param>
  private void SaveGroupStudentToDb(Guid groupId, Guid requestId, Guid studentId)
  {
    var groupStudent = this._pgContext.GroupStudent.
      FirstOrDefault(e => e.GroupId == groupId && e.RequestId == requestId && e.StudentId == studentId);

    if(groupStudent is not null)
    {
      this._logger.Trace($"Найдена запись студента '{studentId}' в группу '{groupId}' по заявке '{requestId}'.");
    }
    else
    {
      groupStudent = new GroupStudent
      {
        StudentId = studentId,
        GroupId = groupId,
        RequestId = requestId
      };
      this._pgContext.GroupStudent.Add(groupStudent);
      this._logger.Trace($"Создана запись студента '{studentId}' в группу '{groupId}' по заявке '{requestId}'.");
    }
  }

  /// <summary>
  /// Сохранить приказы о зачислении и отчислении.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="requestId">Идентификатор заявки.</param>
  private void SaveOrdersToDb(StudentWithRequest item, Guid requestId)
  {
    if(item.EnrollmentOrder is not null && item.EnrollmentOrder.Trim().Length > 0)
    {
      var kindId = new Guid("CE1395D6-7696-4903-840B-4EAB48120D8F");
      if(this._pgContext.KindOrders.Find(kindId) is null)
      {
        var kind = new KindOrder
        {
          Id = kindId,
          Name = "О зачислении"
        };
        this._pgContext.KindOrders.Add(kind);
      }
      this.SaveOrderToDb(item.EnrollmentOrder, kindId, requestId);
    }

    if(item.ExpulsionOrder is null || item.ExpulsionOrder.Trim().Length <= 0)
    {
      var kindId = new Guid("88DD5DAF-2272-4FC3-9D65-82E65B09266D");
      if(this._pgContext.KindOrders.Find(kindId) is null)
      {
        var kind = new KindOrder
        {
          Id = kindId,
          Name = "Об отчислении"
        };
        this._pgContext.KindOrders.Add(kind);
      }
      this.SaveOrderToDb(item.ExpulsionOrder, kindId, requestId);
    }
  }

  /// <summary>
  /// Сохранить приказ в БД.
  /// </summary>
  /// <param name="numberDate">Номер и дата приказа.</param>
  /// <param name="kindOrderId">Идентификатор типа приказа.</param>
  /// <param name="requestId">Идентификатор заявки.</param>
  /// <exception cref="Exception">Исключение возникает, если на входе номер+дата приказа в неверном формате
  /// или возникла ошибка преобразования строки в дату.</exception>
  private void SaveOrderToDb(string? numberDate, Guid kindOrderId, Guid requestId)
  {
    if(numberDate is null || numberDate.Trim().Length == 0)
    {
      return;
    }

    if(!numberDate.Contains("от"))
    {
      throw new Exception($"Ошибка преобразования строки '{numberDate}' в номер договора и дату. Приказ должен быть записан в формате '123456 от 11.11.2024'.");

    }
    var index = numberDate.IndexOf("от", StringComparison.Ordinal);
    var number = numberDate[..index].Trim();
    var dateFromString = numberDate[(index + 2)..];
    if(!DateTime.TryParse(dateFromString, out var date))
    {
      throw new Exception($"Ошибка преобразования строки '{dateFromString}' в дату. Введите корректную дату приказа.");
    }

    var order = this._pgContext.Orders.
      FirstOrDefault(e => e.Number != null && e.Number.Trim() == number &&
                          e.Date == date &&
                          e.KindOrderId == kindOrderId &&
                          e.RequestId == requestId);

    if(order is not null)
    {
      this._logger.Trace($"Найден приказ '{order.Number}' от {order.Date}: id={order.Id}.");
    }
    else
    {
      order = new Order
      {
        Id = Guid.NewGuid(),
        Number = number,
        Date = date,
        KindOrderId = kindOrderId,
        RequestId = requestId
      };
      this._pgContext.Orders.Add(order);
      this._logger.Trace($"Создан приказ '{order.Number}' от {order.Date}: id={order.Id}.");
    }
  }

  /// <summary>
  /// Добавить запись о студенте, если записи еще нет в БД.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="idTypeEducation">Идентификатор типа образования.</param>
  /// <param name="idScopeOfActivityLevelOne">Идентификатор сферы деятельности уровня 1.</param>
  /// <param name="idScopeOfActivityLevelTwo">Идентификатор сферы деятельности уровня 2.</param>
  /// <returns>Идентификатор студента</returns>
  /// <exception cref="Exception">Исключение возникает, если происходит ошибка преобразования даты из строки.</exception>
  private Guid SaveStudentToDb(StudentWithRequest item, Guid idTypeEducation, Guid idScopeOfActivityLevelOne,
    Guid? idScopeOfActivityLevelTwo)
  {
    if(!DateTime.TryParse(item.BirthDate, out var birthDatetime))
    {
      throw new Exception($"Ошибка преобразования в дату значения {item.BirthDate}.");
    }
    var birthDate = DateOnly.FromDateTime(birthDatetime);

    DateTime? dateTakeDiploma = null;
    if(DateTime.TryParse(item.DocumentRiseQualificationDate, out var datetime))
    {
      dateTakeDiploma = datetime;
    }

    var name = item.Name?.ToLower().Trim() ?? string.Empty;
    var patron = item.Patron?.ToLower().Trim() ?? string.Empty;
    var family = item.Family?.ToLower().Trim() ?? string.Empty;

    var student = this._pgContext.Students.FirstOrDefault(e => e.Name != null &&
                                                               e.Name.ToLower().Trim() == name
                                                               && ((e.Patron == null && patron == string.Empty) ||
                                                                   (e.Patron != null && e.Patron.ToLower().Trim() == patron))
                                                               && e.Surname.ToLower().Trim() == family
                                                               && e.BirthDate == birthDate);

    if(student is not null)
    {
      this._logger.Trace($"Найден студент по ФИО '{student.FullName}' и дате рождения {student.BirthDate}: id={student.Id}.");
      return student.Id;
    }
    else
    {
      student = new Student
      {
        Id = Guid.NewGuid(),
        Surname = item.Family ?? string.Empty,
        Name = item.Name,
        Patron = item.Patron,
        BirthDate = birthDate,
        Sex = item.Sex is null || item.Sex.Trim().ToLower() == "муж" ? SexHuman.Men : SexHuman.Woman,
        Nationality = item.Nationality,
        SNILS = item.Snils,
        Address = item.Address ?? string.Empty,
        Phone = item.Phone ?? string.Empty,
        Email = item.Email ?? string.Empty,
        //Projects-в файле эксель не нашла
        IT_Experience = item.ItExperience ?? string.Empty,
        Disability = item.Disability is null ? null : StringToBool(item.Disability),
        TypeEducationId = idTypeEducation,
        ScopeOfActivityLevelOneId = idScopeOfActivityLevelOne,
        ScopeOfActivityLevelTwoId = idScopeOfActivityLevelTwo,
        //Speciality - в файле эксель не нашла
        FullNameDocument = item.FullNameDocument,
        DocumentSeries = item.DocumentSeries,
        DocumentNumber = item.DocumentNumber,
        DateTakeDiplom = dateTakeDiploma
      };
      this._pgContext.Students.Add(student);
      this._logger.Trace($"Создан студент c ФИО '{student.FullName}' и датой рождения {student.BirthDate}: id={student.Id}.");
      return student.Id;
    }
  }

  /// <summary>
  /// Сохранить заявку, если ее еще нет в БД. (Добавить сохранения даты заявки DateCreateRequest, когда дата появится в модели)
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="educationProgramId">Идентификатор программы обучения.</param>
  /// <param name="statusRequestId">Идентификатор статуса заявки.</param>
  /// <param name="statusStudentId">Идентификатор статуса студента.</param>
  /// <param name="documentRiseQualificationId">Идентификатор документа повышения квалификации.</param>
  /// <param name="isAlreadyStudied">Признак обучался ли студент ранее.</param>
  /// <returns>Идентификатор заявки.</returns>
  private Guid SaveRequestToDb(StudentWithRequest item,
    Guid studentId,
    Guid? educationProgramId,
    Guid? statusRequestId,
    Guid? statusStudentId,
    Guid? documentRiseQualificationId,
    bool isAlreadyStudied)
  {
    var statusEntranceExams = item.StatusEntranceExams?.Trim().ToLower() == "собеседование" ?
      StatusEntrancExams.Interview :
      item.StatusEntranceExams?.Trim().ToLower() == "тестовое задание" ?
        StatusEntrancExams.TestTask :
        item.StatusEntranceExams?.Trim().ToLower() == "выполнено" ?
          StatusEntrancExams.Done :
          StatusEntrancExams.NotPassed;

    var request = this._pgContext.Requests.FirstOrDefault(e => e.StudentId == studentId
                                                               && ((e.EducationProgramId == null && educationProgramId == null) || e.EducationProgramId == educationProgramId)
                                                               && ((e.StatusRequestId == null && statusRequestId == null) || e.StatusRequestId == statusRequestId)
                                                               && e.StatusEntrancExams == statusEntranceExams);

    if(request is not null)
    {
      this._logger.Trace($"Найдена заявка по студенту с id '{studentId}', программе обучения '{educationProgramId}', " +
                         $"'статусу заявки {statusRequestId}, статусу вступительного испытания '{statusEntranceExams}': id={request.Id}.");
      return request.Id;
    }
    else
    {
      DateTime.TryParse(item.DateCreateRequest, out var dateCreateRequest);
      request = new Request
      {
        Id = Guid.NewGuid(),
        StudentId = studentId,
        EducationProgramId = educationProgramId,
        Phone = item.Phone ?? string.Empty,
        Email = item.Email ?? string.Empty,
        DocumentRiseQualificationId = documentRiseQualificationId,
        DataNumberDogovor = item.DataNumberDogovor,
        StatusRequestId = statusRequestId,
        StudentStatusId = statusStudentId,
        StatusEntrancExams = statusEntranceExams,
        RegistrationNumber = item.DocumentRiseQualificationRegistrationNumber,
        Agreement = true,
        DateOfCreate = dateCreateRequest
      };
      this._pgContext.Requests.Add(request);
      this._logger.Trace($"Создана заявка по студенту с id '{studentId}', программе обучения '{educationProgramId}', " +
                         $"'статусу заявки {statusRequestId}, статусу вступительного испытания '{statusEntranceExams}': id={request.Id}.");
      return request.Id;
    }
  }

  /// <summary>
  /// Откатить изменения.
  /// </summary>
  private void RollBack()
  {
    var changedEntries = this._pgContext.ChangeTracker.Entries()
      .Where(x => x.State != EntityState.Unchanged).ToList();

    foreach(var entry in changedEntries)
    {
      switch(entry.State)
      {
        case EntityState.Modified:
          entry.CurrentValues.SetValues(entry.OriginalValues);
          entry.State = EntityState.Unchanged;
          break;
        case EntityState.Added:
          entry.State = EntityState.Detached;
          break;
        case EntityState.Deleted:
          entry.State = EntityState.Unchanged;
          break;
      }
    }
  }

  /// <summary>
  /// Найти данные в БД.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  /// <returns>True - если данные уже есть в БД, иначе - false. </returns>
  /// <exception cref="Exception">Исключение возникает, если выпала ошибка преобразования строки в дату.</exception>
  public bool FindStudentRequest(StudentWithRequest item)
  {
    if(!DateTime.TryParse(item.BirthDate, out var birthDatetime))
    {
      throw new Exception($"Ошибка преобразования в дату значения {item.BirthDate}.");
    }
    var birthDate = DateOnly.FromDateTime(birthDatetime);

    var name = item.Name?.ToLower().Trim() ?? string.Empty;
    var patron = item.Patron?.ToLower().Trim() ?? string.Empty;
    var family = item.Family?.ToLower().Trim() ?? string.Empty;

    var student = this._pgContext.Students.FirstOrDefault(e => e.Name != null &&
                                                               e.Name.ToLower().Trim() == name
                                                               && ((e.Patron == null && patron == string.Empty) ||
                                                                   (e.Patron != null && e.Patron.ToLower().Trim() == patron))
                                                               && e.Surname.ToLower().Trim() == family
                                                               && e.BirthDate == birthDate);

    if(student is null)
    {
      return false;
    }

    var statusEntranceExams = item.StatusEntranceExams?.Trim().ToLower() == "собеседование" ?
      StatusEntrancExams.Interview :
      item.StatusEntranceExams?.Trim().ToLower() == "тестовое задание" ?
        StatusEntrancExams.TestTask :
        item.StatusEntranceExams?.Trim().ToLower() == "выполнено" ?
          StatusEntrancExams.Done :
          StatusEntrancExams.NotPassed;

    var statusRequestId = this.FindStatusRequest(item.RequestStatus ?? string.Empty);
    var educationProgramId = this.FindEducationProgram(item.EducationProgram ?? string.Empty);

    var request = this._pgContext.Requests.FirstOrDefault(e => e.StudentId == student.Id
                                                               && e.EducationProgramId == educationProgramId
                                                               && e.StatusRequestId == statusRequestId
                                                               && e.StatusEntrancExams == statusEntranceExams);

    return request is not null;
  }

  /// <summary>
  /// Сохранить данные из эксель в БД.
  /// </summary>
  /// <param name="item">Данные из эксель.</param>
  public void SaveToDb(StudentWithRequest item)
  {
    try
    {
      var typeEducationId = this.SaveTypeEducationToDb(item.TypeEducation ?? string.Empty);
      var scopeOfActivityLevelOneId = this.SaveScopeOfActivityToDb(item, ScopeOfActivityLevel.Level1);
      if(scopeOfActivityLevelOneId is null)
      {
        throw new Exception("Ошибка при записи сферы деятельности 1 ур.");
      }
      var scopeOfActivityLevelTwoId = this.SaveScopeOfActivityToDb(item, ScopeOfActivityLevel.Level2);
      var studentId = this.SaveStudentToDb(item, typeEducationId, scopeOfActivityLevelOneId.Value, scopeOfActivityLevelTwoId);

      Guid? documentRiseQualificationId = null;
      Guid? educationProgramId = null;
      if(item.EducationProgram is not null && item.EducationProgram.Trim() != string.Empty)
      {
        var kindDocumentRiseQualificationId = this.SaveKindDocumentRiseQualificationToDb(item.DocumentRiseQualificationType ?? string.Empty);
        if(kindDocumentRiseQualificationId is not null)
        {
          documentRiseQualificationId = this.SaveDocumentRiseQualificationToDb(item, kindDocumentRiseQualificationId.Value);
        }
        var educationFormId = this.SaveEducationFormToDb(item.EducationForm ?? string.Empty);
        var feaProgramId = this.SaveFeaProgramToDb(item.FeaProgram ?? string.Empty);
        var financingTypeId = this.SaveFinancingTypeToDb(item.FinancingType ?? string.Empty);

        var kindEducationProgramId = this.SaveKindEducationProgramToDb(item.KindEducationProgram);
        educationProgramId = this.SaveEducationProgramToDb(item, educationFormId,
          kindDocumentRiseQualificationId, kindEducationProgramId, feaProgramId, financingTypeId);
      }

      var statusRequestId = this.SaveRequestStatusToDb(item.RequestStatus ?? string.Empty);
      var statusStudentId = this.SaveStudentStatusToDb(item.StudentStatus ?? string.Empty);
      var isAlreadyStudied = this.FindRequestByStudentId(studentId);

      var requestId = this.SaveRequestToDb(item, studentId, educationProgramId, statusRequestId,
        statusStudentId, documentRiseQualificationId, isAlreadyStudied);

      if(item.GroupName is not null && item.GroupName.Trim() != string.Empty && educationProgramId is null)
      {
        throw new Exception($"Необходимо заполнить программу обучения для создания группы '{item.GroupName}'.");
      }
      if(educationProgramId is not null)
      {
        var groupId = this.SaveGroupToDb(item, educationProgramId.Value);
        this.SaveGroupStudentToDb(groupId, requestId, studentId);
      }

      this.SaveOrdersToDb(item, requestId);

      this._pgContext.SaveChanges();
      this._logger.Trace("Созданные данные сохранены в БД.");
    }
    catch
    {
      this.RollBack();
      throw;
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  public DbService(ILogger logger)
  {
    this._pgContext = new PgContext();
    this._logger = logger;
  }

  #endregion
}