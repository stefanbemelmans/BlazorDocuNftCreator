namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetNftByTypeSharedRequest : BaseRequest, IRequest<GetNftByTypeSharedResponse>
  {
    public const string Route = "api/getNftByType";

    public static string RouteFactory(uint aId) => $"api/getNftByType?GetNftType={aId}";
    public uint GetNftType { get; set; }
  }

}