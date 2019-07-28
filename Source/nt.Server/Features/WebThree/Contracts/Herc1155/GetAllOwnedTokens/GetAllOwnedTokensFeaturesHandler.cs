namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetAllOwnedTokens
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;
  using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Constants.AccountAddresses;

  public class GetAllOwnedTokensServerFeaturesHandler : IRequestHandler<GetAllOwnedTokensSharedRequest, GetAllOwnedTokensSharedResponse>
  {
    IMediator Mediator { get; set; }

    public GetAllOwnedTokensServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetAllOwnedTokensSharedResponse> Handle
    (
      GetAllOwnedTokensSharedRequest aGetAllOwnedTokensSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aNftRequest = new GetAllOwnedTokensServiceRequest { TokenOwner = TestEthAccounts.TestEthAccountAddress};

      GetAllOwnedTokensServiceResponse response = await Mediator.Send(aNftRequest);

      return new GetAllOwnedTokensSharedResponse
      {
        TokenIdList = response.TokenIdList
      };
    }
  }
}