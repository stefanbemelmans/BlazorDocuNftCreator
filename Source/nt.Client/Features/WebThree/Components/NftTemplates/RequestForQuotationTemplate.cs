namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class RequestForQuotationTemplate : TemplateFormBase
  {
    public const int NftId = 1;
    public RequestForQuotationTemplate()
    {
      TemplateBaseInfo.Name = "Request For Quotation";
      TemplateBaseInfo.Symbol = "RFQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;
    }
    public string DeliveryTerms { get; set; }
    public string CustomClearance { get; set; }
    public string UNDPprefered { get; set; }
    public string LatestExpectedDeliveryData { get; set; }
    public string DeliverySchedule { get; set; }
    public string ModeOfTransport { get; set; }
    public string AfterSalesService { get; set; }
    public string Deadline { get; set; }
    public string DocumentationLanguage { get; set; }
    public string PeriodOfValidity { get; set; }
    public string PartialQuotes { get; set; }
    public string PaymentTerms { get; set; }
    public string Awardees { get; set; }
    public string ConctractType { get; set; }
    public string CancelationPolicy { get; set; }
    public string ConditionsOfRelease { get; set; }
    public string Contract { get; set; }
    public string EquivalentSubstitution { get; set; }
  }
}
