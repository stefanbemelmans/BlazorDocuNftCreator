namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using System;
  using nt.Shared.Features.Base;

  public class GetNftByTypeSharedResponse : BaseResponse
  {
    public GetNftByTypeSharedResponse(Guid aRequestId)
    {
      RequestId = aRequestId;
    }
    public NftTemplate NftTypeData { get; set; }
  }
}