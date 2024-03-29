﻿namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{   // [Function("name", "return type")]
  using Nethereum.ABI.FunctionEncoding.Attributes;

  [FunctionOutput]  // This works
  public class GetNftByTypeOutputDto : IFunctionOutputDTO
  {
    [Parameter("string", "tokentype.name", 1)]
    public string TokenName { get; set; }

    [Parameter("string", "tokentype.symbol", 2)]
    public string TokenSymbol { get; set; }

    [Parameter("uint", "tokentype.mintlimit", 3)]
    public int TokenMintLimit { get; set; }

    [Parameter("uint", "tokentype.attachedTokens", 4)]
    public int TokenAttachedTokens { get; set; }

  }
}
