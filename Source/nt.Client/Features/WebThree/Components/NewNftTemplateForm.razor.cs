namespace nt.Client.Features.WebThree.Components
{
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;

  public class NewNftTemplateFormModel : BaseComponent
    {
        [Parameter]
      public NftTemplate NewTemplateForm { get; set; } 

    }
}