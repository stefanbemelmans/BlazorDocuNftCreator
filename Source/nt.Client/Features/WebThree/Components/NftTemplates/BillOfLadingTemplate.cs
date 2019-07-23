namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

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
