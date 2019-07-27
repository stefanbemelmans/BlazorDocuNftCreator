namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class RequestForProposalTemplate : TemplateFormBase
  {
    public const int NftId = 0;
    public RequestForProposalTemplate()
    {
      TemplateBaseInfo.Name = "Request For Proposal";
      TemplateBaseInfo.Symbol = "RFQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;
    }

    public string CompanyName { get; set; }
    public string AddressParcel { get; set; }
    public string Requirement { get; set; }
    public string Deadline { get; set; }
    public string AcceptanceCriteria { get; set; }
    public string ModeofTransport { get; set; }
    public string ContactEmail { get; set; }
    public string Budget { get; set; }
    public string EquivalentSubstitution { get; set; }

  }
}

