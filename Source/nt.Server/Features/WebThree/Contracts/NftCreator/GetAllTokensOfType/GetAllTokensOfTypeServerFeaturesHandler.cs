namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetAllTokensOfTypeServerFeaturesHandler : IRequestHandler<GetAllTokensOfTypeSharedRequest, GetAllTokensOfTypeSharedResponse>
  {
    IMediator Mediator { get; set; }

    public GetAllTokensOfTypeServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetAllTokensOfTypeSharedResponse> Handle
    (
      GetAllTokensOfTypeSharedRequest aGetAllTokensOfTypeSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aNftRequest = new GetAllTokensOfTypeServiceRequest { GetAllTokensOfType = aGetAllTokensOfTypeSharedRequest.GetAllTokensOfType };

      GetAllTokensOfTypeServiceResponse response = await Mediator.Send(aNftRequest);

      return new GetAllTokensOfTypeSharedResponse
      {
        TokenList = response.TokenList
      };
    }
  }
}