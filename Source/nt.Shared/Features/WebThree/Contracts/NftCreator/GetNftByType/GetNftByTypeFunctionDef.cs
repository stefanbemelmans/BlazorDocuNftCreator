namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "getNFTData")] // This works
  public class GetNftByTypeFunctionDef : FunctionMessage
  {
    [Parameter("uint", "id", 1)]
    public int NftId { get; set; }
  }
}
