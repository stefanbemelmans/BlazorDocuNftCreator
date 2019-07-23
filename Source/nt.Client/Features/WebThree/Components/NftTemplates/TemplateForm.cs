namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections.Generic;

  public class TemplateForm
  {
    public int NftId { get; set; }

    public string TemplateFormName { get; set; } 
    public Dictionary<string,string> TemplateFormData { get; set; }
    public Dictionary<string, string> ItemFormData { get; set; }
  }
}
