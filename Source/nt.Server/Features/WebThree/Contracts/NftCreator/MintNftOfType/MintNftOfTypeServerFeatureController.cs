namespace nt.Server.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;

  [Route(MintNftOfTypeClientAction.Route)]
  public class MintNftOfTypeServerFeaturesController : BaseController<MintNftOfTypeClientAction, WebThreeState> 
  {
    public async Task<IActionResult> Get(MintNftOfTypeClientAction aRequest) => await Send(aRequest);
  }
}
