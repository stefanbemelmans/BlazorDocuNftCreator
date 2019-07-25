namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class RequestForProposalTemplate : TemplateFormBase
  {
    public RequestForProposalTemplate()
    {
       NftId = 0;
      TemplateBaseInfo.Name = "Request For Proposal";
      TemplateBaseInfo.Symbol = "RFQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;

      TemplateFormData = new Dictionary<string, string>()
      {
        {"Company Name","" },
        {"AddressParcel","" },
        {"Requirement",""},
        {"Deadline","" },
        {"AcceptanceCriteria","" },
        {"ModeofTransport","" },
        {"ContactEmail","" },
        {"Budget","" },
        {"EquivalentSubstitution","" }
      };
    }
  }
}

