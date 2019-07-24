namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class PurchaseRequestTemplate : TemplateFormBase
  {
    public PurchaseRequestTemplate()
    {
      NftId = 4;

      TemplateBaseInfo.Id = NftId;
      TemplateBaseInfo.Name = "Purchase Request";
      TemplateBaseInfo.Symbol = "PRQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;
      ItemFormData = new Dictionary<string, string>()

      {
        {"StockNumber", ""},
        {"Description", "" },
        {"Qty", "" },
        {"UnitPrice", "" },
        {"ExtendedCost", "" }

      };

      TemplateFormData = new Dictionary<string, string>()
      {
        {"Date", "" },
        {"Requester", "" },
        {"Department", "" },
        {"ChargeTo", "" },
        {"Vendor", "" },
        {"VendorAddress", "" },
        {"VendorContact", "" },
        {"Phone", "" },
        {"DateNeeded", "" },
        {"ShipVia", "" }
      };
    }
  }
}
