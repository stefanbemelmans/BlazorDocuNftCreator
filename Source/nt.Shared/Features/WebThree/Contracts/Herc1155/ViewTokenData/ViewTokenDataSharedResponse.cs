namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{ 
  using System;
  using nt.Shared.Features.Base;

  public class ViewTokenDataSharedResponse : BaseResponse
  {
    public ViewTokenDataSharedResponse(Guid aRequestId)
    {
      RequestId = aRequestId;
    }
    public string TokenUri { get; set; }
  }
}
