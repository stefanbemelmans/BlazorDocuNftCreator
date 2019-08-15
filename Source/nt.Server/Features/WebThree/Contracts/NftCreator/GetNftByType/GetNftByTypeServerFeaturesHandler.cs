namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType;
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;

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
      var aNftRequest = new GetNftByTypeServiceRequest { GetNftId = aGetNftByTypeSharedRequest.GetNftId };

      GetNftByTypeServiceResponse response = await Mediator.Send(aNftRequest);
      var nftDto = new NftTemplate()
      {
        Name = response.Name,
        Symbol = response.Symbol,
        AttachedTokens = response.AttachedTokens,
        MintLimit = response.MintLimit
      
      };
      return new GetNftByTypeSharedResponse(new System.Guid())
      {
        NftTypeDto = nftDto
      };
      
    }
  }
}