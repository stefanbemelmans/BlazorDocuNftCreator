namespace nt.Client.Features.WebThree.Components
{
  using nt.Shared.Features.WebThree;
  using nt.Client.Features.Base.Components;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;

  public class TokenInfoModel : BaseComponent
  {
    [Parameter]
    public TemplateBase TokenData { get; set; }
    public string TokenDataString { get; set; }
    public string MutableData { get; set; }


  }

}