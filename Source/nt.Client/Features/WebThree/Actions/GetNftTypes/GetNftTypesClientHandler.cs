namespace nt.Client.Features.WebThree
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BlazorState;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base;
    using nt.Client.Features.WebThree.Actions;
    using nt.Shared.Features.WebThree;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;

    internal partial class WebThreeState : State<WebThreeState>
    {

        public class GetNftTypesClientFeaturesHandler : BaseHandler<GetNftTypesClientFeaturesAction, WebThreeState>
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
            //private List<KeyValuePair<uint, NftTemplate>> _TemplateList { get; set; }
            private List<NftTemplate> _TemplateList { get; set; }
            public override async Task<WebThreeState> Handle
              (
                GetNftTypesClientFeaturesAction aGetNftTypesClientRequest,
                CancellationToken aCancellationToken
              )
            {
                _TemplateList = new List<NftTemplate>();

                GetNftTypesSharedResponse aSharedResponse = await HttpClient.GetJsonAsync<GetNftTypesSharedResponse>(GetNftTypesSharedRequest.Route);
                int NumOfTemplates = (int)aSharedResponse.TotalNftTypes;

                for (uint ctr = 1; ctr <= NumOfTemplates; ctr++)
                {
                    string requestUri = GetNftByTypeSharedRequest.RouteFactory((int)ctr);
                    GetNftByTypeSharedResponse templateResponse = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);

                    var template = new NftTemplate()
                    {
                        NftId = ctr,
                        Name = templateResponse.NftTypeDto.Name,
                        Symbol = templateResponse.NftTypeDto.Symbol,
                        MintLimit = templateResponse.NftTypeDto.MintLimit,
                        AttachedTokens = templateResponse.NftTypeDto.AttachedTokens
                    };


                    _TemplateList.Add(template);
                }

                WebThreeState.TemplateDataList = _TemplateList;

                WebThreeState.TotalNftTypes = aSharedResponse.TotalNftTypes;

                return WebThreeState;
            }
        }
    }
}

