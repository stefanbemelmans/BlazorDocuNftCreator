namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System;
  using System.Collections.Generic;

  public class BillOfLadingData : ImmutableObjectBase
  {
    public string Carrier { get; set; }
    public string Consignee { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }
    public string Instructions { get; set; }
    public string ItemCode { get; set; }
    public string Lading { get; set; }
    public string Order { get; set; }
    public string PO { get; set; }
    public string Quantity { get; set; }
    public string Shipper { get; set; }
    public string Weight { get; set; }
  }
}