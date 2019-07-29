namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  public class AssetNftPageModel : BaseComponent
  {
    public int HercBalance { get; set; } = 123;

    public string Address { get; set; }

    public int TotalNfts { get; set; }
    public int NftTypeToGet { get; set; }


     
    }

}
