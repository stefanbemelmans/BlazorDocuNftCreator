namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class RequestForProposalTemplate : TemplateBase
  {
    public RequestForProposalTemplate()
    {
      NftId = 0;
      Name = "Request For Proposal";
      Symbol = "RFQ";
      MintLimit = 5;
      AttachedTokens = 0;
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

