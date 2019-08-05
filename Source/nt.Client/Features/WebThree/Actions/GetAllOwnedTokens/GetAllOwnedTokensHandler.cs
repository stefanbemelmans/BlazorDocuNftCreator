namespace nt.Client.Features.WebThree
{
    using AnySerializer;
    using BlazorState;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base;
    using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using static nt.Client.Features.WebThree.Components.NftTemplates.ImmutableDataObjectBase;

    internal partial class WebThreeState : State<WebThreeState>
    {
        public class GetAllOwnedTokensHandler : BaseHandler<GetAllOwnedTokensAction, WebThreeState>
        {
            private readonly SerializerOptions options = 0;

            private HttpClient HttpClient { get; }

            private List<TokenBase> TokenDataList { get; set; }

            public GetAllOwnedTokensHandler
              (
                IStore aStore,
                HttpClient aHttpClient

              ) : base(aStore)
            {
                HttpClient = aHttpClient;
            }

            public override async Task<WebThreeState> Handle
              (
                GetAllOwnedTokensAction aGetAllOwnedTokensClientRequest,
                CancellationToken aCancellationToken
              )
            {
                TokenDataList = new List<TokenBase>();

                GetAllOwnedTokensSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllOwnedTokensSharedResponse>(GetAllOwnedTokensSharedRequest.Route);
                foreach (uint token in aTokenList.TokenIdList)
                {
                    // TokenId

                    TokenBase ownedToken = new TokenBase() { TokenId = token };

                    //TokenNFtTypeId

                    ownedToken.TemplateData = await GetNft(token);

                    // Token Balance

                    ownedToken.Balance = await GetBalance(token);

                    // Token ImmutableData (Data)

                    var DataString = await GetDataString(token);

                    DeserializeAndAddData(token, ownedToken, DataString);
                }

                WebThreeState.TokenDataList = TokenDataList;
                WebThreeState.OwnedTokenIdList = aTokenList.TokenIdList;
                WebThreeState.CurrentTokenData = TokenDataList[0];
                WebThreeState.CurrentTokenId = TokenDataList[0].TokenId;
                WebThreeState.CurrentTokenNftType = TokenDataList[0].TemplateData.NftId;
                return WebThreeState;
            }

            private void DeserializeAndAddData(uint token, TokenBase ownedToken, string DataString)
            {
                if (token == 3)
                {
                    byte[] serializedImmutableData = Convert.FromBase64String(DataString);

                    ImmutableData DeserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options); // options == 0

                    ownedToken.ImmDataObj = DeserializedObject;

                    // Add to StateList
                    TokenDataList.Add(ownedToken);
                }
                else
                {
                    ownedToken.Data = DataString;

                    TokenDataList.Add(ownedToken);
                }
            }

            private async Task<int> GetBalance(uint token)
            {
                BalanceOfSharedResponse BalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory((int)token));
                return BalanceContainer.Balance;
            }

            private async Task<string> GetDataString(uint token)
            {
                ViewTokenDataSharedResponse DataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)token));
                string dataString = DataString.TokenDataString;
                return dataString;
            }

            private async Task<NftTemplate> GetNft(uint token)
            {   // TokenNftTypeData Should already have the data in state so no need to make a service call
                var NftContainer = await HttpClient.GetJsonAsync<GetTokenNftTypeSharedResponse>(GetTokenNftTypeSharedRequest.RouteFactory((int)token));
                var Template = WebThreeState.TemplateDataList.Find(nft => nft.NftId == NftContainer.NftType);
                return Template;
            }
        }
    }
}