namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections;
  using System.Collections.Generic;
  using nt.Shared.Features.WebThree;

  public class TemplateFormBase : IEnumerable
  {
    public TemplateFormBase()
    {
      TemplateBaseInfo = new NftTemplate();
    }

    // I was thinking on render to put together the NftTemplate which is the Base Immutable Data with the 
    // TemplateFormData and potential ItemFormData
    public NftTemplate TemplateBaseInfo { get; private set; } 

    public IEnumerator GetEnumerator() => throw new System.NotImplementedException();
  }
}
