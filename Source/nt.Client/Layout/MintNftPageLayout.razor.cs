namespace nt.Client.Layout
{
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Components.Layouts;
  using nt.Client.Features.WebThree;
  using nt.Shared.Features.WebThree;

  public class MintNftPageLayoutModel :  LayoutComponentBase 
  {
    static WebThreeState WebThreeState { get; }
    public uint CurrentNftId = WebThreeState.CurrentNftTemplate.NftId;

  }
}
