using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class RequestForQuotationTemplate
  {
    public readonly int NftId = 1;
    struct RequestForQuotation
    {
     public uint DeliveryTerms { get; set; }
     public uint CustomClearance { get; set; }
     public string UNDPprefered { get; set; }
     public bool LatestExpectedDeliveryData { get; set; }
     public bool DeliverySchedule { get; set; }
     public uint ModeOfTransport { get; set; }
     public uint AfterSalesService { get; set; }
     public uint Deadline { get; set; }
     public uint DocumentationLanguage { get; set; }
     public uint PeriodOfValidity { get; set; }
     public bool PartialQuotes { get; set; }
     public uint PaymentTerms { get; set; }
     public uint Awardees { get; set; }
     public uint ConctractType { get; set; }
     public bool CancelationPolicy { get; set; }
     public uint ConditionsOfRelease { get; set; }
     public string Contract { get; set; }
     public string EquivalentSubstitution { get; set; }

    }
  }
}
