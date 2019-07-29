namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System;
  using System.Collections.Generic;

  public class PurchaseRequestTemplate : TemplateFormBase
  {
    public const int NftId = 4;
    public PurchaseRequestTemplate()
    {
      TemplateBaseInfo.Name = "Purchase Request";
      TemplateBaseInfo.Symbol = "PRQ";
      TemplateBaseInfo.MintLimit = 5;
      TemplateBaseInfo.AttachedTokens = 0;
    }

    public int StockNumber { get; set; }
    public string Description { get; set; }
    public int Qty { get; set; }
    public int UnitPrice { get; set; }
    public int ExtendedCost { get; set; }
    public DateTime Date { get; set; }
    public string Requester { get; set; }
    public string Department { get; set; }
    public string ChargeTo { get; set; }
    public string Vendor { get; set; }
    public string VendorAddress { get; set; }
    public string VendorContact { get; set; }
    public string Phone { get; set; }
    public DateTime DateNeeded { get; set; }
    public string ShipVia { get; set; }
  };
}



