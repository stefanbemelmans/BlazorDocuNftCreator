namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using System;
  using Microsoft.AspNetCore.WebUtilities;

  internal partial class WebThreeState
  {

    public class GetNftByTypeClientFeaturesHandler : RequestHandler<GetNftByTypeClientFeaturesAction, WebThreeState>
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
          GetNftByTypeClientFeaturesAction aGetNftByTypeClientRequest,
          CancellationToken aCancellationToken
        )
      {

        int getNftId = aGetNftByTypeClientRequest.GetNftType;

        string requestUri = QueryHelpers.AddQueryString(GetNftByTypeSharedRequest.Route, "GetNftType", getNftId.ToString());

        GetNftByTypeSharedResponse aNftTemplate = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);

        return new WebThreeState
        {
          CurrentNftType = aNftTemplate.NftTypeData
        };
      }
    }
  }
}

 