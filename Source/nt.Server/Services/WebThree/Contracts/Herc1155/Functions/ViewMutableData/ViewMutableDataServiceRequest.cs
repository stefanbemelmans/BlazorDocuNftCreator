namespace nt.Server.Services.WebThree.Contracts.Herc1155
  using MediatR;

  public class ViewMutableDataServiceRequest : IRequest<ViewMutableDataServiceResponse>
    {
    public uint ViewTokenId { get; set; }
    }
}
