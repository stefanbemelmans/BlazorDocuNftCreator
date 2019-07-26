namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;
  using nt.Shared.Features.WebThree;

  public class TemplateFormBase
  {
    public TemplateFormBase()
    {
      TemplateBaseInfo = new NftTemplate();
    }
    public int NftId { get; set; }
    // I was thinking on render to put together the NftTemplate which is the Base Immutable Data with the 
    // TemplateFormData and potential ItemFormData
    public NftTemplate TemplateBaseInfo { get; set; } 
    public Dictionary<string,string> TemplateFormData { get; set; }
    public Dictionary<string, string> ItemFormData { get; set; }
  }
}
