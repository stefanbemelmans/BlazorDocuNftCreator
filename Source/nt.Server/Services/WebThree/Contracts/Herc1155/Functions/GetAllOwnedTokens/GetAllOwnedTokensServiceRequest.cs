namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using MediatR;

  public class GetAllOwnedTokensServiceRequest : IRequest<GetAllOwnedTokensServiceResponse>
    {
    public string TokenOwner { get; set; }
    }
}
