namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType
{
  using MediatR;
  public class GetAllTokensOfTypeServiceRequest : IRequest<GetAllTokensOfTypeServiceResponse>
    {
      public int GetAllTokensOfType { get; set; }
    
    }
}
