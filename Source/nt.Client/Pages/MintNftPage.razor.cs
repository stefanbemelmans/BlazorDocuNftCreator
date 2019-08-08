namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Shared.Features.WebThree;
    using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Features.WebThree.Components.NftTemplates;

  public class MintNftPageModel : BaseComponent
  {
    // These values are gotten in the AssetNftPageModel Init
    public uint TotalNfts
    {
      get => WebThreeState.TotalNftTypes;
      set { }
    }
    public NftTemplate CurrentNftTemplate
    {
      get => WebThreeState.CurrentNftTemplate;
      set { }
    }

   
  }
}
