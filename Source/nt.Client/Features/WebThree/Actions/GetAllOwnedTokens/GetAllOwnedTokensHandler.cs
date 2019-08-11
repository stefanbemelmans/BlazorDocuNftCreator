namespace nt.Client.Features.WebThree
{
  using AnySerializer;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
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

          var ownedToken = new TokenBase() { TokenId = token };

          //TokenNFtTypeId

          ownedToken.TemplateData = await GetNft(token);

          // Token Balance

          ownedToken.Balance = await GetBalance(token);

          // Token ImmutableData (Data)

          string aDataString = await GetDataString(token);

          DeserializeAndAddData(token, ownedToken, aDataString);
        }

        WebThreeState.TokenDataList = TokenDataList;
        WebThreeState.OwnedTokenIdList = aTokenList.TokenIdList;
        WebThreeState.CurrentTokenData = TokenDataList[0];
        WebThreeState.CurrentTokenId = TokenDataList[0].TokenId;
        WebThreeState.CurrentTokenNftType = WebThreeState.CurrentTokenData.TemplateData.NftId;
        return WebThreeState;
      }

      private void DeserializeAndAddData(uint aToken, TokenBase aOwnedToken, string aDataString)
      {
        if (aToken == 3)
        {
          byte[] serializedImmutableData = Convert.FromBase64String(aDataString);

          ImmutableData aDeserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options); // options == 0

          aOwnedToken.ImmDataObj = aDeserializedObject;

          // Add to StateList
          TokenDataList.Add(aOwnedToken);
        }
        if (aToken == 6)
        {
          byte[] serializedImmutableData = Convert.FromBase64String(aDataString);

          PurchaseOrderData aDeserializedObject = Serializer.Deserialize<PurchaseOrderData>(serializedImmutableData, options); // options == 0

          aOwnedToken.PurchaseOrderData = aDeserializedObject;

          // Add to StateList
          TokenDataList.Add(aOwnedToken);
        }
        else
        {
          aOwnedToken.Data = aDataString;

          TokenDataList.Add(aOwnedToken);
        }
      }

      private async Task<int> GetBalance(uint aToken)
      {
        BalanceOfSharedResponse aBalanceContainer = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(BalanceOfSharedRequest.RouteFactory((int)aToken));
        return aBalanceContainer.Balance;
      }

      private async Task<string> GetDataString(uint aToken)
      {
        ViewTokenDataSharedResponse dataString = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(ViewTokenDataSharedRequest.RouteFactory((int)aToken));
        string aDataString = dataString.TokenDataString;
        return aDataString;
      }

      private async Task<NftTemplate> GetNft(uint aToken)
      {   // TokenNftTypeData Should already have the data in state so no need to make a service call
        GetTokenNftTypeSharedResponse nftContainer = await HttpClient.GetJsonAsync<GetTokenNftTypeSharedResponse>(GetTokenNftTypeSharedRequest.RouteFactory((int)aToken));
        NftTemplate template = WebThreeState.TemplateDataList.Find(aNft => aNft.NftId == nftContainer.NftType);
        return template;
      }
    }
  }
}