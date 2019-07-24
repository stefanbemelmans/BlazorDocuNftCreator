namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class BillOfLadingTemplate : TemplateFormBase
  {
    public BillOfLadingTemplate()
    {
      NftId = 6;
      TemplateBaseInfo.Id = NftId;
      TemplateBaseInfo.Name = "Bill of Lading";
      TemplateBaseInfo.Symbol = "BOL";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;


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
