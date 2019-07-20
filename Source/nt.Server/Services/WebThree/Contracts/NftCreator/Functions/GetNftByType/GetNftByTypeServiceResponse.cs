namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  public class GetNftByTypeServiceResponse : BaseResponse
    {
    public NftTemplate NftTypeData { get; set; }
    }
}
