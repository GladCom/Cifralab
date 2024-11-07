using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Migrations;

internal static class HasDataEntities
{
  #region Свойства

  public static List<FEAProgram> FEAProgramEntities => new(_fEAProgramEntities);
  public static List<FinancingType> FinancingTypeEntities => new(_financingTypeEntities);
  public static List<EducationForm> EducationFormEntities => new(_educationFormEntities);

  public static List<KindDocumentRiseQualification> KindDocumentRiseQualificationEntities =>
    new(_kindDocumentRiseQualificationEntities);

  public static List<KindOrder> KindOrderEntities => new(_kindOrderEntities);
  public static List<ScopeOfActivity> ScopeOfActivityEntities => new(_scopeOfActivityEntities);
  public static List<StatusRequest> StatusRequestEntities => new(_statusRequestsEntities);
  public static List<StudentStatus> StudentStatusEntities => new(_studentStatusEntities);
  public static List<TypeEducation> TypeEducationEntities => new(_typeEducationsEntities);

  public static List<DocumentRiseQualification> DocumentRiseQualificationEntities =>
    new(_documentRiseQualificationEntities);

  public static List<EducationProgram> EducationProgramEntities => new(_educationProgramEntities);
  public static List<Group> GroupEntities => new(_groupEntities);
  public static List<GroupStudent> GroupStudentEntities => new(_groupStudentEntities);
  public static List<Order> OrderEntities => new(_orderEntities);
  public static List<Request> RequestEntities => new(_requestEntities);
  public static List<Student> StudentEntities => new(_studentEntities);

  #endregion

  #region Поля

  private static readonly List<FEAProgram> _fEAProgramEntities = new()
  {

    new FEAProgram
    {
      Id = Guid.Parse("8cc81b3a-3681-4bf8-bf1a-a62b1d1775fa"),
      Name = "Сельское, лесное хозяйство, охота, рыболовство и рыбоводство"
    },
    new FEAProgram
    {
      Id = Guid.Parse("57782aff-9f4c-4f83-a967-3229285bf140"),
      Name = "Добыча полезных ископаемых"
    },
    new FEAProgram
    {
      Id = Guid.Parse("bb4d092c-0a13-4e61-ad74-bab54565467a"),
      Name = "Обрабатывающие производства"
    },
    new FEAProgram
    {
      Id = Guid.Parse("42c8476f-62f7-461e-b059-f3c2edd38f40"),
      Name = "Обеспечение электрической энергией, газом и паром; кондиционирование воздуха"
    },
    new FEAProgram
    {
      Id = Guid.Parse("55fca356-ecd3-40ed-b2b3-6262d685f321"),
      Name =
        "Водоснабжение, водоотведение, организация сбора и утилизации отходов, деятельность по ликвидации загрязнений"
    },
    new FEAProgram
    {
      Id = Guid.Parse("2eaab406-6302-4707-be8b-f6de40bec96e"),
      Name = "Строительство"
    },
    new FEAProgram
    {
      Id = Guid.Parse("313349b3-c3d2-42af-add6-c5fc6fc5f238"),
      Name = "Торговля оптовая и розничная; ремонт автотранспортных средств и мотоциклов"
    },
    new FEAProgram
    {
      Id = Guid.Parse("07b93879-1903-4c4f-9b63-19cd9a357c79"),
      Name = "Транспортировка и хранение"
    },
    new FEAProgram
    {
      Id = Guid.Parse("c841a174-36b3-40b9-b96a-78e7f40db406"),
      Name = "Деятельность гостиниц и предприятий общественного питания"
    },
    new FEAProgram
    {
      Id = Guid.Parse("d6667aea-5077-491e-9fc6-75aba2b5c040"),
      Name = "Деятельность в области информации и связи"
    },
    new FEAProgram
    {
      Id = Guid.Parse("543ee5ea-587a-4ad3-9011-0e0040314112"),
      Name = "Деятельность финансовая и страховая"
    },
    new FEAProgram
    {
      Id = Guid.Parse("2e0a8801-529d-406a-8b06-09dee812f0fd"),
      Name = "Деятельность по операциям с недвижимым имуществом"
    },
    new FEAProgram
    {
      Id = Guid.Parse("a9ede175-ff97-49fa-a42a-d481a6e40008"),
      Name = "Деятельность профессиональная, научная и техническая"
    },
    new FEAProgram
    {
      Id = Guid.Parse("3620d6b8-e3dd-407b-8f22-9f73162c0f09"),
      Name = "Деятельность административная и сопутствующие дополнительные услуги"
    },
    new FEAProgram
    {
      Id = Guid.Parse("5b564193-b96a-4fd8-bfcd-f348e68694cb"),
      Name = "Государственное управление и обеспечение военной безопасности; социальное обеспечение"
    },
    new FEAProgram
    {
      Id = Guid.Parse("9a123e90-7122-49af-8e24-9aca964b39cb"),
      Name = "Образование"
    },
    new FEAProgram
    {
      Id = Guid.Parse("0a2720fe-6381-4920-9fc1-765487de0c53"),
      Name = "Деятельность в области здравоохранения и социальных услуг"
    },
    new FEAProgram
    {
      Id = Guid.Parse("ceff5624-b542-4a93-aca9-0ded3cde2146"),
      Name = "Деятельность в области культуры, спорта, организации досуг и развлечений"
    },
    new FEAProgram
    {
      Id = Guid.Parse("8a2953b7-d2f6-4bc8-813b-c0f4d1a928ae"),
      Name = "Предоставление прочих видов услуг"
    },
    new FEAProgram
    {
      Id = Guid.Parse("6977c645-b2de-453e-b0e1-75fed0f06986"),
      Name =
        "Деятельность домашних хозяйств как работодателей; недифференцированная деятельность частных домашних хозяйств"
    },
    new FEAProgram
    {
      Id = Guid.Parse("33869d2e-968b-4928-a485-bcb01b9821d2"),
      Name = "Деятельность экстерриториальных организаций и органов"
    }
  };

