namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftTypes
{
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using MediatR;

  public class GetNftTypesHandler : IRequestHandler<GetNftTypesRequest, GetNftTypesResponse>
  {
    IMediator Mediator { get; }
    public GetNftTypesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetNftTypesResponse> Handle
    (
      GetNftTypesRequest aGetNftTypesRequest,
      CancellationToken aCancellationToken
    )
    {
      GetNftTypesResponse response = await Mediator.Send(aGetNftTypesRequest);

      return response;
      
    }
  }
}