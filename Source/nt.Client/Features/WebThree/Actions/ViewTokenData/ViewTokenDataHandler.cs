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
                // What comes back from the server call will be either a string or a base64 string,
                // Once things progress further in development the pattern will be
                // Server response is a base64 string that will deserialized using 
                // "Any Serializer" into respective object based on NftId,
                // TokenId 5 is just a string
                // TokenId 4 is just a string
                // TokenId 3 deserializes from base64 into ImmutableData type
                string requestUri = ViewTokenDataSharedRequest.RouteFactory(TokenId);
                ViewTokenDataSharedResponse QuestionableString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(requestUri);

                WebThreeState.CurrentTokenNftType = type.NftType;

                return WebThreeState;
            }
        }
    }
}

