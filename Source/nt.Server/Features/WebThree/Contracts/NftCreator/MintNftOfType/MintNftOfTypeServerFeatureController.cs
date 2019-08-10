namespace nt.Server.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;

  [Route(MintNftOfTypeSharedRequest.Route)]
  public class MintNftOfTypeServerFeaturesController : BaseController<MintNftOfTypeSharedRequest, MintNftOfTypeSharedResponse> 
  {
    public async Task<IActionResult> Get(MintNftOfTypeSharedRequest aRequest) => await Send(aRequest);
  }
}
