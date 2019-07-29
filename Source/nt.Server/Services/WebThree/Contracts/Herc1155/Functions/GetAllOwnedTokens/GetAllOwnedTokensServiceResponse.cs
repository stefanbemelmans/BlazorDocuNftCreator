namespace nt.Server.Services.WebThree.Contracts.Herc1155.GetAllOwnedTokens
{
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  public class GetAllOwnedTokensServiceResponse : BaseResponse
    {
    public List<uint> TokenIdList { get; set; }
    }
}
