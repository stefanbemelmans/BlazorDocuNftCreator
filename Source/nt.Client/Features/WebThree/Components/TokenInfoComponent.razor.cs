namespace nt.Client.Features.WebThree.Components
{
  using nt.Shared.Features.WebThree;
  using nt.Client.Features.Base.Components;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;

  public class TokenInfoModel : BaseComponent
  {
    [Parameter]
    public TemplateFormBase TokenData { get; set; }
    [Parameter]
    public string MutableData { get; set; }


  }

}