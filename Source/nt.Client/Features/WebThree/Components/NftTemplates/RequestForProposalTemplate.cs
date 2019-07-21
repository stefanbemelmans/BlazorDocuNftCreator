using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class RequestForProposalTemplate : TemplateForm
  {
    public RequestForProposalTemplate()
    {
       NftId = 0;
       TemplateFormName = "Request For Proposal";

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

