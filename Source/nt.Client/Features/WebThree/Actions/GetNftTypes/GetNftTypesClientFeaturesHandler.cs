namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using System.Text.Json.Serialization;
  using MediatR;


  internal partial class WebThreeState
  {

  public class GetNftTypesClientFeaturesHandler : BlazorState.RequestHandler<GetNftTypesClientFeaturesAction, WebThreeState>
  {
      //private readonly JsonSerializerOptions JsonSerializerOptions;
      public GetNftTypesClientFeaturesHandler
        (
          IStore aStore,
          IMediator aMediator
          //HttpClient aHttpClient,
          //JsonSerializerOptions aJsonSerializerOptions
        ) : base(aStore)
      {
        Mediator = aMediator;
        //HttpClient = aHttpClient;
        //JsonSerializerOptions = aJsonSerializerOptions;
      }
      public IMediator Mediator { get; }
      //private HttpClient HttpClient { get; }

      private WebThreeState WebThreeState => Store.GetState<WebThreeState>();

      public override async Task<WebThreeState> Handle
        (
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {


        GetNftTypesSharedResponse SharedResponse = await Mediator.Send(new GetNftTypesSharedRequest());

        WebThreeState.TotalNftTypes = SharedResponse.TotalNftTypes;

        return WebThreeState;
      }
        //using HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(GetNftTypesSharedRequest.Route);

        //string content = await httpResponseMessage.Content.ReadAsStringAsync();

        //GetNftTypesSharedResponse getNftTypesSharedResponse =
        //  JsonSerializer.Parse<GetNftTypesSharedResponse>(content, JsonSerializerOptions);



  }

  }
}
