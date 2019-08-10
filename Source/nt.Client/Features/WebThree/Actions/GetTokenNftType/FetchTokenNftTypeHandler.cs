namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;
  internal partial class WebThreeState
  {

    public class FetchTokenNftTypeClientFeaturesHandler : BaseHandler<FetchTokenNftTypeAction, WebThreeState>
    {
      public FetchTokenNftTypeClientFeaturesHandler
        (IStore aStore,
          HttpClient aHttpClient
        ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }

      public override async Task<WebThreeState> Handle
      (
        FetchTokenNftTypeAction aFetchTokenNftTypeClientRequest,
        CancellationToken aCancellationToken
      )
      {
        int TokenId = aFetchTokenNftTypeClientRequest.TokenId;

        string requestUri = GetTokenNftTypeSharedRequest.RouteFactory(TokenId);

        GetTokenNftTypeSharedResponse type = await HttpClient.GetJsonAsync<GetTokenNftTypeSharedResponse>(requestUri);

        WebThreeState.CurrentTokenNftType = type.NftType;

        return WebThreeState;
      }
    }
  }
}

