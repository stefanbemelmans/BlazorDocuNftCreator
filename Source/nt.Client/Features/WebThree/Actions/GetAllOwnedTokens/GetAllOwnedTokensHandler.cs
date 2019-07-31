namespace nt.Client.Features.WebThree
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
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

      WebThreeState WebThreeState => Store.GetState<WebThreeState>();
      public override async Task<WebThreeState> Handle
        (
          GetAllOwnedTokensAction aGetAllOwnedTokensClientRequest,
          CancellationToken aCancellationToken
        )
      {

        GetAllOwnedTokensSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllOwnedTokensSharedResponse>(GetAllOwnedTokensSharedRequest.Route);

        WebThreeState.OwnedTokenIdList = aTokenList.TokenIdList;
        return WebThreeState;
        
      }


    }
  }
}
