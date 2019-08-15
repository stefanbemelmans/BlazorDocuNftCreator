namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base;
  using nt.Client.Features.WebThree.Actions;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public class GetNftTypesClientFeaturesHandler : BaseHandler<GetNftTypesClientFeaturesAction, WebThreeState>
    {
      //private List<KeyValuePair<uint, NftTemplate>> _TemplateList { get; set; }
      private List<NftTemplate> _TemplateList { get; set; }

      private HttpClient HttpClient { get; }

      public GetNftTypesClientFeaturesHandler
                          (
                IStore aStore,
                HttpClient aHttpClient
              ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }

      public override async Task<WebThreeState> Handle
        (
          GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
          CancellationToken aCancellationToken
        )
      {
        _TemplateList = new List<NftTemplate>();

        GetNftCountSharedResponse aSharedResponse = await HttpClient.GetJsonAsync<GetNftCountSharedResponse>(GetNftCountSharedRequest.Route);
        int nftCount = (int)aSharedResponse.NftCount;

        for (int ctr = 1; ctr <= nftCount; ctr++)
        {
          string requestUri = GetNftByTypeSharedRequest.RouteFactory(ctr);
          GetNftByTypeSharedResponse templateResponse = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);

          var template = new NftTemplate()
          {
            NftId = (uint)ctr,
            Name = templateResponse.NftTypeDto.Name,
            Symbol = templateResponse.NftTypeDto.Symbol,
            MintLimit = templateResponse.NftTypeDto.MintLimit,
            AttachedTokens = templateResponse.NftTypeDto.AttachedTokens
          };

          _TemplateList[ctr] = (template);
        }

        WebThreeState.TemplateDataList = _TemplateList;

        WebThreeState.TotalNftTypes = aSharedResponse.NftCount;
        return WebThreeState;
      }
    }
  }
}