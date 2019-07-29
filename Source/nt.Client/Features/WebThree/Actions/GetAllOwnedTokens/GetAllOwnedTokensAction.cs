namespace nt.Client.Features.WebThree.Actions.GetAllOwnedTokens
{
  using MediatR;
  using nt.Shared.Constants.AccountAddresses;

  public class GetAllOwnedTokensAction : IRequest<WebThreeState>
  {
    public const string TokenOwner = TestEthAccounts.TestEthAccountAddress;
  }
}
