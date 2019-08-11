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
    public class MintNftOfTypeHandler : BaseHandler<MintNftOfTypeClientAction, WebThreeState>
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
             MintNftOfTypeClientAction aMintNftClientRequest,
             CancellationToken aCancellationToken
           )
      {
        var mintingRequest = new MintNftOfTypeSharedRequest()
        {
          MintNftId = (int)aMintNftClientRequest.MintNftId,
          ImmutableDataString = aMintNftClientRequest.ImmutableDataString,
          MutableDataString = aMintNftClientRequest.MutableDataString
        };

        //string uri = MintNftOfTypeSharedRequest.RouteFactory((int)aMintNftClientRequest.MintNftId, aMintNftClientRequest.MutableDataString, aMintNftClientRequest.ImmutableDataString);
        MintNftOfTypeSharedResponse mintingResponse = await HttpClient.SendJsonAsync<MintNftOfTypeSharedResponse>(HttpMethod.Post, MintNftOfTypeSharedRequest.Route, mintingRequest);

        WebThreeState.TransactionHash = mintingResponse.TransactionHash;
        WebThreeState.NewTokenId = mintingResponse.TokenId;

        return WebThreeState;
      }
    }
  }
}