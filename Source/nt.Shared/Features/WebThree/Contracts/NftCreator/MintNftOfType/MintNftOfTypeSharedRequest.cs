namespace nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using nt.Shared.Features.Base;
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;

  public class MintNftOfTypeClientAction : BaseRequest, IRequest<WebThreeState>
  {
    public const string Route = "api/mintNftOfType";

    public static string RouteFactory(int aId) => $"api/mintNftOfType?MintNftType={aId}";
    public int MintNftId { get; set; }
    public string ImmutableDataString { get; set; }
    public string MutableDataString { get; set; }
  }

}
