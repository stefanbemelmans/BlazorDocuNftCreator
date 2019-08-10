namespace nt.Client.Features.WebThree.Actions.GetAllOwnedTokens
{
    using MediatR;
    using nt.Shared.Constants.AccountAddresses;
    using nt.Shared.Features.Base;

    public class GetAllOwnedTokensAction : BaseRequest, IRequest<WebThreeState>
    {
        public const string TokenOwner = TestEthAccounts.TestEthAccountAddress;
    }
}
