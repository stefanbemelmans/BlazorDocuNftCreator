namespace nt.Client.Features.WebThree.Components.NftTemplates.RequestForProposal
{
  using nt.Client.Features.WebThree.Components.NftTemplates;

  public class RequestForProposalData : ImmutableObjectBase
  {
    public string AcceptanceCriteria { get; set; }
    public string AddressParcel { get; set; }
    public string Budget { get; set; }
    public string CompanyName { get; set; }
    public string ContactEmail { get; set; }
    public string Deadline { get; set; }
    public string EquivalentSubstitution { get; set; }
    public string ModeofTransport { get; set; }
    public string Requirement { get; set; }
  }
}