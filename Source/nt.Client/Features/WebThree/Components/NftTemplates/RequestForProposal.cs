using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class RequestForProposalTemplate 
  {
    public int NftId = 1;
    public string TemplateFormName = "Request For Proposal";

      Dictionary<string, string> TemplateFormData = new Dictionary<string, string>()
    {
        { "Company Name","" }
      string AddressParcel { get; set; }
      string Requirement { get; set; }
      string Deadline { get; set; }
      string AcceptanceCriteria { get; set; }
      string ModeofTransport { get; set; }
      string ContactEmail { get; set; }
      string Budget { get; set; }
      string EquivalentSubstitution { get; set; }
    }
  }
}
