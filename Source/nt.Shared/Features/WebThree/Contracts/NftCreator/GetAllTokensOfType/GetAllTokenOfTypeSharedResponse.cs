namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using System;
  using System.Collections.Generic;
  using nt.Shared.Features.Base;

  public class GetAllTokensOfTypeSharedResponse : BaseResponse
  {
    public GetAllTokensOfTypeSharedResponse() { }

    public GetAllTokensOfTypeSharedResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public List<int> TokenList { get; set; }
  }
}