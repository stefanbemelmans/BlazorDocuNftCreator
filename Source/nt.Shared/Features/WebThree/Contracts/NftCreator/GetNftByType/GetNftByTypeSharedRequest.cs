namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using MediatR;
  using nt.Shared.Features.Base;

  public class GetNftByTypeSharedRequest : BaseRequest, IRequest<GetNftByTypeSharedResponse>
  {
    public const string Route = "api/getNftByType";

    public uint GetNftId { get; set; }

    public static string RouteFactory(int aId) => $"api/getNftByType?GetNftType={aId}";
  }
}