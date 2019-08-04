namespace nt.Client.Features.WebThree
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BlazorState;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base;
    using nt.Client.Features.WebThree.Actions.ViewTokenData;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;

    internal partial class WebThreeState
    {
        public class ViewTokenDataHandler : BaseHandler<ViewTokenDataAction, WebThreeState>
        {
            public ViewTokenDataHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
            {
                HttpClient = aHttpClient;
            }

            private HttpClient HttpClient { get; }

            public TokenBase CurrentTokenData { get; set; }

            public override async Task<WebThreeState> Handle
                (
                ViewTokenDataAction aViewTokenDataRequest,
                CancellationToken aCancellationToken
                )
            {
                uint TokenId = aViewTokenDataRequest.TokenIdToGet;
                CurrentTokenData.TokenId = TokenId;

                ViewTokenDataSharedResponse DataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)TokenId));
                CurrentTokenData.Data = DataString.TokenDataString;
                WebThreeState.CurrentTokenData = CurrentTokenData;

                return WebThreeState;
            }
        }
    }
}
