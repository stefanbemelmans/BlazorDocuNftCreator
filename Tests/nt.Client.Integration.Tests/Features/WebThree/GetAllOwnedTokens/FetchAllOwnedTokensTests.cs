namespace nt.Client.Integration.Tests.Features.WebThree.FetchAllOwnedTokens
{
  using BlazorState;
  using global::AnySerializer;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Integration.Tests.Infrastructure;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;
  using Shouldly;
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;
  using static nt.Client.Features.WebThree.Components.NftTemplates.ImmutableDataObjectBase;

  internal class FetchAllOwnedTokensTests
  {
    private readonly SerializerOptions options = 0;

    //public WebThreeState WebThreeState { get; set; }
    //public List<NftTemplate> TemplateDataList { get; set; }
    public List<TokenBase> TokenDataList { get; } = new List<TokenBase>();

    private HttpClient HttpClient { get; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }

    public FetchAllOwnedTokensTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      IStore store = ServiceProvider.GetService<IStore>();
      //WebThreeState = store.GetState<WebThreeState>();
      Mediator = ServiceProvider.GetService<IMediator>();
      HttpClient = ServiceProvider.GetService<HttpClient>();
    }

    //List<NftTemplate> TemplateDataList => WebThreeState.TemplateDataList;

    public async Task ShouldBuildTokenListInPieces()
    {
      var SeparateTokenDataList = new List<TokenBase>();

      WebThreeState WebThree = await Mediator.Send(new GetNftTypesClientFeaturesAction());

      GetAllOwnedTokensSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllOwnedTokensSharedResponse>(GetAllOwnedTokensSharedRequest.Route);
      aTokenList.TokenIdList.Count.ShouldBeGreaterThan(3);
      aTokenList.TokenIdList.Contains(3).ShouldBe(true);
      aTokenList.TokenIdList.Contains(4).ShouldBe(true);
      aTokenList.TokenIdList.Contains(5).ShouldBe(true);
      aTokenList.TokenIdList.Contains(6).ShouldBe(true);
      foreach (uint token in aTokenList.TokenIdList)
      {
        // Start the list with TokenId
        var ownedToken = new TokenBase() { TokenId = token };
        //SeparateTokenDataList.Add(ownedToken);

        string getNftTypeUri = GetTokenNftTypeSharedRequest.RouteFactory((int)token);

        GetTokenNftTypeSharedResponse aNftTypeSharedResponse = await HttpClient.GetJsonAsync<GetTokenNftTypeSharedResponse>(getNftTypeUri);

        // TokenNftTypeData Should already have the data in state so no need to make a service call
        NftTemplate nftType = WebThree.TemplateDataList.Find(nft => nft.NftId == aNftTypeSharedResponse.NftType);

        ownedToken.TemplateData = nftType;

        // Token Balance

        BalanceOfSharedResponse aBalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory((int)token));

        ownedToken.Balance = aBalanceContainer.Balance;

        // Token ImmutableData (Data)

        ownedToken.TemplateData.ShouldBeOfType<NftTemplate>();

        ViewTokenDataSharedResponse dataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)token));

        dataString.TokenDataString.ShouldNotBe(null);
        if (token == 3)
        {
          byte[] serializedImmutableData = Convert.FromBase64String(dataString.TokenDataString);
          // need to figure out a way to get the type occording to the nftId
          ImmutableData deserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options); // options == 0

          ownedToken.ImmDataObj = deserializedObject;

          // Add to StateList
          SeparateTokenDataList.Add(ownedToken);
        }
        if (token == 6)
        {
          byte[] serializedImmutableData = Convert.FromBase64String(dataString.TokenDataString);
          // need to figure out a way to get the type occording to the nftId
          PurchaseOrderData deserializedObject = Serializer.Deserialize<PurchaseOrderData>(serializedImmutableData, options); // options == 0

          ownedToken.PurchaseOrderData = deserializedObject;

          // Add to StateList
          SeparateTokenDataList.Add(ownedToken);
        }
        else
        {
          ownedToken.Data = dataString.TokenDataString;

          SeparateTokenDataList.Add(ownedToken);
        }
      }

      SeparateTokenDataList.Count.ShouldBeGreaterThan(3);
    }

    public async Task ShouldReturnWebThreeState()
    {
      WebThreeState webThreeState = await Mediator.Send(new GetAllOwnedTokensAction());
      webThreeState.ShouldNotBe(null);
    }
  }
}