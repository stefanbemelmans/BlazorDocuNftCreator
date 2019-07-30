namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;

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

        GetNftTypesSharedResponse aSharedResponse = await HttpClient.GetJsonAsync<GetNftTypesSharedResponse>(GetNftTypesSharedRequest.Route);

        return new WebThreeState()
        {
          TotalNftTypes = aSharedResponse.TotalNftTypes
        };
      }
    }
  }
}

 