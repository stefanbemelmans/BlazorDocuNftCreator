namespace nt.Server.Features.WebThree.Contracts.NftCreator.BalanceOf
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;

  [Route(BalanceOfSharedRequest.Route)]
  public class BalanceOfServerFeaturesController : BaseController<BalanceOfSharedRequest, BalanceOfSharedResponse> 
  {
    public async Task<IActionResult> Get(BalanceOfSharedRequest aRequest) => await Send(aRequest);
  }
}
