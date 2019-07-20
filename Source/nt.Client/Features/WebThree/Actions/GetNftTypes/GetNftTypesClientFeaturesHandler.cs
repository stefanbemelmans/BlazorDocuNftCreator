namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using Microsoft.AspNetCore.Components;

  internal partial class WebThreeState
  {

    public class GetNftTypesClientFeaturesHandler : RequestHandler<GetNftTypesClientFeaturesAction, WebThreeState>
    {
      public GetNftTypesClientFeaturesHandler
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
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {

        GetNftTypesSharedResponse SharedResponse = await HttpClient.GetJsonAsync<GetNftTypesSharedResponse>(GetNftTypesSharedRequest.Route);

        return new WebThreeState
        {
          TotalNftTypes = SharedResponse.TotalNftTypes
        };
      }
    }
  }
}

 