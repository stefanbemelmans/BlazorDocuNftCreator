namespace nt.Server.Features.WebThree.Contracts.NftCreator.GetNftTypes
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;

  [Route(GetNftTypesSharedRequest.Route)]
  public class GetNftTypesServerFeaturesController : BaseController<GetNftTypesSharedRequest, GetNftTypesSharedResponse> 
  {
    public async Task<IActionResult> Get(GetNftTypesSharedRequest aRequest) => await Send(aRequest);
  }
}
