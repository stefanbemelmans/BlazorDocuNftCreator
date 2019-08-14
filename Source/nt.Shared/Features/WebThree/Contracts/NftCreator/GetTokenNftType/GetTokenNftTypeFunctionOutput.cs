using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace nt.Shared.Features.WebThree
{
  [FunctionOutput]
  public class GetTokenNftTypeFunctionOutput : IFunctionOutputDTO
  {
    [Parameter(type: "uint", 1)]
    public uint NftId { get; set; }
   
  }
}
