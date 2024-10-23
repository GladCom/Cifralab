using Microsoft.EntityFrameworkCore;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Contexts;

public sealed class InMemoryContext : StudentContext
{
  public InMemoryContext()
  {
    Database.EnsureCreated();

  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseInMemoryDatabase(databaseName: "ImMemoryDB");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    #region Data Seeding

    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<EducationForm>().HasData(
        new EducationForm { Id = new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48"), Name = "Очная" },
        new EducationForm { Id = new Guid("DFA6FEDB-932D-431A-8E9A-0C6666A10041"), Name = "Заочная" },
        new EducationForm { Id = new Guid("5AFFDA31-3A2E-4BEA-85EE-F4C67564B3B2"), Name = "Очно-заочная" }
    );
    modelBuilder.Entity<FEAProgram>().HasData(
        new FEAProgram
        {
          Id = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
          Name = "Сельское, лесное хозяйство, охота, рыболовство и рыбоводство"
        },
        new FEAProgram
        {
          Id = new Guid("A372123C-2E7C-47A7-BFE6-80D3F6EB5DB4"),
          Name = "Добыча полезных ископаемых"
        },
        new FEAProgram
        {
          Id = new Guid("0E192D99-1A96-4987-AB32-1CBC93D19483"),
          Name = "Обрабатывающие производства"
        },
        new FEAProgram
        {
          Id = new Guid("9ABA2438-0EDB-4892-9C4D-528E55A163E2"),
          Name = "Обеспечение электрической энергией, газом и паром; кондиционирование воздуха"
        },
        new FEAProgram
        {
          Id = new Guid("6556CCAE-0953-4CE5-BAD7-CD45CDAB0430"),
          Name = "Водоснабжение, водоотведение, организация сбора и утилизации отходов, деятельность по ликвидации загрязнений"
        },
        new FEAProgram
        {
          Id = new Guid("B1C84659-5E03-4481-9C06-D1AF2DCCB1D1"),
          Name = "Строительство"
        },
        new FEAProgram
        {
          Id = new Guid("F5677A6B-7BBD-4F23-A20B-CDB22DF0B791"),
          Name = "Торговля оптовая и розничная; ремонт автотранспортных средств и мотоциклов"
        },
        new FEAProgram
        {
          Id = new Guid("256479FE-DB32-4BAD-A8F1-1E7FFE6FDF7F"),
          Name = "Транспортировка и хранение"
        },
        new FEAProgram
        {
          Id = new Guid("ACEC08BC-B442-4250-B031-F06290661F60"),
          Name = "Деятельность гостиниц и предприятий общественного питания"
        },
        new FEAProgram
        {
          Id = new Guid("0B55103E-CCCB-4D43-8C8F-EF38DAA57D1A"),
          Name = "Деятельность в области информации и связи"
        },
        new FEAProgram
        {
          Id = new Guid("29AA5936-2CA3-4387-AF90-5142F698C5E7"),
          Name = "Деятельность финансовая и страховая"
        },
        new FEAProgram
        {
          Id = new Guid("E918F975-3774-4C88-A8E9-44AAACBA50CA"),
          Name = "Деятельность по операциям с недвижимым имуществом"
        },
        new FEAProgram
        {
          Id = new Guid("CD22CD4F-BAD3-4090-94E8-FA5563D3FB73"),
          Name = "Деятельность профессиональная, научная и техническая"
        },
        new FEAProgram
        {
          Id = new Guid("A90495B2-B81B-4220-A6D7-2EC755318F47"),
          Name = "Деятельность административная и сопутствующие дополнительные услуги"
        },
        new FEAProgram
        {
          Id = new Guid("B76547B7-8756-4C8D-A62E-2A428D8E1B23"),
          Name = "Государственное управление и обеспечение военной безопасности; социальное обеспечение"
        },
        new FEAProgram
        {
          Id = new Guid("6E72CBFF-741E-49E5-B37D-0EE1F8FAA3C4"),
          Name = "Образование"
        },
        new FEAProgram
        {
          Id = new Guid("25ADCDDD-D3CB-4FAB-AAE4-06ECB534027F"),
          Name = "Деятельность в области здравоохранения и социальных услуг"
        },
        new FEAProgram
        {
          Id = new Guid("A0E6AC5D-6467-4DAF-BE89-39679858ED59"),
          Name = "Деятельность в области культуры, спорта, организации досуг и развлечений"
        },
        new FEAProgram
        {
          Id = new Guid("EF462C10-A340-477C-BD10-D06682C357B3"),
          Name = "Предоставление прочих видов услуг"
        },
        new FEAProgram
        {
          Id = new Guid("2BD97038-C34F-45FA-A09E-A6342B248A35"),
          Name = "Деятельность домашних хозяйств как работодателей; недифференцированная деятельность частных домашних хозяйств"
        },
        new FEAProgram
        {
          Id = new Guid("17B2F00D-A764-4214-BE2D-89DC8E5E8817"),
          Name = "Деятельность экстерриториальных организаций и органов"
        }
    );
    modelBuilder.Entity<StatusRequest>().HasData(
        new StatusRequest
        {
          Id = new Guid("949A5221-63E6-4A92-BDBC-3BE7ACB6CDDD"),
          Name = "новая заявка"
        },
        new StatusRequest
        {
          Id = new Guid("8B70E4C5-54FB-46C7-84CF-3B46128D7D8B"),
          Name = "вступительное испытание"
        },
        new StatusRequest
        {
          Id = new Guid("043AEBE6-BCE0-4DD4-B0C0-1582852A6EFD"),
          Name = "не соответствует"
        },
        new StatusRequest
        {
          Id = new Guid("499322AC-CA21-4217-9E31-F94F33B4FE13"),
          Name = "в архиве"
        },
        new StatusRequest
        {
          Id = new Guid("BD671117-09C1-481D-98B3-35D8981FD515"),
          Name = "обучение"
        },
        new StatusRequest
        {
          Id = new Guid("A5DC52F9-199E-4572-A906-134EEC697CE2"),
          Name = "отчислен"
        },
        new StatusRequest
        {
          Id = new Guid("3D3996AF-8287-49C3-AD8C-EC54DB0D318B"),
          Name = "завершил"
        }
    );
    modelBuilder.Entity<ScopeOfActivity>().HasData(
        new ScopeOfActivity
        {
          Id = new Guid("6C3776FC-F3AC-4F4A-92D5-1E94A5596F6A"),
          Level = ScopeOfActivityLevel.Level1,
          NameOfScope = "Работники предприятий и организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("3DF1FEB6-1268-4EEF-B55B-F822EDF6C84F"),
          Level = ScopeOfActivityLevel.Level1,
          NameOfScope = "Работники образовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("41C02A83-14DD-41EC-9EEB-6718FEBD53D5"),
          Level = ScopeOfActivityLevel.Level1,
          NameOfScope = "Гос. Служащие"
        },
        new ScopeOfActivity
        {
          Id = new Guid("33934742-89F3-45E9-B094-A64816B352C3"),
          Level = ScopeOfActivityLevel.Level1,
          NameOfScope = "Незанятые лица по направлению службы занятости"
        },
        new ScopeOfActivity
        {
          Id = new Guid("6DEEDB35-3804-48BF-91A3-95D21F533E1B"),
          Level = ScopeOfActivityLevel.Level1,
          NameOfScope = "Другие"
        },

        new ScopeOfActivity
        {
          Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители предприятий и организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("14A416A5-6C4B-42EC-B256-93F7238F56E3"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители дошкольных образовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("ECF6A4DA-0136-4897-8559-4DF47BAF2E79"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители общеобразовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("E9D4ADE5-B78D-4CAC-B8CC-80EE1989C8FF"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители профессиональных образовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("508E21B1-99BE-48A6-BA6C-9F4F800EDC40"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители образовательных организаций ВО"
        },
        new ScopeOfActivity
        {
          Id = new Guid("C56BFF2C-CF4A-4133-8EB9-D06043AF561F"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители организаций ДПО"
        },
        new ScopeOfActivity
        {
          Id = new Guid("CA4DC6F3-34D4-41EA-A9B4-D890C31754DC"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители организаций дополнительного образования"
        },
        new ScopeOfActivity
        {
          Id = new Guid("6C1AC0BF-366B-4F03-9829-646BB8C24911"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники дошкольных образовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("C8F559AF-1F93-4B1F-B1BC-156E3FD86AD4"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники общеобразовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("AFC40C5A-CA03-4F23-91A8-DD055C86DB2D"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники профессиональных образовательных организаций"
        },
        new ScopeOfActivity
        {
          Id = new Guid("8F003E01-7866-42C3-8367-41780CEEA239"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники образовательных организаций ВО"
        },
        new ScopeOfActivity
        {
          Id = new Guid("91E7725A-ACAE-4156-B4D0-383483C5CC39"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники организаций ДПО"
        },
        new ScopeOfActivity
        {
          Id = new Guid("29D5F4D3-2D42-4980-8369-986C594A4D6B"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Педагогические работники организаций дополнительного образования"
        },
        new ScopeOfActivity
        {
          Id = new Guid("76342C39-145B-4153-9BD3-94BBCA00357E"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Руководители гос.служащие"
        },
        new ScopeOfActivity
        {
          Id = new Guid("791B9C31-4A87-4CF7-9F0B-9F0C14DFE3E1"),
          Level = ScopeOfActivityLevel.Level2,
          NameOfScope = "Безработные"
        }
    );
    modelBuilder.Entity<TypeEducation>().HasData(
        new TypeEducation
        {
          Id = new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
          Name = "Высшее образование"
        },
        new TypeEducation
        {
          Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
          Name = "Среднее профессиональное образование"
        },
        new TypeEducation
        {
          Id = new Guid("60AB01D9-0B9E-47D4-8623-C4F441276365"),
          Name = "Студент ВО"
        },
        new TypeEducation
        {
          Id = new Guid("48658492-AA7F-4763-ABAA-7FB958CBA87B"),
          Name = "Студент СПО"
        }
    );
    modelBuilder.Entity<StudentStatus>().HasData(
        new StudentStatus
        {
          Id = new Guid("8877A2F7-B866-4881-922C-C2BAA9D1C7EF"),
          Name = "обучение"
        },
        new StudentStatus
        {
          Id = new Guid("8FA04109-EF98-4CBD-B5A9-0799ECE57097"),
          Name = "отчислен"
        },
        new StudentStatus
        {
          Id = new Guid("BC233A40-66CE-4AC3-9BC4-323A083A4351"),
          Name = "завершил"
        }
    );
    modelBuilder.Entity<KindDocumentRiseQualification>().HasData(
        new KindDocumentRiseQualification
        {
          Id = new Guid("45146B2D-274F-4541-BF85-50D441503944"),
          Name = "Удостоверение о повышении квалификации"
        },
        new KindDocumentRiseQualification
        {
          Id = new Guid("85F88509-87AE-42EB-99CE-9CDB07918138"),
          Name = "Диплом о профессиональной переподготовке"
        }
    );
    modelBuilder.Entity<DocumentRiseQualification>().HasData(
        new DocumentRiseQualification
        {
          Id = new Guid("8A42A22F-FCE7-441F-965F-F7FEDDF38F3D"),
          KindDocumentRiseQualificationId = new Guid("45146B2D-274F-4541-BF85-50D441503944"),
          Date = new DateTime(2024, 8, 29), //возможно поменять на DateOnly
          Number = "ФЕ 34"
        }
    );
    modelBuilder.Entity<FinancingType>().HasData(
        new FinancingType
        {
          Id = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          SourceName = "За счет бюджетных ассигнований федерального бюджета"
        },
        new FinancingType
        {
          Id = new Guid("2C89D40C-FEAB-495B-A7AD-173930081862"),
          SourceName = "За счет бюджетных ассигнований бюджетов субъектов РФ"
        },
        new FinancingType
        {
          Id = new Guid("D8DB8FF7-7AF8-43F3-B258-A61D28F5B022"),
          SourceName = "За счет бюджетных ассигнований местных бюджетов"
        },
        new FinancingType
        {
          Id = new Guid("EFD7B981-2B64-4803-B331-B1674775F599"),
          SourceName = "По договорам за счет средств физических лиц"
        },
        new FinancingType
        {
          Id = new Guid("6B311D2C-3394-4285-9B6B-799E9A852E4F"),
          SourceName = "По договорам за счет средств юридических лиц"
        },
        new FinancingType
        {
          Id = new Guid("1A5F57E6-0F03-4810-BF9F-BEAAAB0075E5"),
          SourceName = "За счет собственных средств организации"
        }
    );
    modelBuilder.Entity<EducationProgram>().HasData(
        new EducationProgram
        {
          Id = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          Name = "Бизнес-анализ для специалистов с начальным уровнем подготовки",
          HoursCount = 72,
          EducationFormId = new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48"),
          //EducationForm = EducationForms!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48")))!,
          IsModularProgram = false,
          FEAProgramId = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
          IsCollegeProgram = false,
          Cost = 1234.5,
          FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          //FinancingType = FinancingTypes!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D")))!,
          KindDocumentRiseQualificationId = new Guid("45146B2D-274F-4541-BF85-50D441503944"),
          IsArchive = false,
          IsNetworkProgram = false,
          IsDOTProgram = false,
          IsFullDOTProgram = false,
          //KindDocumentRiseQualification = KindDocumentRiseQualifications!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("45146B2D-274F-4541-BF85-50D441503944")))!
        },
        new EducationProgram
        {
          Id = new Guid("2B693FEB-55AB-44C4-8A5E-D61D074C23FE"),
          Name = "Проектирование на языке C#",
          HoursCount = 72,
          EducationFormId = new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48"),
          //EducationForm = EducationForms!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48")))!,
          IsModularProgram = false,
          FEAProgramId = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
          IsCollegeProgram = false,
          Cost = 54.7,
          FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          //FinancingType = FinancingTypes!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D")))!,
          KindDocumentRiseQualificationId = new Guid("45146B2D-274F-4541-BF85-50D441503944"),
          IsNetworkProgram = false,
          IsDOTProgram = false,
          IsFullDOTProgram = false,
          IsArchive = false
          //KindDocumentRiseQualification = KindDocumentRiseQualifications!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("45146B2D-274F-4541-BF85-50D441503944")))!
        }
    );
    modelBuilder.Entity<Request>().HasData(
        new Request
        {
          Id = new Guid("6A4D3929-B049-4400-80EF-264C90914F61"),
          EducationProgramId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          DocumentRiseQualificationId = new Guid("8A42A22F-FCE7-441F-965F-F7FEDDF38F3D"),
          //Interview = "Прошел",
          //BirthDate = new DateOnly(1990, 5, 10),
          //CreatedAt = new DateTime(2023, 10, 15, 8, 0, 0),
          Phone = "+7 (123) 456-78-90",
          Email = "fff@mail.ru",
          //EntranceExamination = "Прошел",
          //FullName = "Иванов Иван Иванович",
          //StudentStatusId = new Guid("8877A2F7-B866-4881-922C-C2BAA9D1C7EF"),
          //StudentEducationId = new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
          //Disability = false,
          //FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          //ScopeOfActivityLv1Id = new Guid("6C3776FC-F3AC-4F4A-92D5-1E94A5596F6A"),
          //ScopeOfActivityLv2Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
          //JobResult = "Работаю",
          //OrderOfAdmission = "Приказ №1 от 01.01.2021",
          //Address = "г. Москва, ул. Ленина, д. 1, кв. 1",
          //Speciality = "Инженер-программист",
          //JobCV = "Опыть в IT 10 лет",
          DataNumberDogovor = "Договор №1 от 01.01.2021", //вернуть на EducationContract
                                                          //EducationContract = "Договор №1 от 01.01.2021",
                                                          //DocumentTypeId = new Guid("00B61F12-84FD-4352-B9BD-BF697642E307")
          StatusRequestId = new Guid("949A5221-63E6-4A92-BDBC-3BE7ACB6CDDD"),
          Agreement = true
        },
        new Request
        {
          Id = new Guid("7BFC4F24-7F38-4F3F-9B17-1A0C82323DBB"),
          EducationProgramId = new Guid("2B693FEB-55AB-44C4-8A5E-D61D074C23FE"),
          Email = "student2@mail.ru",
          //Interview = "Прошел",
          //BirthDate = new DateOnly(1995, 1, 22),
          //CreatedAt = new DateTime(2023, 09, 16, 12, 45, 0),
          Phone = "+7 (123) 456-32-90",
          //EntranceExamination = "Прошел",
          //FullName = "Петров Петр Петрович",
          //StudentEducationId = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
          //StudentStatusId = new Guid("8FA04109-EF98-4CBD-B5A9-0799ECE57097"),
          //Disability = false,
          //FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
          //ScopeOfActivityLv1Id = new Guid("6C3776FC-F3AC-4F4A-92D5-1E94A5596F6A"),
          //ScopeOfActivityLv2Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
          //JobResult = "Работаю",
          //OrderOfAdmission = "Приказ №1 от 01.01.2021",
          //Address = "г. Москва, ул. Ленина, д. 1, кв. 1",
          //Speciality = "Инженер-программист",
          //JobCV = "Опыть в IT 10 лет",
          //EducationContract = "Договор №1 от 01.01.2021",
          DataNumberDogovor = "Договор №1 от 01.01.2021", //вернуть на EducationContract
                                                          //DocumentTypeId = new Guid("00B61F12-84FD-4352-B9BD-BF697642E307"),
          StudentId = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6"),
          StatusRequestId = new Guid("949A5221-63E6-4A92-BDBC-3BE7ACB6CDDD"),
          StudentStatusId = new Guid("8877A2F7-B866-4881-922C-C2BAA9D1C7EF"),
          Agreement = true
        }
    );
    modelBuilder.Entity<Group>().HasData(
        new Group
        {
          Id = new Guid("1D60B8BB-83E7-4410-A53B-7E46ADA4EBD6"),
          EducationProgramId = new Guid("2B693FEB-55AB-44C4-8A5E-D61D074C23FE"),
          StartDate = new DateOnly(2023, 12, 1),
          EndDate = new DateOnly(2023, 12, 31),
          Name = "Группа 1"
        }
    );
    modelBuilder.Entity<KindOrder>().HasData(
        new KindOrder
        {
          Id = new Guid("CE1395D6-7696-4903-840B-4EAB48120D8F"),
          Name = "О зачислении"
        },
        new KindOrder
        {
          Id = new Guid("88DD5DAF-2272-4FC3-9D65-82E65B09266D"),
          Name = "Об отчислении"
        }
    );
    modelBuilder.Entity<Order>().HasData(
        new Order
        {
          Id = new Guid("C9D7307E-F019-416E-9677-50EC9377D4FB"),
          Number = "xxx 55",
          Date = new DateTime(2024, 8, 29),
          KindOrderId = new Guid("CE1395D6-7696-4903-840B-4EAB48120D8F"),
          RequestId = new Guid("6A4D3929-B049-4400-80EF-264C90914F61"),
          //KindOrder = KindOrders!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("CE1395D6-7696-4903-840B-4EAB48120D8F")))!,
          //Request = Requests!.AsNoTracking().FirstOrDefault(x => x.Id!.Equals(new Guid("6A4D3929-B049-4400-80EF-264C90914F61")))!
        }
    );
    modelBuilder.Entity<Student>().HasData(
        new Student
        {
          Id = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6"),
          BirthDate = new DateOnly(1990,
            5,
            10),
          Family = "Иванов",
          Name = "Иван",
          Patron = "Иванович",
          Nationality = "РФ",
          DocumentNumber = "АААА123456",
          DocumentSeries = "1234",
          SNILS = "123-456-789 00",
          Email = "test@mail.ru",
          Phone = "+7 (123) 456-32-90",
          FullNameDocument = "Эх, сейчас бы сиды полные",
          Address = "Иваново",
          IT_Experience = "Какой-то опыт есть",
          TypeEducationId = new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
          Sex = SexHuman.Woman,
          ScopeOfActivityLevelOneId = default
        }
    );
    modelBuilder.Entity<GroupStudent>().HasData(
        new GroupStudent
        {
          StudentsId = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6"),
          GroupsId = new Guid("1D60B8BB-83E7-4410-A53B-7E46ADA4EBD6")
        }
    );

    #endregion
  }
}
