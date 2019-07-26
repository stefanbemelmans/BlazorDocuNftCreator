namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
  using nt.Shared.Features.Base;
  using MediatR;

public class ViewTokenDataSharedRequest : BaseRequest, IRequest<ViewTokenDataSharedResponse>
  {
    public const string Route = "api/viewTokenData";

    public static string RouteFactory(uint aId) => $"api/ViewTokenData?ViewTokenId={aId}";
    public uint ViewTokenId { get; set; }
  }

}