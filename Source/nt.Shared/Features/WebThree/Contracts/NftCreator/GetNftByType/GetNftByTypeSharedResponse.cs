namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using System;
  using nt.Shared.Features.Base;

  public class GetNftByTypeSharedResponse : BaseResponse
  {
    public GetNftByTypeSharedResponse() { }

    public GetNftByTypeSharedResponse(Guid aRequestId)
    {
      
      RequestId = aRequestId;
    }

    public GetNftByTypeOutputDto NftypeData { get; set; }
    public NftTemplate NftData { get; set; }
  }
}