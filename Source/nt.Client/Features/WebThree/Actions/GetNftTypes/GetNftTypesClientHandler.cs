namespace nt.Client.Features.WebThree
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
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
      private List<NftTemplate> _NftTypeList { get; set; }

      WebThreeState WebThreeState => Store.GetState<WebThreeState>();
      public override async Task<WebThreeState> Handle
        (
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {
        _NftTypeList = new List<NftTemplate>();

        GetNftTypesSharedResponse aSharedResponse = await HttpClient.GetJsonAsync<GetNftTypesSharedResponse>(GetNftTypesSharedRequest.Route);
        int NumOfTemplates = (int)aSharedResponse.TotalNftTypes;

        for (int ctr = 1; ctr < NumOfTemplates; ctr++)
        {
          string requestUri = GetNftByTypeSharedRequest.RouteFactory(ctr);

          NftTemplate templateResponse = await HttpClient.GetJsonAsync<NftTemplate>(requestUri);

          _NftTypeList.Add(templateResponse);
        }
        WebThreeState.NftTypeList = _NftTypeList;

        WebThreeState.TotalNftTypes = aSharedResponse.TotalNftTypes;
        return WebThreeState;

      }
    }
  }
}

