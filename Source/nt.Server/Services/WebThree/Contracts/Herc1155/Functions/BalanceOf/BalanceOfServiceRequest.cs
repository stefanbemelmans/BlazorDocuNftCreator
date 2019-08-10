namespace nt.Server.Services.WebThree.Contracts.Herc1155.BalanceOf
{
  using MediatR;

  public class BalanceOfServiceRequest : IRequest<BalanceOfServiceResponse>
    {
    public uint TokenId { get; set; }
    }
}
