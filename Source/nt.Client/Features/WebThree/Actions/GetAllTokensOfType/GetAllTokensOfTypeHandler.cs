namespace nt.Client.Features.WebThree
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions.GetAllTokensOfType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;

  internal partial class WebThreeState
  {

    public class GetAllTokensOfTypeHandler : RequestHandler<GetAllTokensOfTypeAction, WebThreeState>
    {
      public GetAllTokensOfTypeHandler
        (
          IStore aStore,
          HttpClient aHttpClient
        ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }


      public override async Task<WebThreeState> Handle
        (
          GetAllTokensOfTypeAction aGetAllTokensOfTypeClientRequest,
          CancellationToken aCancellationToken
        )
      {

        //string requestUri = QueryHelpers.AddQueryString(GetAllTokensOfTypeSharedRequest.Route, "GetNftType", getNftId.ToString());
        string requestUri = GetAllTokensOfTypeSharedRequest.RouteFactory(aGetAllTokensOfTypeClientRequest.GetAllTokensOfType);

        List<uint> tempList = await HttpClient.GetJsonAsync<List<uint>>(requestUri);
        
        //GetAllTokensOfTypeSharedResponse aTokenList = await HttpClient.GetJsonAsync<GetAllTokensOfTypeSharedResponse>(requestUri);



        return new WebThreeState
        {
          CurrentTokenIds = tempList
        };
      }
    }
  }
}
