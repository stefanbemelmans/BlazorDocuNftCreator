namespace nt.Client.Pages
{
    using nt.Client.Features.Base.Components;
    using nt.Client.Features.Nft.Components;

  public class AssetNftPageModel : BaseComponent
  {
    public int HercBalance { get; set; } = 123;

    public string Address { get; set; }

    public int NftTypes { get; set; }

    public int TotalNfts { get; set; }
    public int NftTypeToGet { get; set; }

      NftTemplate NftTemplate = new NftTemplate();

     
    }

}
