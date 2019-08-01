namespace nt.Client.Features.WebThree
{
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using nt.Client.Features.WebThree.Actions.ChangeCurrentNft;

  internal partial class WebThreeState
  {
    public class ChangeCurrentNftHandler : RequestHandler<ChangeCurrentNftAction, WebThreeState>
    {
      public ChangeCurrentNftHandler
         (
           IStore aStore,
           HttpClient aHttpClient
         ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }
      WebThreeState WebThreeState => Store.GetState<WebThreeState>();

      public override Task<WebThreeState> Handle
        (
          ChangeCurrentNftAction aChangeCurrentNftRequest,
          CancellationToken aCancellationToken
        )
      {

        int newNftId = (int)aChangeCurrentNftRequest.NewNftTypeIndex;

        //string requestUri = QueryHelpers.AddQueryString(GetNftByTypeSharedRequest.Route, "GetNftType", getNftId.ToString());
        
        NftTemplate newSelectedTemplate = WebThreeState.TemplateDataList[newNftId];
        WebThreeState.CurrentNftTemplate = newSelectedTemplate;

        return Task.FromResult(WebThreeState);
      }

    }
  }
}
