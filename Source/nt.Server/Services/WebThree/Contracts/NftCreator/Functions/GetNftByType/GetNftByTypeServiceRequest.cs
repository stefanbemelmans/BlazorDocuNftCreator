namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using MediatR;
  using nt.Client.Server.Services.WebThree.NftCreator.Functions.GetNftByType;

  public class GetNftByTypeServiceRequest : IRequest<GetNftByTypeServiceResponse>
    {
      public int GetNftId { get; set; }
    
    }
}
