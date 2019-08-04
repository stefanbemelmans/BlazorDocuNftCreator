using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class TesterNftTemplate : TemplateBase
  {
    public TesterNftTemplate()
    {
      Name = "Tester Nft Template";
      Symbol = "TNT";
      MintLimit = 42;
      AttachedTokens = 0;
      //NftProps = new Dictionary<string, string>()
      //{
      //  { ImportantNumber1Of2, "one" },
      //  { ImportantWord1of2, "Important" },
      //  { ImportantNumber2of2, "42" },
      //  { ImportantWord2of2, "Word" },
      //  { Date, DateTime.Now.ToString() }

      //};

    }

    public string ImportantNumber1Of2 = "ImportantNumber1Of2";
    public string ImportantWord1of2 = "ImportantWord1of2";
    public string ImportantWord2of2 = "ImportantWord2of2";
    public string Date = "Date";
    public string ImportantNumber2of2 = "ImportantNumber2of2";
  }
}
