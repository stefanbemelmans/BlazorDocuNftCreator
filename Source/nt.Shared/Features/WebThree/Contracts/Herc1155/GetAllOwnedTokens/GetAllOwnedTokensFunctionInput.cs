namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Web3.Accounts;
  using Nethereum.Contracts;

  [Function(name: "getAllOwnedTokens")] // This works
  public class GetAllOwnedTokensFunctionInput : FunctionMessage
  {
    [Parameter(type: "address", name: "owner", order: 1)]
    public string TokenOwner { get; set; } // this will be the default Edge Eth Address
  }
}
