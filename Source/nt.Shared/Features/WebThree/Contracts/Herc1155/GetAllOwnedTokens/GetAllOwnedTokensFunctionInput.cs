namespace nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Web3.Accounts;
  using Nethereum.Contracts;
  using nt.Shared.Constants.AccountAddresses;

  [Function(name: "getAllOwnedTokens")] // This works
  public class GetAllOwnedTokensFunctionInput : FunctionMessage
  {
    [Parameter(type: "address", name: "owner", order: 1)]
    public string TokenOwner { get; set; }
    
  }
}
