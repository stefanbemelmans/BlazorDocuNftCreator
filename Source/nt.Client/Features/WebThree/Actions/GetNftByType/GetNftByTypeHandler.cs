namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  internal partial class WebThreeState
  {

    public class GetNftByTypeClientFeaturesHandler : RequestHandler<GetNftByTypeAction, WebThreeState>
    {
      public GetNftByTypeClientFeaturesHandler
        (
          IStore aStore,
          HttpClient aHttpClient
        ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }


      public override async Task<WebThreeState> Handle
        (
          GetNftByTypeAction aGetNftByTypeClientRequest,
          CancellationToken aCancellationToken
        )
      {

        uint getNftId = aGetNftByTypeClientRequest.GetNftType;

        //string requestUri = QueryHelpers.AddQueryString(GetNftByTypeSharedRequest.Route, "GetNftType", getNftId.ToString());
        string requestUri = GetNftByTypeSharedRequest.RouteFactory(getNftId);
        GetNftByTypeSharedResponse aNftTemplate = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);

        return new WebThreeState
        {
          CurrentNftTemplate = aNftTemplate.NftTypeData
        };
      }
    }
  }
}

 