namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "NFTTemplates")]
  public class GetNftByTypeFunctionInput : FunctionMessage
  {
    [Parameter(type: "uint")]
    public uint NftId { get; set; }
  }
}
