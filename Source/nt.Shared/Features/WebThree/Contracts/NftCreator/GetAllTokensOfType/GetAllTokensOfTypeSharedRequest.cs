namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetAllTokensOfTypeSharedRequest : BaseRequest, IRequest<GetAllTokensOfTypeSharedResponse>
  {
    public const string Route = "api/getAllTokensByType";

    public static string RouteFactory(uint aId) => $"api/getAllTokensOfType?GetAllTokensOfType={aId}";
    public uint GetAllTokensOfType { get; set; }
  }

}