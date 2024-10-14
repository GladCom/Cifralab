using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
  /// <summary>
  /// Репозиторий ВЭД программ.
  /// </summary>
  public class FEAProgramRepository : GenericRepository<FEAProgram>, IFEAProgramRepository
  {
    #region Поля и свойства

    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly StudentContext _ctx;

    /// <summary>
    /// Список ВЭД программ для первичного добавления в справочник.
    /// </summary>
    private static string[] feaPrograms =
      {"Сельское, лесное хозяйство, охота, рыболовство и рыбоводство",
      "Добыча полезных ископаемых",
      "Обрабатывающие производства",
      "Обеспечение электрической энергией, газом и паром; кондиционирование воздуха",
      "Водоснабжение, водоотведение, организация сбора и утилизации отходов, деятельность по ликвидации загрязнений",
      "Строительство",
      "Торговля оптовая и розничная; ремонт автотранспортных средств и мотоциклов",
      "Транспортировка и хранение",
      "Деятельность гостиниц и предприятий общественного питания",
      "Деятельность в области информации и связи",
      "Деятельность финансовая и страховая",
      "Деятельность по операциям с недвижимым имуществом",
      "Деятельность профессиональная, научная и техническая",
      "Деятельность административная и сопутствующие дополнительные услуги",
      "Государственное управление и обеспечение военной безопасности; социальное обеспечение",
      "Образование",
      "Деятельность в области здравоохранения и социальных услуг",
      "Деятельность в области культуры, спорта, организации досуг и развлечений",
      "Предоставление прочих видов услуг",
      "Деятельность домашних хозяйств как работодателей; недифференцированная деятельность частных домашних хозяйств" ,
      "Деятельность экстерриториальных организаций и органов"};

    #endregion

    #region Методы

    /// <summary>
    /// Добавить в справочник ВЭД первоначального набора данных.
    /// </summary>
    public async Task AddSeedData()
    {
      bool needToSave = false;
      foreach (var feaprogram in feaPrograms)
      {
        if (_ctx.FEAPrograms.Where(e => e.Name != null && e.Name.Trim() == feaprogram).FirstOrDefault() == null)
        {
          _ctx.FEAPrograms.Add(new FEAProgram() { Id = Guid.NewGuid(), Name = feaprogram });
          needToSave = true;
        }
      }
      if (needToSave)
      {
        await _ctx.SaveChangesAsync();
      }
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public FEAProgramRepository(StudentContext context) : base(context)
    {
      _ctx = context;
    }

    #endregion
  }
}
