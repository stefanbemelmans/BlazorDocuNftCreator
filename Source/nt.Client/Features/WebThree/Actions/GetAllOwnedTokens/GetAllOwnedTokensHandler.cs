namespace nt.Client.Features.WebThree
{
    using AnySerializer;
    using BlazorState;
    using MediatR;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base;
    using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
    using nt.Client.Features.WebThree.Components.NftTemplates;
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
            public GetAllOwnedTokensHandler
              (
                IStore aStore,
                HttpClient aHttpClient

              ) : base(aStore)
            {
                HttpClient = aHttpClient;
            }
            private HttpClient HttpClient { get; }
            //List<NftTemplate> TemplateDataList => WebThreeState.TemplateDataList;

            //WebThreeState webthreestate => Store.GetState<WebThreeState>();
            List<TokenBase> TokenDataList { get; set; }
            IMediator Mediator { get; set; }

            readonly SerializerOptions options = 0;
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
                    //string getNftTypeUri = GetTokenNftTypeSharedRequest.RouteFactory((int)token);

                    var NftTypeSharedResponse = await HttpClient.GetJsonAsync<GetTokenNftTypeSharedResponse>(GetTokenNftTypeSharedRequest.RouteFactory((int)token));

                    // TokenNftTypeData Should already have the data in state so no need to make a service call
                    var nftType = WebThreeState.TemplateDataList.Find(nft => nft.NftId == NftTypeSharedResponse.NftType);

                    ownedToken.TemplateData = nftType;

                    // Token Balance

                    var BalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory((int)token));

                    ownedToken.Balance = BalanceContainer.Balance;

                    // Token ImmutableData (Data)

                    string viewDataUri = ViewTokenDataSharedRequest.RouteFactory((int)token);

                    ViewTokenDataSharedResponse DataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)token));

                    if (token == 3)
                    {
                        byte[] serializedImmutableData = Convert.FromBase64String(DataString.TokenDataString);
                        // need to figure out a way to get the type occording to the nftId
                        ImmutableData DeserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options); // options == 0

                        ownedToken.ImmDataObj = DeserializedObject;

                        // Add to StateList 
                        TokenDataList.Add(ownedToken);
                    }
                    else
                    {
                        ownedToken.Data = DataString.TokenDataString;

                        TokenDataList.Add(ownedToken);
                    }
                }

                WebThreeState.TokenDataList = TokenDataList;
                WebThreeState.OwnedTokenIdList = aTokenList.TokenIdList;
                //WebThreeState.CurrentTokenData = TokenDataList[0];
                //WebThreeState.CurrentTokenId = TokenDataList[0].TokenId;
                //WebThreeState.CurrentTokenNftType = TokenDataList[0].TemplateData.NftId;
                return WebThreeState;

            }
        }
    }

    // a testing class
    //class ImmutableData 
    //{
    //    public string Title = "The First Minted NFT!Take 2";
    //    public DateTime Date = DateTime.Now;
    //    public string MintedFrom = "Server.Services";
    //}
}
