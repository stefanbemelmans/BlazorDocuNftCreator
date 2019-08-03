//namespace nt.Client.Features.WebThree.Actions.BalanceOf
//{
//    using System.Collections.Generic;
//    using System.Net.Http;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using BlazorState;
//    using Microsoft.AspNetCore.Components;
//    using nt.Client.Features.WebThree.Actions;
//    using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;
//    using nt.Shared.Features.WebThree;

//    internal partial class WebThreeState 
//    {

//        public class BalanceOfHandler : RequestHandler<BalanceOfAction, WebThreeState>
//        {
//            public BalanceOfHandler
//              (
//                IStore aStore,
//                HttpClient aHttpClient

//              ) : base(aStore)
//            {
//                HttpClient = aHttpClient;
//            }
//            private HttpClient HttpClient { get; }
//            WebThreeState WebThreeState => Store.GetState<WebThreeState>();

//            // maybe add the balance to the TokenDataList async

//            //List<NftTemplate> TemplateDataList => WebThreeState.TemplateDataList;
//            //List<TemplateBase> TokenDataList { get; set; }
//            public override async Task<WebThreeState> Handle
//              (
//                BalanceOfAction aBalanceOfClientRequest,
//                CancellationToken aCancellationToken
//              )
//            {

//                BalanceOfSharedResponse BalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory(aBalanceOfClientRequest.TokenId));
//                WebThreeState.G
                

//                return WebThreeState;

//            }

//        }
//    }
//}
