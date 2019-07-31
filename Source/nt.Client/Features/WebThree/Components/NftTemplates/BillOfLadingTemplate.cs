namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using nt.Shared.Features.WebThree;
  using System;
  using System.Collections.Generic;

  public class BillOfLadingTemplate : TemplateFormBase
  {
    public BillOfLadingTemplate()
    {
      NftId = 5;
      Name = "Bill Of Lading";
      Symbol = "BOL";
      MintLimit = 1000;
      AttachedTokens = 0;
    }

    public string Lading { get; set; } 
    public string Order { get; set; }
    public string PO { get; set; }
    public DateTime Date { get; set; }
    public string Carrier { get; set; }
    public string Shipper { get; set; }
    public string Consignee { get; set; }
    public string Instructions { get; set; }
    public string ItemCode { get; set; }
    public string Quantity { get; set; }
    public string Weight { get; set; }
    public string Details { get; set; }
  }
}
