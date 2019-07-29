using System;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class PurchaseOrderTemplate : TemplateFormBase
  {
    public PurchaseOrderTemplate()
    {
      TemplateBaseInfo.Name = "Purchase Order";
      TemplateBaseInfo.Symbol = "POT";
      TemplateBaseInfo.MintLimit = 1000;
      TemplateBaseInfo.AttachedTokens = 0;
    }

    public const int NftId = 1;
    public string Approver { get; set; } = "";
    public DateTime DeliveryDate => DateTime.Now;
    public string Department { get; set; } = "";
    public string Notes { get; set; } = "";
    public string Requester { get; set; } = "";
    public ItemTemplate ItemTemplate { get; set; }
  }
  public class ItemTemplate
  {
    public string Code { get; set; } = "";
    public string Discount { get; set; } = "";
    public string Name { get; set; } = "";
    public string Price { get; set; } = "";
    public int Qty { get; set; } = 0;
    public int Total { get; set; } = 0;

  }

}