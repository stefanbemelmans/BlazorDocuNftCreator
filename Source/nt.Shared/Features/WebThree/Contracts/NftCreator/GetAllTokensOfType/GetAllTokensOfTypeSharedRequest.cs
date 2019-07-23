namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetAllTokensOfTypeSharedRequest : BaseRequest, IRequest<GetAllTokensOfTypeSharedResponse>
  {
    public const string Route = "api/getAllTokensByType";

    public static string RouteFactory(int aId) => $"api/getAllTokensOfType?GetAllTokensOfType={aId}";
    public int GetAllTokensOfType { get; set; }
  }

}