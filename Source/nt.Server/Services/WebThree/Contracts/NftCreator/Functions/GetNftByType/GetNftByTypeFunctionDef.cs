namespace nt.Client.Server.Services.WebThree.NftCreator.Functions.GetNftByType
{   // [Function("name", "return type")]
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "getNFTData")] // This works
  public class GetNftByTypeFunctionDef : FunctionMessage
  {
    [Parameter("uint", "id", 1)]
    public int NftId { get; set; }
  }
}
