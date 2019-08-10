namespace nt.Server.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType;
  using System.Threading;
  using System.Threading.Tasks;

  public class MintNftOfTypeServerFeaturesHandler : IRequestHandler<MintNftOfTypeSharedRequest, MintNftOfTypeSharedResponse>
  {
    IMediator Mediator { get; set; }

    public MintNftOfTypeServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<MintNftOfTypeSharedResponse> Handle
    (
      MintNftOfTypeSharedRequest aMintNftOfTypeSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aMintNftRequest = new MintNftOfTypeServiceRequest {
        MintNftId = aMintNftOfTypeSharedRequest.MintNftId,
        ImmutableDataString = aMintNftOfTypeSharedRequest.ImmutableDataString,
        MutableDataString = aMintNftOfTypeSharedRequest.MutableDataString

      };

      MintNftOfTypeServiceResponse response = await Mediator.Send(aMintNftRequest);

      return new MintNftOfTypeSharedResponse
      {
        TransactionHash = response.TransactionHash,
        TokenId = response.TokenId
      };
    }
  }
}