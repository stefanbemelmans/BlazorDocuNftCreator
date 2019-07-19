namespace nt.Shared.Features.WebThree
{
  using System;
  using nt.Shared.Features.Base;

  public class GetNftTypesSharedResponse : BaseResponse
  {
    public GetNftTypesSharedResponse() { }

    public GetNftTypesSharedResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public int TotalNfts { get; set; }
  }
}