namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftCount
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount;

  [Route(GetNftCountSharedRequest.Route)]
  public class GetNftCountServerFeaturesController : BaseController<GetNftCountSharedRequest, GetNftCountSharedResponse> 
  {
    public async Task<IActionResult> Get(GetNftCountSharedRequest aRequest) => await Send(aRequest);
  }
}
