namespace nt.Server.Features.WebThree.Contracts.Herc1155.ViewTokenData
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;

[Route(ViewTokenDataSharedRequest.Route)]
public class ViewTokenDataServerFeaturesController : BaseController<ViewTokenDataSharedRequest, ViewTokenDataSharedResponse>
  {
    public async Task<IActionResult> Get(ViewTokenDataSharedRequest aRequest) => await Send(aRequest);
  }
}
