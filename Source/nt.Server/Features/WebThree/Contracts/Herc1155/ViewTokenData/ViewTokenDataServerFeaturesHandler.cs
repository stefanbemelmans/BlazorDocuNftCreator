namespace nt.Server.Features.WebThree.Contracts.Herc1155.ViewTokenData
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
    using nt.Shared.Features.WebThree.Contracts.Herc1155;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;

    public class ViewTokenDataServerFeaturesHandler : IRequestHandler<ViewTokenDataSharedRequest, ViewTokenDataSharedResponse>
    {
        IMediator Mediator { get; set; }

        public ViewTokenDataServerFeaturesHandler(IMediator aMediator)
        {
            Mediator = aMediator;
        }

        public async Task<ViewTokenDataSharedResponse> Handle
        (
          ViewTokenDataSharedRequest aViewTokenDataSharedRequest,
          CancellationToken aCancellationToken
        )
        {

            ViewTokenDataServiceResponse response = await Mediator.Send(new ViewTokenDataServiceRequest
            {
                ViewTokenId = aViewTokenDataSharedRequest.TokenIdToGet
            }
            );

            return new ViewTokenDataSharedResponse(new System.Guid())
            {
                TokenDataString = response.TokenDataString,
               
            };

        }
    }
}
