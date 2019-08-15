namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount

{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetNftCountSharedRequest : BaseRequest, IRequest<GetNftCountSharedResponse>
  {
    public const string Route = "api/getNftCount";
  }

}