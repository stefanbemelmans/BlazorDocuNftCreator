namespace nt.Client.Features.WebThree.Actions.MintNft
{
  using nt.Client.Features.Base;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
    internal partial class WebThreeState
    {

  public class MintNftOfTypeHandler : BaseHandler<MintNftOfTypeHandler, WebThreeState>
  {
   
        public MintNftOfTypeHandler
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
               MintNftOfTypeHandler aMintNftOfClientRequest,
               CancellationToken aCancellationToken
             )
        {



        }

    }
