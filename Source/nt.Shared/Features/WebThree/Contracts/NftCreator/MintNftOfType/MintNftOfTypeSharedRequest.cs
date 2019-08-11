namespace nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using nt.Shared.Features.Base;
  using MediatR;

  public class MintNftOfTypeSharedRequest : BaseRequest, IRequest<MintNftOfTypeSharedResponse>
  {
    public const string Route = "api/mintNftOfType";

    public static string RouteFactory(int aId, string mutable, string immutable) => $"api/mintNftOfType?MintNftId={aId}?MutableDataString={mutable}?ImmutableDataString={immutable}";
    public int MintNftId { get; set; }
    public string ImmutableDataString { get; set; }
    public string MutableDataString { get; set; }
  }

}
