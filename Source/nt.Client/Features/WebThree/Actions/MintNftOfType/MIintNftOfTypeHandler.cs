namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base;
  using nt.Client.Features.WebThree.Actions.MintNft;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public class MintNftOfTypeHandler : BaseHandler<MintNftOfTypeAction, WebThreeState>
    {
      private HttpClient HttpClient { get; }

      public MintNftOfTypeHandler
                      (
            IStore aStore,
            HttpClient aHttpClient
          ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }

      public override async Task<WebThreeState> Handle
           (
             MintNftOfTypeAction aMintNftOfClientRequest,
             CancellationToken aCancellationToken
           )
      {
        Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType.WebThreeState MintReceiptContainer = await HttpClient.SendJsonAsync<Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType.WebThreeState>(HttpMethod.Get, MintNftOfTypeClientAction.Route, new MintNftOfTypeClientAction()
        {
          MintNftId = (int)aMintNftOfClientRequest.MintNftId,
          ImmutableDataString = aMintNftOfClientRequest.ImmutableDataString,
          MutableDataString = aMintNftOfClientRequest.MutableDataString
        });

        WebThreeState.MintingTransactionReceipt = MintReceiptContainer.MintingTransactionReceipt;

        return WebThreeState;
      }
    }
  }
}