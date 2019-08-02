using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using nt.Shared.Features.WebThree;
using nt.Client.Features.WebThree.Actions.ChangeCurrentNft;

namespace nt.Client.Features.WebThree
{
    internal partial class WebThreeState : State<WebThreeState>
    {
        public class ChangeCurrentNftHandler : RequestHandler<ChangeCurrentNftAction, WebThreeState>
        {
            public ChangeCurrentNftHandler
               (
                 IStore aStore
               ) : base(aStore)
            {
            }
            WebThreeState WebThreeState => Store.GetState<WebThreeState>();

            public override Task<WebThreeState> Handle
              (
                ChangeCurrentNftAction aChangeCurrentNftRequest,
                CancellationToken aCancellationToken
              )
            {

                string TemplateName = aChangeCurrentNftRequest.TemplateName;

                //string requestUri = QueryHelpers.AddQueryString(GetNftByTypeSharedRequest.Route, "GetNftType", getNftId.ToString());

                NftTemplate newSelectedTemplate = WebThreeState.TemplateDataList.Find(nft => nft.Name == TemplateName);

                WebThreeState.CurrentNftTemplate = newSelectedTemplate;

                return Task.FromResult(WebThreeState);
            }

        }
    }
}
