namespace nt.Client.Features.WebThree.Actions.ViewTokenData
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BlazorState;
    using Microsoft.AspNetCore.Components;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;

    internal partial class WebThreeState : State<WebThreeState>
    {

        public class ViewTokenDataHandler : RequestHandler<FetchTokenDataTypeAction, WebThreeState>
        {
            public ViewTokenDataHandler
              (IStore aStore, HttpClient aHttpClient) : base(aStore)
            {
                HttpClient = aHttpClient;
            }
            private HttpClient HttpClient { get; }

            WebThreeState WebThreeState => Store.GetState<WebThreeState>();

            public override async Task<WebThreeState> Handle
            (
              ViewTokenDataAction aViewTokenDataRequest,
              CancellationToken aCancellationToken
            )
            {
                int TokenId = aFetchTokenTokenDataRequest.TokenIdToGet;

                string requestUri = ViewTokenDataSharedRequest.RouteFactory(TokenId);
                ViewTokenDataSharedResponse QuestionableString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(requestUri);

                WebThreeState.CurrentTokenNftType = type.NftType;

                return WebThreeState;
            }
        }
    }
}

