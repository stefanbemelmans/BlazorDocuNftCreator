namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using System.Text.Json.Serialization;


  internal partial class WebThreeState
  {

  public class GetNftTypesClientFeaturesHandler : RequestHandler<GetNftTypesClientFeaturesAction, WebThreeState>
  {
      private readonly JsonSerializerOptions JsonSerializerOptions;
      public GetNftTypesClientFeaturesHandler
        (
          IStore aStore,
          HttpClient aHttpClient,
          JsonSerializerOptions aJsonSerializerOptions
        ) : base(aStore)
      {
        HttpClient = aHttpClient;
        JsonSerializerOptions = aJsonSerializerOptions;
      }

      private HttpClient HttpClient { get; }

      private WebThreeState WebThreeState => Store.GetState<WebThreeState>();

      public override async Task<WebThreeState> Handle
        (
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {
        var aGetNftTypesSharedRequest = new GetNftTypesSharedRequest();

        using HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(GetNftTypesSharedRequest.Route);

        string content = await httpResponseMessage.Content.ReadAsStringAsync();

        GetNftTypesSharedResponse getNftTypesSharedResponse =
          JsonSerializer.Parse<GetNftTypesSharedResponse>(content, JsonSerializerOptions);

        WebThreeState.TotalNftTypes = getNftTypesSharedResponse.TotalNfts;

        return WebThreeState;
      }


  }

  }
}
