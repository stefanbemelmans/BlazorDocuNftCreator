namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  [Route(GetNftByTypeSharedRequest.Route)]
  public class GetNftByTypeServerFeaturesController : BaseController<GetNftByTypeSharedRequest, GetNftByTypeSharedResponse> 
  {
    public async Task<IActionResult> Get(GetNftByTypeSharedRequest aRequest) => await Send(aRequest);
  }
}
