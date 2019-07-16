namespace nt.Client.Pages.Nft
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.Nft.Compnents;

  public class AssetNftPageModel : BaseComponent
    {
      public int HercBalance {get; set;} = 123;

      public string Address {get; set; }

      public int NftTypes {get; set; }

      public int TotalNfts {get; set; }

      NftTemplate NftTemplate = new NftTemplate();

      public async Task GetNftByType()
        {



        }
    }

}
