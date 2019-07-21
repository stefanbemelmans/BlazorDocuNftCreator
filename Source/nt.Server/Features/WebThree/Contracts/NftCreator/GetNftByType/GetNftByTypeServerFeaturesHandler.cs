namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using MediatR;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType;

  public class GetNftByTypeServerFeaturesHandler : IRequestHandler<GetNftByTypeSharedRequest, GetNftByTypeSharedResponse>
  {
    IMediator Mediator { get; set; }

    public GetNftByTypeServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetNftByTypeSharedResponse> Handle
    (
      GetNftByTypeSharedRequest aGetNftByTypeSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aNftRequest = new GetNftByTypeServiceRequest { GetNftId = aGetNftByTypeSharedRequest.GetNftType };

      GetNftByTypeServiceResponse response = await Mediator.Send(aNftRequest);

      return new GetNftByTypeSharedResponse
      {
        NftTypeData = response.NftTypeData
      };
    }
  }
}