namespace nt.Server.Features.WebThree
{
  using System.Threading;
  using System.Threading.Tasks;
  using MediatR;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;
  public class ViewMutableDataServerFeaturesHandler : IRequestHandler<ViewMutableDataSharedRequest, ViewMutableDataSharedResponse>
  {
    IMediator Mediator { get; set; }

    public ViewMutableDataServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<ViewMutableDataSharedResponse> Handle
    (
      ViewMutableDataSharedRequest aViewMutableDataSharedRequest,
      CancellationToken aCancellationToken
    )
    {

      ViewMutableDataServiceResponse response = await Mediator.Send(new ViewMutableDataServiceRequest
      {
        ViewTokenId = aViewMutableDataSharedRequest.ViewTokenId
      }
      );

      return new ViewMutableDataSharedResponse(new System.Guid())
      {
        MutableDataString = response.MutableDataString
      };

    }
  }
}
