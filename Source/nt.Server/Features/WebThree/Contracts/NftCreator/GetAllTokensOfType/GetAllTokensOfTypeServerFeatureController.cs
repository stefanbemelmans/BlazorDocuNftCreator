namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;

  [Route(GetAllTokensOfTypeSharedRequest.Route)]
  public class GetAllTokensOfTypeServerFeaturesController : BaseController<GetAllTokensOfTypeSharedRequest, GetAllTokensOfTypeSharedResponse> 
  {
    public async Task<IActionResult> Get(GetAllTokensOfTypeSharedRequest aRequest) => await Send(aRequest);
  }
}
