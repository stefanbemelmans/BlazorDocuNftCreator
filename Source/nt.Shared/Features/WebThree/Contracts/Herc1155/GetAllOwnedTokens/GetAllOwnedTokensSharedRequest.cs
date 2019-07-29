namespace nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetAllOwnedTokensSharedRequest : BaseRequest, IRequest<GetAllOwnedTokensSharedResponse>
  {
    public const string Route = "api/getAllOwnedTokens";

  }

}