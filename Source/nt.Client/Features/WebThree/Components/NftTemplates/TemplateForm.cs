using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class TemplateForm
  {
    public int NftId { get; set; }

    public string TemplateFormName { get; set; } 
    public Dictionary<string,string> TemplateFormData { get; set; }
    public Dictionary<string, string> ItemFormData { get; set; }
  }
}
