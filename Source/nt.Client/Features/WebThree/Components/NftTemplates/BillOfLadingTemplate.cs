using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class BillOfLadingTemplate : TemplateForm
  {
    public BillOfLadingTemplate()
    {
      NftId = 6;
      TemplateFormName = "Bill of Lading";

      TemplateFormData = new Dictionary<string, string>()
      {
        {"Lading", ""},
        {"Order", ""},
        {"PO", ""},
        {"date", ""},
        {"Carrier", ""},
        {"Shipper", ""},
        {"Consignee", ""},
        {"Instructions", "" },
        {"ItemCode", ""},
        {"Quantity", ""},
        {"Weight", ""},
        {"Details", ""}
      };
    }
  }
}
