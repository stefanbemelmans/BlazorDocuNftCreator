namespace nt.Client.Features.WebThree.Actions.ChangeCurrentToken
{
  using MediatR;
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;
  public class ChangeCurrentTokenAction : BaseRequest, IRequest<WebThreeState>
  {
    public int TokenId { get; set; }
  }
}