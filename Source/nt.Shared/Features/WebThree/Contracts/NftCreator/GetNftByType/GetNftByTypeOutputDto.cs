namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{   // [Function("name", "return type")]
  using Nethereum.ABI.FunctionEncoding.Attributes;

  [FunctionOutput]  // This works
  public class GetNftByTypeOutputDto : IFunctionOutputDTO
  {
    [Parameter(type: "string", name: "name", 1)]
    public string Name { get; set; }
    [Parameter("string", "symbol", 2)]
    public string Symbol { get; set; }
    [Parameter("uint", "mintlimit", 3)]
    public uint MintLimit { get; set; }
    [Parameter("uint", "attachedTokens", 4)]
    public uint AttachedTokens { get; set; }

  }
}
