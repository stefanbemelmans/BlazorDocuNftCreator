

namespace nt.Client.Features.WebThree.Actions.GetNftListInfo
{
  using MediatR;
  using System.Collections.Generic;

  public class GetNftListInfoAction : IRequest<WebThreeState>
    {
        public List<uint> NftsToGet { get; set; }
    }
}
