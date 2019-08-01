namespace nt.Client.Features.WebThree
{
  using MediatR;
  using nt.Client.Features.WebThree.Actions.GetTokenNftType;

  public class FetchTokenNftTypeAction : IRequest<WebThreeState>
  {
   public int TokenId { get; set; }
  }
}
