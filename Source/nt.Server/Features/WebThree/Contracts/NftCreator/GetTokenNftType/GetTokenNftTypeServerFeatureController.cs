namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetTokenNftType
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;

  [Route(GetTokenNftTypeSharedRequest.Route)]
  public class GetTokenNftTypeServerFeaturesController : BaseController<GetTokenNftTypeSharedRequest, GetTokenNftTypeSharedResponse> 
  {
    public async Task<IActionResult> Get(GetTokenNftTypeSharedRequest aRequest) => await Send(aRequest);
  }
}
