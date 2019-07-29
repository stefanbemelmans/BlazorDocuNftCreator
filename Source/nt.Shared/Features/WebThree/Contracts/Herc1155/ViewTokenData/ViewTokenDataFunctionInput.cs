namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "viewTokenData")] // This works
  public class ViewTokenDataFunctionInput : FunctionMessage
  {
    [Parameter(type: "uint", name:"_id", order: 1)]
    public uint ViewTokenId { get; set; }
  }
}
