using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class TesterNftTemplate : TemplateFormBase
  {
    public TesterNftTemplate()
    {
      TemplateBaseInfo.Name = "TesterTemplate";
      TemplateBaseInfo.Symbol = "TEST";
      TemplateBaseInfo.MintLimit = 1000;
      TemplateBaseInfo.AttachedTokens = 0;
    }
    public int ImportantNumber1fo2 { get; set; }
    public string ImportantWord1of2 { get; set; }
    public string ImportantWord2of2 { get; set; }
    public DateTime Date { get; set; }
    public int ImportantNumber2of2 { get; set; }
  }
}
