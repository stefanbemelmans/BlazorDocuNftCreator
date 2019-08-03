namespace nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData
{
  using nt.Shared.Features.Base;
  using MediatR;

public class ViewTokenDataSharedRequest : BaseRequest, IRequest<ViewTokenDataSharedResponse>
  {
    public const string Route = "api/viewTokenData";

    public static string RouteFactory(int aId) => $"api/viewTokenData?TokenIdToGet={aId}";
    public uint TokenIdToGet { get; set; }
  }

}