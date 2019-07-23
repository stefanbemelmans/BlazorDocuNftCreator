namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType
{
  using MediatR;
  public class GetAllTokensOfTypeServiceRequest : IRequest<GetAllTokensOfTypeServiceResponse>
    {
      public uint GetAllTokensOfType { get; set; }
    
    }
}
