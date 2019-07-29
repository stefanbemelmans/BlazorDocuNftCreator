namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using System.Collections.Generic;

  public class AssetNftPageModel : BaseComponent
  {

    public int TotalTokens { get; set; }

    public List<uint> CurrentTokenIds { get; set; }

  }

}
