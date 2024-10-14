using Students.Models;

namespace Students.DBCore.Migrations;

internal static class HasDataEntities
{
  public static List<FEAProgram> FEAProgramEntities { get; } = new()
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

  public static List<FinancingType> FinancingTypeEntities { get; } = new()
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
}
