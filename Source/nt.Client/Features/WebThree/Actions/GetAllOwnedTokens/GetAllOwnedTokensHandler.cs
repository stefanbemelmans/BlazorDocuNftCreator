namespace nt.Client.Features.WebThree
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BlazorState;
    using Microsoft.AspNetCore.Components;
    using Nethereum.Contracts;
    using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;


    internal partial class WebThreeState
    {

        public class GetAllOwnedTokensHandler : RequestHandler<GetAllOwnedTokensAction, WebThreeState>
        {
            public GetAllOwnedTokensHandler
              (
                IStore aStore,
                HttpClient aHttpClient
              ) : base(aStore)
            {
                HttpClient = aHttpClient;
            }
            private HttpClient HttpClient { get; }
            private
            WebThreeState WebThreeState => Store.GetState<WebThreeState>();
            List<TemplateBase> TokenDataList { get; set; }
            public override async Task<WebThreeState> Handle
              (
                GetAllOwnedTokensAction aGetAllOwnedTokensClientRequest,
                CancellationToken aCancellationToken
              )
            {

                GetAllOwnedTokensSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllOwnedTokensSharedResponse>(GetAllOwnedTokensSharedRequest.Route);
                foreach(uint token in aTokenList.TokenIdList)
                {
                    
                }

                WebThreeState.OwnedTokenIdList = aTokenList.TokenIdList;

                return WebThreeState;

            }

            //public uint GetTokenType(uint TokenId)
            //{
            //  Function tokenTypeFunction = NFtCreator.Instance.GetFunction("tokenType");
            //}

            //public async Task GetTokenData(List<uint> tokenList) 
            //{
            //  foreach(uint token in tokenList)
            //  {

            //  }


            //}


        }
    }
}
