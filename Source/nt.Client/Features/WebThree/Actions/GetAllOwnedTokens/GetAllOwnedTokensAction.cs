namespace nt.Client.Features.WebThree.Actions.GetAllOwnedTokens
{
  using MediatR;

  public class GetAllOwnedTokensAction : IRequest<WebThreeState>
  {
    public string TokenOwner { get; set; }
  }
}
