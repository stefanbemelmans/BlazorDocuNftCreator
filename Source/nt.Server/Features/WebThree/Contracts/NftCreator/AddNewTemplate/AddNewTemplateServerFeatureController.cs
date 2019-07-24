﻿namespace nt.Server.Features.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using System.Threading.Tasks;
  using nt.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate;

  [Route(AddNewTemplateSharedRequest.Route)]
  public class AddNewTemplateServerFeaturesController : BaseController<AddNewTemplateSharedRequest, AddNewTemplateSharedResponse> 
  {
    public async Task<IActionResult> Get(AddNewTemplateSharedRequest aRequest) => await Send(aRequest);
  }
}
