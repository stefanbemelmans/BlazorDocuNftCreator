using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class RequestForQuotationTemplate : TemplateFormBase
  {
    public RequestForQuotationTemplate()
    {
      NftId = 1;
      TemplateBaseInfo.Name = "Request For Quotation";
      TemplateBaseInfo.Symbol = "RFQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;

      TemplateFormData = new Dictionary<string, string>()
      {
        { "DeliveryTerms", "" },
        { "CustomClearance", "" },
        { "UNDPprefered", "" },
        { "LatestExpectedDeliveryData", "" },
        { "DeliverySchedule", "" },
        { "ModeOfTransport", "" },
        { "AfterSalesService", "" },
        { "Deadline", "" },
        { "DocumentationLanguage", "" },
        { "PeriodOfValidity", "" },
        { "PartialQuotes", "" },
        { "PaymentTerms", "" },
        { "Awardees", "" },
        { "ConctractType", "" },
        { "CancelationPolicy", "" },
        { "ConditionsOfRelease", "" },
        { "Contract", "" },
        { "EquivalentSubstitution", "" }
      };
    }
  }
}
