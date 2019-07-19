namespace nt.Shared.Features.WebThree
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetNftTypesSharedRequest : BaseRequest, IRequest<GetNftTypesSharedResponse>
  {
    public const string Route = "api/getNftTypes";
  }

}