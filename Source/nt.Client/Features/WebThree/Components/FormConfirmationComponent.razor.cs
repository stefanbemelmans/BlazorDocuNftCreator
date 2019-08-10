namespace nt.Client.Features.WebThree.Components
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.Base.Components;

  public class FormConfirmationComponentModel : BaseComponent
  {
    [Parameter]
   public ImmutableObjectBase FormData { get; set; }

    [Parameter]
    public string MutableDataString { get; set; }


  }
}