  private static readonly List<FinancingType> _financingTypeEntities = new()
  {
    new FinancingType
    {
      Id = Guid.Parse("06784e4c-dc85-4f51-9ee4-c87d3e478db4"),
      SourceName = "За счет бюджетных ассигнований федерального бюджета"
    },
    new FinancingType
    {
      Id = Guid.Parse("0457cc26-6b4f-472b-bdbf-a9be3599e931"),
      SourceName = "За счет бюджетных ассигнований бюджетов субъектов РФ"
    },
    new FinancingType
    {
      Id = Guid.Parse("34de84cf-271d-4546-80f7-3a9a65b3830b"),
      SourceName = "За счет бюджетных ассигнований местных бюджетов"
    },
    new FinancingType
    {
      Id = Guid.Parse("533020ac-b4ae-4d7c-a946-fa5ff0b95633"),
      SourceName = "По договорам за счет средств физических лиц"
    },
    new FinancingType
    {
      Id = Guid.Parse("66d030a8-7441-4d40-840c-d5d44c3d634e"),
      SourceName = "По договорам за счет средств юридических лиц "
    },
    new FinancingType
    {
      Id = Guid.Parse("1f155a86-9bd1-4cbe-bc5e-829171cfb92b"),
      SourceName = "За счет собственных средств организации"
    }
  };

  private static readonly List<EducationForm> _educationFormEntities = new()
  {
    new EducationForm
    {
      Id = Guid.Parse("0241c1ac-bb5b-4ca1-bb46-89ba1e0c4287"),
      Name = "Очная"
    },
    new EducationForm
    {
      Id = Guid.Parse("77c07268-346c-443c-8a21-9ba091c828fd"),
      Name = "Очно-заочная"
    },
    new EducationForm
    {
      Id = Guid.Parse("9fd0638c-3976-42b0-8782-06ed3f9ca0db"),
      Name = "Заочная"
    }
  };

  private static readonly List<KindDocumentRiseQualification> _kindDocumentRiseQualificationEntities = new()
  {
    new KindDocumentRiseQualification
    {
      Id = Guid.Parse("f3963a72-8d77-47cc-85e5-0e46c1846f15"),
      Name = "Диплом о профессиональной переподготовке"
    },
    new KindDocumentRiseQualification
    {
      Id = Guid.Parse("aa7a8325-4b0d-4dd2-bedc-2c4a065ab332"),
      Name = "Удостоверение о повышении квалификации"
    }
  };

  private static readonly List<KindOrder> _kindOrderEntities = new()
  {
    new KindOrder
    {
      Id = new Guid("753df8b7-2d6f-4499-9f86-563771f016c1"),
      Name = "О зачислении"
    },
    new KindOrder
    {
      Id = new Guid("c929e14d-e657-4b95-873c-0746f4edc68e"),
      Name = "Об отчислении"
    }
  };

