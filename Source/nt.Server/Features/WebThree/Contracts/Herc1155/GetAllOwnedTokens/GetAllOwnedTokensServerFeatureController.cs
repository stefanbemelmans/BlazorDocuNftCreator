namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetAllOwnedTokens
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;

  [Route(GetAllOwnedTokensSharedRequest.Route)]
  public class GetAllOwnedTokensServerFeaturesController : BaseController<GetAllOwnedTokensSharedRequest, GetAllOwnedTokensSharedResponse> 
  {
    public async Task<IActionResult> Get(GetAllOwnedTokensSharedRequest aRequest) => await Send(aRequest);
  }
}
