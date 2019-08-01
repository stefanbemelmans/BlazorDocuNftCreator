namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType
{
  using System;
  using nt.Shared.Features.Base;

  public class GetTokenNftTypeSharedResponse : BaseResponse
  {
    public GetTokenNftTypeSharedResponse() { }
    public GetTokenNftTypeSharedResponse(Guid aRequestId)
    {
      RequestId = aRequestId;
    }
    public uint NftType { get; set; }
  }
}