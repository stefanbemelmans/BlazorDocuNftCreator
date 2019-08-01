namespace nt.Client.Features.WebThree.Actions.ChangeCurrentNft
{
  using MediatR;
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;
  public class ChangeCurrentNftAction : BaseRequest, IRequest<WebThreeState>
  {
    public uint NewNftTypeIndex { get; set; }
  }
}