namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType
{
  using nt.Shared.Features.Base;
  using System.Collections.Generic;

  public class GetAllTokensOfTypeServiceResponse : BaseResponse
    {
    public List<uint> TokenList { get; set; }
    }
}
