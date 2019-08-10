namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTokenNftType
{
  using MediatR;
  public class GetTokenNftTypeServiceRequest : IRequest<GetTokenNftTypeServiceResponse>
    {
      public uint TokenId { get; set; }
    
    }
}
