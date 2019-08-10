namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetTokenNftTypeSharedRequest : BaseRequest, IRequest<GetTokenNftTypeSharedResponse>
  {
    public const string Route = "api/GetTokenNftType";

    public static string RouteFactory(int aId) => $"api/GetTokenNftType?TokenId={aId}";
    public uint TokenId { get; set; }
  }

}