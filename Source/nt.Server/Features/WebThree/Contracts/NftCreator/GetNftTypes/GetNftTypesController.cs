namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftTypes
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using nt.Shared.Features.WebThree;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetNftTypesRequest.Route)]
  public class GetNftTypesController : BaseController<GetNftTypesRequest, GetNftTypesResponse> 
  {
    [HttpGet]
    public async Task<IActionResult> Get(GetNftTypesRequest aRequest) => await Send(aRequest);
  }
}
