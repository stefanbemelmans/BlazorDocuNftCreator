namespace nt.Shared.Features.WebThree
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetNftTypesRequest : BaseRequest, IRequest<GetNftTypesResponse>
  {
    public const string Route = "api/getNftTypes";
  }

}