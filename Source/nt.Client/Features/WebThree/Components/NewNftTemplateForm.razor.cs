namespace nt.Client.Features.WebThree.Components
{
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  public class NewNftTemplateFormModel : BaseComponent
    {
        [Parameter]
      public ImmutableDataObjectBase CurrentTemplateForm { get; set; } 

    }
}