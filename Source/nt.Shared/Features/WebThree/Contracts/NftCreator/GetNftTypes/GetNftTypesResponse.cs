namespace nt.Shared.Features.WebThree
{
  using System;
  using nt.Shared.Features.Base;

  public class GetNftTypesResponse : BaseResponse
  {
    public GetNftTypesResponse() { }

    public GetNftTypesResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public int TotalNfts { get; set; }
  }
}