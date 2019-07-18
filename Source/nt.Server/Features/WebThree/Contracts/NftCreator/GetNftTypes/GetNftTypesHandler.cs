namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftTypes
{
  using System.Threading;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using MediatR;

  public class GetNftTypesHandler : IRequestHandler<GetNftTypesRequest, GetNftTypesResponse>
  {
    IMediator Mediator { get; set; }
    public async Task<GetNftTypesResponse> Handle
    (
      GetNftTypesRequest aGetNftTypesRequest,
      CancellationToken aCancellationToken
    )
    {
      var response = new GetNftTypesResponse(aGetNftTypesRequest.Id);

      return await Task.Run(() => response);
      
    }
  }
}