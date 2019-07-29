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
    public byte[] SerializedTokenData { get; set; }
    // Token Type will determine what object to use to deserialize the data
    public uint TokenType { get; set; }
  }
}