  private static readonly List<ScopeOfActivity> _scopeOfActivityEntities = new()
  {
    new ScopeOfActivity
    {
      Id = new Guid("e768a213-0421-4c6f-85b8-0069882870c6"),
      Level = ScopeOfActivityLevel.Level1,
      NameOfScope = "Работники предприятий и организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("e1ab6e96-d9af-41c1-abca-61a1e5052a9e"),
      Level = ScopeOfActivityLevel.Level1,
      NameOfScope = "Работники образовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("ed3df49f-e714-4940-a151-458616ee7d84"),
      Level = ScopeOfActivityLevel.Level1,
      NameOfScope = "Гос. Служащие"
    },
    new ScopeOfActivity
    {
      Id = new Guid("5f450e00-d584-4736-882b-1b6ada2484bc"),
      Level = ScopeOfActivityLevel.Level1,
      NameOfScope = "Незанятые лица по направлению службы занятости"
    },
    new ScopeOfActivity
    {
      Id = new Guid("a5e1e718-4747-47f4-b7c3-08e56bb7ea34"),
      Level = ScopeOfActivityLevel.Level1,
      NameOfScope = "Другие"
    },

    new ScopeOfActivity
    {
      Id = new Guid("ca1c76a3-d268-4d06-8e4a-3721a4f2fb54"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители предприятий и организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("71e13148-a111-4c45-94b2-a920353d0571"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители дошкольных образовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("3af3138f-d487-4866-b8c3-b6e782bf1de8"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители общеобразовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("e94fff46-4a09-4c26-ad86-75219d0bc489"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители профессиональных образовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("b9115d04-3a42-42e3-8a74-61519f13a4e8"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители образовательных организаций ВО"
    },
    new ScopeOfActivity
    {
      Id = new Guid("d8b097c4-a4c3-447f-9ead-112312c25530"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители организаций ДПО"
    },
    new ScopeOfActivity
    {
      Id = new Guid("e060399a-c130-4ea9-901c-28f62cb7c532"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители организаций дополнительного образования"
    },
    new ScopeOfActivity
    {
      Id = new Guid("77fdb430-5b2f-4c64-8a1a-6728be169e1f"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники дошкольных образовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("ac7b229f-97a0-4325-9e32-c3334c2c8939"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники общеобразовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("197a368e-b704-44ed-81fa-c494537a0813"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники профессиональных образовательных организаций"
    },
    new ScopeOfActivity
    {
      Id = new Guid("5b12db36-3fe2-4831-be2f-075c0bc08d63"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники образовательных организаций ВО"
    },
    new ScopeOfActivity
    {
      Id = new Guid("d58399ce-b5f3-4d0d-8cb9-79419fc373dd"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники организаций ДПО"
    },
    new ScopeOfActivity
    {
      Id = new Guid("ab739f86-1efe-4a5a-883c-ea6963d49e5e"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Педагогические работники организаций дополнительного образования"
    },
    new ScopeOfActivity
    {
      Id = new Guid("fbd51db0-a7c0-4da0-9963-f5e668a13058"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Руководители гос.служащие"
    },
    new ScopeOfActivity
    {
      Id = new Guid("9b70f630-83bf-4805-b9c9-e0a96c0a39b2"),
      Level = ScopeOfActivityLevel.Level2,
      NameOfScope = "Безработные"
    }
  };

  private static readonly List<StatusRequest> _statusRequestsEntities = new()
  {
    new StatusRequest
    {
      Id = new Guid("d2b3c504-1890-43f4-a351-22eea9b8dc08"),
      Name = "Новая заявка"
    },
    new StatusRequest
    {
      Id = new Guid("e51930d7-b466-4188-8b50-7b0013d95a55"),
      Name = "Вступительное испытание"
    },
    new StatusRequest
    {
      Id = new Guid("d8ae2c61-3cd5-410f-a182-10f8f03f1500"),
      Name = "Не соответствует"
    },
    new StatusRequest
    {
      Id = new Guid("a8003ef9-b86d-4b63-9e41-d01720752b80"),
      Name = "В архиве"
    },
    new StatusRequest
    {
      Id = new Guid("2d466d99-995c-473a-abcc-6260c6a2340a"),
      Name = "Обучение"
    },
    new StatusRequest
    {
      Id = new Guid("f42bbf66-14e0-44aa-b15b-605994370ffb"),
      Name = "Отчислен"
    },
    new StatusRequest
    {
      Id = new Guid("0daf618a-7a2f-4099-bbbb-e5323f9921f7"),
      Name = "Завершил"
    }
  };

  private static readonly List<StudentStatus> _studentStatusEntities = new()
  {
    new StudentStatus
    {
      Id = new Guid("69b4aaff-b67f-483d-98e3-98d39da93d7a"),
      Name = "Обучается"
    },
    new StudentStatus
    {
      Id = new Guid("cc2de503-af1c-4c9e-b228-6c4178217169"),
      Name = "Отчислен"
    },
    new StudentStatus
    {
      Id = new Guid("fb1ec3f7-75a8-4a84-bdb6-db7a582e05ae"),
      Name = "Окончил обучение"
    }
  };

  private static readonly List<TypeEducation> _typeEducationsEntities = new()
  {
    new TypeEducation
    {
      Id = new Guid("a4f6d736-28e7-4a63-845e-24e62b433fc1"),
      Name = "Высшее образование"
    },
    new TypeEducation
    {
      Id = new Guid("f87eaad5-5d84-45ce-b862-8da5c45ead5b"),
      Name = "Среднее профессиональное образование"
    },
    new TypeEducation
    {
      Id = new Guid("5cca2c3c-85b9-41ac-bf0d-73ba0cbaa833"),
      Name = "Студент ВО"
    },
    new TypeEducation
    {
      Id = new Guid("3b7bf44e-a9a1-46d6-aadc-7acff647d24f"),
      Name = "Студент СПО"
    }
  };

  private static readonly List<DocumentRiseQualification> _documentRiseQualificationEntities = new()
  {
    new DocumentRiseQualification
    {
      Id = new Guid("b28d1f29-0aa9-4209-8bab-cd49a8ad548d"),
      KindDocumentRiseQualificationId = Guid.Parse("f3963a72-8d77-47cc-85e5-0e46c1846f15"),
      Date = new DateTime(2024, 09, 09),
      Number = "1"
    },
    new DocumentRiseQualification
    {
      Id = new Guid("5dde5f20-a247-45b5-b989-800a858d0b70"),
      KindDocumentRiseQualificationId = Guid.Parse("aa7a8325-4b0d-4dd2-bedc-2c4a065ab332"),
      Date = new DateTime(2024, 10, 09),
      Number = "2"
    }
  };

  private static readonly List<EducationProgram> _educationProgramEntities = new()
  {
    new EducationProgram
    {
      Id = new Guid("b741f950-19b2-472c-bf66-e84bec7c0bb5"),
      Name = "Академия цифра",
      Cost = 0,
      HoursCount = 250,
      EducationFormId = Guid.Parse("0241c1ac-bb5b-4ca1-bb46-89ba1e0c4287"),
      KindDocumentRiseQualificationId = Guid.Parse("aa7a8325-4b0d-4dd2-bedc-2c4a065ab332"),
      IsModularProgram = false,
      FinancingTypeId = Guid.Parse("0457cc26-6b4f-472b-bdbf-a9be3599e931"),
      IsCollegeProgram = false,
      IsArchive = false,
      IsNetworkProgram = false,
      IsDOTProgram = false,
      IsFullDOTProgram = false
    }
  };

  private static readonly List<Group> _groupEntities = new()
  {
    new Group
    {
      Id = new Guid("9a8cd57f-4afe-488b-ab0c-1a25519a2fd7"),
      Name = "С42-019-10",
      EducationProgramId = Guid.Parse("b741f950-19b2-472c-bf66-e84bec7c0bb5"),
      StartDate = new DateOnly(2024, 09, 01),
      EndDate = new DateOnly(2025, 06, 01)
    }
  };

  private static readonly List<GroupStudent> _groupStudentEntities = new()
  {
    new GroupStudent
    {
      StudentId = new Guid("c337e8c4-142a-4f01-a54f-fea1be3d874b"),
      GroupId = new Guid("9a8cd57f-4afe-488b-ab0c-1a25519a2fd7"),
      RequestId = new Guid("4178e3fa-dca8-4e28-a815-46cfacb61fe5")
    },
    new GroupStudent
    {
      StudentId = new Guid("ce523bbd-dbd2-4bc6-8986-0f0c83926c57"),
      GroupId = new Guid("9a8cd57f-4afe-488b-ab0c-1a25519a2fd7"),
      RequestId = new Guid("7ecc61ae-2472-484e-8078-3b34f3448b8e")
    }
  };

  private static readonly List<Order> _orderEntities = new()
  {
    new Order
    {
      Id = new Guid("0f6779b4-4e09-4f91-b7df-881205ea39d0"),
      Number = "42",
      Date = new DateTime(2024, 09, 01),
      KindOrderId = new Guid("753df8b7-2d6f-4499-9f86-563771f016c1"),
      RequestId = new Guid("4178e3fa-dca8-4e28-a815-46cfacb61fe5"),
    }
  };

  private static readonly List<Request> _requestEntities = new()
  {
    new Request
    {
      Id = new Guid("4178e3fa-dca8-4e28-a815-46cfacb61fe5"),
      StudentId = new Guid("c337e8c4-142a-4f01-a54f-fea1be3d874b"),
      EducationProgramId = new Guid("b741f950-19b2-472c-bf66-e84bec7c0bb5"),
      DocumentRiseQualificationId = new Guid("b28d1f29-0aa9-4209-8bab-cd49a8ad548d"),
      DataNumberDogovor = "2024-09-01, 9876",
      StatusRequestId = new Guid("d2b3c504-1890-43f4-a351-22eea9b8dc08"),
      StudentStatusId = new Guid("69b4aaff-b67f-483d-98e3-98d39da93d7a"),
      StatusEntrancExams = StatusEntrancExams.Done,
      RegistrationNumber = "432",
      Email = "III@gmail.com",
      Phone = "+7 (123) 456-78-90",
      Agreement = true
    },
    new Request
    {
      Id = new Guid("7ecc61ae-2472-484e-8078-3b34f3448b8e"),
      StudentId = new Guid("ce523bbd-dbd2-4bc6-8986-0f0c83926c57"),
      EducationProgramId = new Guid("b741f950-19b2-472c-bf66-e84bec7c0bb5"),
      DocumentRiseQualificationId = new Guid("5dde5f20-a247-45b5-b989-800a858d0b70"),
      DataNumberDogovor = "2024-09-02, 9877",
      StatusRequestId = new Guid("d2b3c504-1890-43f4-a351-22eea9b8dc08"),
      StudentStatusId = new Guid("69b4aaff-b67f-483d-98e3-98d39da93d7a"),
      StatusEntrancExams = StatusEntrancExams.Done,
      RegistrationNumber = "432",
      Email = "IAI@gmail.com",
      Phone = "+7 (123) 451-71-90",
      Agreement = true
    }
  };

  private static readonly List<Student> _studentEntities = new()
  {
    new Student
    {
      Id = new Guid("c337e8c4-142a-4f01-a54f-fea1be3d874b"),
      Family = "Иванов",
      Name = "Иван",
      Patron = "Иванович",
      BirthDate = new DateOnly(2003,
        03,
        03),
      Sex = SexHuman.Men,
      Nationality = "Россия",
      Address = "Проспект Сишарпа, 42",
      Phone = "+7 (123) 453-78-90",
      Email = "III@gmail.com",
      Projects = "Немало",
      IT_Experience = "Есть",
      Disability = false,
      TypeEducationId = new Guid("a4f6d736-28e7-4a63-845e-24e62b433fc1"),
      ScopeOfActivityLevelOneId = new Guid("e768a213-0421-4c6f-85b8-0069882870c6"),
      Speciality = "Сварщик",
      FullNameDocument = "Иванов",
      DateTakeDiplom = new DateTime(2077, 01, 01)
    },
    new Student
    {
      Id = new Guid("ce523bbd-dbd2-4bc6-8986-0f0c83926c57"),
      Family = "Иванова",
      Name = "Анна",
      Patron = "Ивановна",
      BirthDate = new DateOnly(2004,
        04,
        04),
      Sex = SexHuman.Woman,
      Nationality = "Россия",
      Address = "Проспект PHP, 47",
      Phone = "+7 (123) 451-71-90",
      Email = "IAI@gmail.com",
      Projects = "Мало",
      IT_Experience = "Есть",
      Disability = false,
      TypeEducationId = new Guid("f87eaad5-5d84-45ce-b862-8da5c45ead5b"),
      ScopeOfActivityLevelOneId = new Guid("9b70f630-83bf-4805-b9c9-e0a96c0a39b2"),
      Speciality = "HR",
      FullNameDocument = "Иванова",
      DateTakeDiplom = new DateTime(2042, 01, 01)
    }
  };

  #endregion
}
