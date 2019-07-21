namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  using nt.Shared.Features.Base;
  using MediatR;

public class GetNftByTypeSharedRequest : BaseRequest, IRequest<GetNftByTypeSharedResponse>
  {
    public const string Route = "api/getNftByType";

    public int GetNftType { get; set; }
  }

}