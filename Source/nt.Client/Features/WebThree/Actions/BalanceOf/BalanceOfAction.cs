namespace nt.Client.Features.WebThree.Actions.BalanceOf
{
  using MediatR;
  using nt.Shared.Constants.AccountAddresses;

  public class BalanceOfAction : IRequest<WebThreeState>
  {
    public uint TokenId { get; set; }
  }
}
