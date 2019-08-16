namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Shared.Features.WebThree;

  public class TokenBase

  {
    public int Balance { get; set; }
    public string Data { get; set; }

    // Changing Object to ImmutableObjectBase that contains the Immutable DataProperty
    public ImmutableObjectBase DataObject { get; set; }

    public string MutableData { get; set; }
    public PurchaseOrderData PurchaseOrderData { get; set; }
    public NftTemplate TemplateData { get; set; }
    public uint NftId { get; set; }
    public uint TokenId { get; set; }
  }
}