namespace nt.Server.Features.WebThree.Contracts.Herc1155.ViewMutableData
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;

[Route(ViewMutableDataSharedRequest.Route)]
public class ViewMutableDataServerFeaturesController : BaseController<ViewMutableDataSharedRequest, ViewMutableDataSharedResponse>
  {
    public async Task<IActionResult> Get(ViewMutableDataSharedRequest aRequest) => await Send(aRequest);
  }
}
