namespace nt.Server.Features.WebThree.Contracts.Herc1155.BalanceOf
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;
  using nt.Server.Services.WebThree.Contracts.Herc1155.BalanceOf;
  using System.Threading;
  using System.Threading.Tasks;

  public class BalanceOfServerFeaturesHandler : IRequestHandler<BalanceOfSharedRequest, BalanceOfSharedResponse>
  {
    IMediator Mediator { get; set; }

    public BalanceOfServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<BalanceOfSharedResponse> Handle
    (
      BalanceOfSharedRequest aBalanceOfSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      BalanceOfServiceResponse response = await Mediator.Send(new BalanceOfServiceRequest()
      {
          TokenId = aBalanceOfSharedRequest.TokenId
      });

      return new BalanceOfSharedResponse()
      {
        Balance = response.Balance
      };
    }
  }
}