namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetAllOwnedTokensSharedRequest : BaseRequest, IRequest<GetAllOwnedTokensSharedResponse>
  {
    public const string Route = "api/getAllOwnedTokens";

    public static string RouteFactory(string aId) => $"api/getAllOwnedTokens?TokenOwner={aId}";
    public string TokenOwner { get; set; }
  }

}