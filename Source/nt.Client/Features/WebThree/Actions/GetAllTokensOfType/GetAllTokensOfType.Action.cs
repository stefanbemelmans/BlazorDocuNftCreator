namespace nt.Client.Features.WebThree.Actions.GetAllTokensOfType
{
  using MediatR;

  public class GetAllTokensOfTypeAction : IRequest<WebThreeState>
  {
    public uint GetAllTokensOfType { get; set; }
  }
}
