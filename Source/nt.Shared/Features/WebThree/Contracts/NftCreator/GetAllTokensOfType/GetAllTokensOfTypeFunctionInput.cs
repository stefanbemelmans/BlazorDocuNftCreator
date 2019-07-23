namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "getAllTokensofType")] 
  public class GetAllTokensOfTypeFunctionInput : FunctionMessage
  {
    [Parameter("uint", "_type", 1)]
    public uint GetAllTokensOfType { get; set; }
  }
}
