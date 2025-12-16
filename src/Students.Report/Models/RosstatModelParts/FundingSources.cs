namespace Students.Reports.Models.RosstatModelParts;

public class FundingSources : PartialInfoRosstatModel
{
  public int FederalBudgetAdvanced { get; set; }
  public int RegionalBudgetAdvanced { get; set; }
  public int LocalBudgetAdvanced { get; set; }
  public int IndividualBudgetAdvanced { get; set; }
  public int CompanyBudgetAdvanced { get; set; }
  public int SelfBudgetAdvanced { get; set; }
  public int FederalBudgetRetraining { get; set; }
  public int RegionalBudgetRetraining { get; set; }
  public int LocalBudgetAdvancedRetraining { get; set; }
  public int IndividualBudgetRetraining { get; set; }
  public int CompanyBudgetRetraining { get; set; }
  public int SelfBudgetRetraining { get; set; }
}