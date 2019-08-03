//namespace nt.Client.Features.WebThree.Actions.ViewTokenData
//{
//    using System.Net.Http;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using BlazorState;
//    using Microsoft.AspNetCore.Components;
//    using nt.Shared.Features.WebThree.Contracts.Herc1155;

//    internal partial class WebThreeState
//    {
//        public class ViewTokenDataHandler : RequestHandler<ViewTokenDataAction, WebThreeState>
//        {
//            public ViewTokenDataHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
//            {
//                HttpClient = aHttpClient;
//            }

//            private HttpClient HttpClient { get; }
//            WebThreeState WebThreeState => Store.GetState<WebThreeState>();

//            public override async Task<WebThreeState> Handle
//                (
//                ViewTokenDataAction aViewTokenDataRequest,
//                CancellationToken aCancellationToken
//                )
//            {
//                uint TokenId = aViewTokenDataRequest.TokenIdToGet;
//                string requestUri = ViewTokenDataSharedRequest.RouteFactory(TokenId);

//                ViewTokenDataSharedResponse DataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(requestUri);

//            }
//        }
//    }
//}
