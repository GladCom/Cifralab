using Microsoft.EntityFrameworkCore;
using Students.Models;

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
            new EducationForm { Id = Guid.NewGuid(), Name = "Заочная" },
            new EducationForm { Id = Guid.NewGuid(), Name = "Очно-заочная" }
        );
        modelBuilder.Entity<EducationType>().HasData(
            new EducationType
                { Id = new Guid("7EDA9352-0057-4CBD-A102-B0F817A9F3DC"), Name = "Программа повышения квалификации" },
            new EducationType { Id = Guid.NewGuid(), Name = "Программа профессиональной переподготовки" }
        );
        modelBuilder.Entity<FEAProgram>().HasData(
            new FEAProgram
            {
                Id = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
                Name = "Сельское, лесное хозяйство, охота, рыболовство и рыбоводство"
            },
            new FEAProgram { Id = Guid.NewGuid(), Name = "Добыча полезных ископаемых" },
            new FEAProgram { Id = Guid.NewGuid(), Name = "Обрабатывающие производства" },
            new FEAProgram
            {
                Id = Guid.NewGuid(),
                Name = "Обеспечение электрической энергией, газом и паром; кондиционирование воздуха"
            }
        );
        modelBuilder.Entity<EducationProgram>().HasData(
            new EducationProgram
            {
                Id = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
                Name = "Бизнес-анализ для специалистов с начальным уровнем подготовки",
                HoursCount = 72,
                EducationTypeId = new Guid("7EDA9352-0057-4CBD-A102-B0F817A9F3DC"),
                EducationFormId = new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48"),
                IsNetworkProgram = false,
                IsDOTProgram = false,
                IsModularProgram = false,
                FEAProgramId = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
                IsCollegeProgram = false
            },
            new EducationProgram
            {
                Id = new Guid("2B693FEB-55AB-44C4-8A5E-D61D074C23FE"),
                Name = "Проектирование на языке C#",
                HoursCount = 72,
                EducationTypeId = new Guid("7EDA9352-0057-4CBD-A102-B0F817A9F3DC"),
                EducationFormId = new Guid("64FC4EA9-FEA1-4EA5-A20F-F33C42438D48"),
                IsNetworkProgram = false,
                IsDOTProgram = false,
                IsModularProgram = false,
                FEAProgramId = new Guid("7DBA8AC7-4A5C-4412-A2D9-D4E4B654ED6E"),
                IsCollegeProgram = false
            }
        );

        modelBuilder.Entity<FinancingType>().HasData(
            new FinancingType
            {
                Id = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
                SourceName = "За счет бюджетных ассигнований федерального бюджета"
            },
            new FinancingType
                { Id = Guid.NewGuid(), SourceName = "За счет бюджетных ассигнований бюджетов субъектов РФ" }
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
                Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                Level = ScopeOfActivityLevel.Level2,
                NameOfScope = "Руководители предприятий и организаций"
            }
        );
        modelBuilder.Entity<StudentDocument>().HasData(
            new StudentDocument
            {
                Id = new Guid("00B61F12-84FD-4352-B9BD-BF697642E307"),
                Name = "Удостоверение о повышении квалификации"
            },
            new StudentDocument
            {
                Id = new Guid("4304E2DF-513F-4C1C-8CA8-7E21B1D91EF3"),
                Name = "Диплом о профессиональной переподготовке"
            }
        );
        modelBuilder.Entity<StudentEducation>().HasData(
            new StudentEducation
            {
                Id = new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
                Name = "Высшее образование"
            },
            new StudentEducation
            {
                Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                Name = "Среднее профессиональное образование"
            }
        );
        modelBuilder.Entity<StudentStatus>().HasData(
            new StudentStatus
            {
                Id = new Guid("8877A2F7-B866-4881-922C-C2BAA9D1C7EF"),
                Name = "Абитуриент"
            },
            new StudentStatus
            {
                Id = new Guid("8FA04109-EF98-4CBD-B5A9-0799ECE57097"),
                Name = "Обучается"
            }
        );
        modelBuilder.Entity<Request>().HasData(
            new Request
            {
                Id = new Guid("6A4D3929-B049-4400-80EF-264C90914F61"),
                EducationProgramId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
                Email = "student1@mail.ru",
                Interview = "Прошел",
                BirthDate = new DateOnly(1990, 5, 10),
                CreatedAt = new DateTime(2023, 10, 15, 8, 0, 0),
                Phone = "+71234567890",
                EntranceExamination = "Прошел",
                FullName = "Иванов Иван Иванович",
                StudentStatusId = new Guid("8877A2F7-B866-4881-922C-C2BAA9D1C7EF"),
                StudentEducationId = new Guid("7CF2BA34-080B-4FEF-8BFE-83731AC54742"),
                Disability = false,
                FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
                ScopeOfActivityLv1Id = new Guid("6C3776FC-F3AC-4F4A-92D5-1E94A5596F6A"),
                ScopeOfActivityLv2Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                JobResult = "Работаю",
                OrderOfAdmission = "Приказ №1 от 01.01.2021",
                Address = "г. Москва, ул. Ленина, д. 1, кв. 1",
                Speciality = "Инженер-программист",
                JobCV = "Опыть в IT 10 лет",
                EducationContract = "Договор №1 от 01.01.2021",
                DocumentTypeId = new Guid("00B61F12-84FD-4352-B9BD-BF697642E307")
            },
            new Request
            {
                Id = new Guid("7BFC4F24-7F38-4F3F-9B17-1A0C82323DBB"),
                EducationProgramId = new Guid("2B693FEB-55AB-44C4-8A5E-D61D074C23FE"),
                Email = "student2@mail.ru",
                Interview = "Прошел",
                BirthDate = new DateOnly(1995, 1, 22),
                CreatedAt = new DateTime(2023, 09, 16, 12, 45, 0),
                Phone = "+71234567890",
                EntranceExamination = "Прошел",
                FullName = "Петров Петр Петрович",
                StudentEducationId = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                StudentStatusId = new Guid("8FA04109-EF98-4CBD-B5A9-0799ECE57097"),
                Disability = false,
                FinancingTypeId = new Guid("B3C907D0-B166-4D56-A378-8A3DE358093D"),
                ScopeOfActivityLv1Id = new Guid("6C3776FC-F3AC-4F4A-92D5-1E94A5596F6A"),
                ScopeOfActivityLv2Id = new Guid("38BD0222-68EC-4C0C-8F47-6E0FC6C9535D"),
                JobResult = "Работаю",
                OrderOfAdmission = "Приказ №1 от 01.01.2021",
                Address = "г. Москва, ул. Ленина, д. 1, кв. 1",
                Speciality = "Инженер-программист",
                JobCV = "Опыть в IT 10 лет",
                EducationContract = "Договор №1 от 01.01.2021",
                DocumentTypeId = new Guid("00B61F12-84FD-4352-B9BD-BF697642E307"),
                StudentId = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6")
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
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6"),
                BirthDate = new DateOnly(1990, 5, 10),
                FullName = "Иванов Иван Иванович",
                Nationality = "РФ",
                DocumentNumber = "АААА123456",
                DocumentSeries = "1234",
                SNILS = "123-456-789 00",
                Email = "test@mail.ru",
                Phone = "+71234567890",
                FullNameDocument = "Эх, сейчас бы сиды полные"
            }
        );
        modelBuilder.Entity<StudentInGroup>().HasData(
            new StudentInGroup
        	{
                StudentId = new Guid("6CCEA275-77D3-439F-9E20-E86C1B2952F6"),
                GroupId = new Guid("1D60B8BB-83E7-4410-A53B-7E46ADA4EBD6")
            }
        );

        #endregion
    }
}
