namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using MediatR;

  public class ViewTokenDataServiceRequest : IRequest<ViewTokenDataServiceResponse>
    {
    public uint ViewTokenId { get; set; }
    }
}
