namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class PurchaseOrderTemplate 
  {
    public int NftId = 1;
    struct PurchaseOrder
    {
      public string Approver { get; set; }
      public string DeliveryDate { get; set; }
      public string Department { get; set; }
      public string Notes { get; set; }
      public string Requester { get; set; }
    }

    struct ItemTemplate
    {
      public string Code { get; set; }
      public string Discount { get; set; }
      public string Name { get; set; }
      public string Price { get; set; }
      public string Qty { get; set; }
      public string Total { get; set; }

    }
  }
}