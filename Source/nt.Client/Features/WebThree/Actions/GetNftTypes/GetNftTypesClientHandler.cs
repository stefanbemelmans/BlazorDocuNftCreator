namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;

  internal partial class WebThreeState : State<WebThreeState>
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

      WebThreeState WebThreeState => Store.GetState<WebThreeState>();
      public override async Task<WebThreeState> Handle
        (
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {

        GetNftTypesSharedResponse aSharedResponse = await HttpClient.GetJsonAsync<GetNftTypesSharedResponse>(GetNftTypesSharedRequest.Route);

        WebThreeState.TotalNftTypes = aSharedResponse.TotalNftTypes;
        return WebThreeState;

      }
    }
  }
}

