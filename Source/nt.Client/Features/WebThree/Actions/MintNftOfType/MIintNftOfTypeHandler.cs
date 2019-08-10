namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base;
  using nt.Client.Features.WebThree.Actions.MintNft;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public class MintNftOfTypeHandler : BaseHandler<MintNftOfTypeAction, WebThreeState>
    {
      private HttpClient HttpClient { get; }

      public MintNftOfTypeHandler
                      (
            IStore aStore,
            HttpClient aHttpClient
          ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }

      public override async Task<WebThreeState> Handle
           (
             MintNftOfTypeAction aMintNftOfClientRequest,
             CancellationToken aCancellationToken
           )
      {
        MintNftOfTypeSharedResponse MintingResponse = await HttpClient.SendJsonAsync<MintNftOfTypeSharedResponse>(HttpMethod.Get, MintNftOfTypeSharedRequest.Route, new MintNftOfTypeAction()
        {
          MintNftId = aMintNftOfClientRequest.MintNftId,
          ImmutableDataString = aMintNftOfClientRequest.ImmutableDataString,
          MutableDataString = aMintNftOfClientRequest.MutableDataString
        });

        WebThreeState.TransactionHash = MintingResponse.TransactionHash;
        WebThreeState.NewTokenId = MintingResponse.TokenId;

        return WebThreeState;
      }
    }
  }
}