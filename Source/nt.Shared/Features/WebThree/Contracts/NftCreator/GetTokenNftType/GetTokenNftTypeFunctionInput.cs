namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNFtType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "NFTTemplates")] 
  public class GetTokenNftTypeFunctionInput : FunctionMessage
  {
    [Parameter(type: "uint")]
    public uint TokenId { get; set; }
  }
}
