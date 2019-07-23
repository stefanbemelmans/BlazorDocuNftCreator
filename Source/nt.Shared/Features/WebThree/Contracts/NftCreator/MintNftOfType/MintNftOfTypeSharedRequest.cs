using System;
using System.Collections.Generic;
using System.Text;

namespace nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using nt.Shared.Features.Base;
  using MediatR;

  public class MintNftOfTypeSharedRequest : BaseRequest, IRequest<GetNftByTypeSharedResponse>
  {
    public const string Route = "api/mintNftOfType";

    public static string RouteFactory(int aId) => $"api/mintNftOfType?MintNftType={aId}";
    public int MintNftId { get; set; }
  }

}
