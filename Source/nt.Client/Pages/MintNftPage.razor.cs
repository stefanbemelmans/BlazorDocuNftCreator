namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Shared.Features.WebThree;

  public class MintNftPageModel : BaseComponent
  {
    // These values are gotten in the AssetNftPageModel
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
