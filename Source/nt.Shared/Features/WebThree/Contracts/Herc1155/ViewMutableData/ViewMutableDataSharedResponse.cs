namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{  using System;
  using nt.Shared.Features.Base;

  public class ViewMutableDataSharedResponse : BaseResponse
  {
    public ViewMutableDataSharedResponse(Guid aRequestId)
    {
      RequestId = aRequestId;
    }
    public string MutableDataString { get; set; }
  }
}