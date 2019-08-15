namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount
{
  using System;
  using nt.Shared.Features.Base;

  public class GetNftCountSharedResponse : BaseResponse
  {
    public uint NftCount{ get; set; }
  }
}