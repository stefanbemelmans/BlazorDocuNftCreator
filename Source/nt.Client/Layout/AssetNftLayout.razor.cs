namespace nt.Client.Layout
{
  using BlazorState.Services;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Components.Layouts;
  using nt.Client.Features.Nft;

  public class AssetNftLayoutModel : LayoutComponentBase
  {
    public string AddressFromEdge { get; set; }
    public int NftTemplateTypes { get; set; }


  }
}
