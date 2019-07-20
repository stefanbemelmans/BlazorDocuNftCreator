namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftTypes
{
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using MediatR;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;

  public class GetNftTypesServerFeaturesHandler : IRequestHandler<GetNftTypesSharedRequest, GetNftTypesSharedResponse>
  {
    IMediator Mediator { get; set; }

    public GetNftTypesServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetNftTypesSharedResponse> Handle
    (
      GetNftTypesSharedRequest aGetNftTypesSharedRequest,
      CancellationToken aCancellationToken
    )
    {

      GetNftTypesServiceResponse response = await Mediator.Send(new GetNftTypesServiceRequest());


      return new GetNftTypesSharedResponse
      {
        TotalNftTypes = response.TotalNftTypes
      };
    }
  }
}