namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
  using System;
  using System.Collections.Generic;
  using nt.Shared.Features.Base;

  public class GetAllOwnedTokensSharedResponse : BaseResponse
  {
    public GetAllOwnedTokensSharedResponse() { }

    public GetAllOwnedTokensSharedResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public List<uint> TokenIdList { get; set; }
  }
}