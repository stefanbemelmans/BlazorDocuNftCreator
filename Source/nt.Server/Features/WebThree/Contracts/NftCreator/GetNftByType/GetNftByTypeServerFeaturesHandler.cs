namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetNftByTypeServerFeaturesHandler : IRequestHandler<GetNftByTypeSharedRequest, GetNftByTypeSharedResponse>
  {
    IMediator Mediator { get; set; }

    System.Guid guid { get; set; }
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

      return new GetNftByTypeSharedResponse(new System.Guid())
      {
        NftTypeData = response.NftTypeData
      };
      
    }
  }
}