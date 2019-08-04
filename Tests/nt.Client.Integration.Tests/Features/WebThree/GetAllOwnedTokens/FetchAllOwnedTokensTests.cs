namespace nt.Client.Integration.Tests.Features.WebThree.FetchAllOwnedTokens
{
    using System;
    using Shouldly;
    using nt.Client.Features.WebThree;
    using nt.Client.Integration.Tests.Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using System.Threading.Tasks;
    using System.Net.Http;
    using nt.Shared.Constants.AccountAddresses;
    using Microsoft.AspNetCore.Components;
    using BlazorState;
    using nt.Client.Features.WebThree.Actions;
    using nt.Shared.Features.WebThree;
    using System.Collections.Generic;
    using global::AnySerializer;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;
    using nt.Shared.Features.WebThree.Contracts.Herc1155;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;
    using static nt.Client.Features.WebThree.Components.NftTemplates.ImmutableDataObjectBase;

    internal class FetchAllOwnedTokensTests
    {
        private IMediator Mediator { get; }
        private IServiceProvider ServiceProvider { get; }
        private HttpClient HttpClient { get; }

        //public WebThreeState WebThreeState { get; set; }
        //public List<NftTemplate> TemplateDataList { get; set; } 
        public List<TokenBase> TokenDataList { get; } = new List<TokenBase>();
        public FetchAllOwnedTokensTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;
            IStore store = ServiceProvider.GetService<IStore>();
            //WebThreeState = store.GetState<WebThreeState>();
            Mediator = ServiceProvider.GetService<IMediator>();
            HttpClient = ServiceProvider.GetService<HttpClient>();
        }
        readonly SerializerOptions options = 0;
        //List<NftTemplate> TemplateDataList => WebThreeState.TemplateDataList;

        public async Task ShouldBuildTokenList()
        {

            var WebThree = await Mediator.Send(new GetNftTypesClientFeaturesAction());

            GetAllOwnedTokensSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllOwnedTokensSharedResponse>(GetAllOwnedTokensSharedRequest.Route);
            foreach (uint token in aTokenList.TokenIdList)
            {
                // TokenId
                TokenBase ownedToken = new TokenBase() { TokenId = token };

                // TokenNFtTypeId
                string getNftTypeUri = GetTokenNftTypeSharedRequest.RouteFactory((int)token);

                var NftTypeContainer = await Mediator.Send(new FetchTokenNftTypeAction() { TokenId = (int)ownedToken.TokenId });

                // TokenNftTypeData Should already have the data in state so no need to make a service call
                var nftType = WebThree.TemplateDataList.Find(nft => nft.NftId == NftTypeContainer.CurrentTokenNftType);

                ownedToken.TemplateData = nftType;

                // Token Balance

                var BalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory((int)token));

                ownedToken.Balance = BalanceContainer.Balance;

                // Token ImmutableData (Data)

                ownedToken.TemplateData.ShouldBeOfType<NftTemplate>();
                
                ViewTokenDataSharedResponse DataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)token));

                DataString.TokenDataString.ShouldNotBe(null);
                if (token == 3)
                {
                    byte[] serializedImmutableData = Convert.FromBase64String(DataString.TokenDataString);
                    // need to figure out a way to get the type occording to the nftId
                    ImmutableData DeserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options); // options == 0

                    ownedToken.ImmDataObj= DeserializedObject;

                    // Add to StateList 
                    TokenDataList.Add(ownedToken);
                }
                else
                {
                    ownedToken.Data = DataString.TokenDataString;

                    TokenDataList.Add(ownedToken);
                }
            }

            TokenDataList.Count.ShouldBe(3);
        }

    }
}
