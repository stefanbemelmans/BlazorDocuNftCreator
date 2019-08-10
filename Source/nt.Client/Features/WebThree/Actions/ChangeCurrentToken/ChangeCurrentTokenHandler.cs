using BlazorState;
using nt.Client.Features.Base;
using nt.Client.Features.WebThree.Actions.ChangeCurrentToken;
using nt.Client.Features.WebThree.Components.NftTemplates;
using System.Threading;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree
{
    internal partial class WebThreeState : State<WebThreeState>
    {
        public class ChangeCurrentTokenHandler : BaseHandler<ChangeCurrentTokenAction, WebThreeState>
        {
            public ChangeCurrentTokenHandler
               (
                 IStore aStore
               ) : base(aStore)
            {
            }

            public override Task<WebThreeState> Handle
              (
                ChangeCurrentTokenAction aChangeCurrentTokenRequest,
                CancellationToken aCancellationToken
              )
            {

                int TokenId = aChangeCurrentTokenRequest.TokenId;

                //string requestUri = QueryHelpers.AddQueryString(GetNftByTypeSharedRequest.Route, "GetNftType", getNftId.ToString());

                TokenBase newSelectedToken = WebThreeState.TokenDataList.Find(token => token.TokenId == TokenId);

                WebThreeState.CurrentTokenData = newSelectedToken;

                return Task.FromResult(WebThreeState);
            }

        }
    }
}
