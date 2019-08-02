namespace nt.Client.Features.WebThree
{
  using MediatR;

  public class FetchTokenNftTypeAction : IRequest<WebThreeState>
  {
   public int TokenId { get; set; }
  }
}
