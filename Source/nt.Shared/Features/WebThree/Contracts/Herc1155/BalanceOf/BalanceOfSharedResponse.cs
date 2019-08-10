namespace nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf
{
  using System;
  using System.Collections.Generic;
  using nt.Shared.Features.Base;

  public class BalanceOfSharedResponse : BaseResponse
  {
    public BalanceOfSharedResponse() { }

    public BalanceOfSharedResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public int Balance { get; set; }
  }
}