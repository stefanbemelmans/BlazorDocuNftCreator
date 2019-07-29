using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace nt.Shared.Features.WebThree
{
  [FunctionOutput]
  public class TokenInfo 
  {
    public TokenInfo() { }

    [Parameter(type: "string", name: "name", order: 1)]
    public string Name { get; set; }  
    [Parameter(type: "uint", name: "type", order: 2)]
    public uint TemplateType { get; set; }

  }
}
