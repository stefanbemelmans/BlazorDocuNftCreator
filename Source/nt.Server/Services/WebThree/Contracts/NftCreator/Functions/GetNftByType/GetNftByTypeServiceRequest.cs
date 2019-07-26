namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  public class GetNftByTypeServiceRequest : IRequest<GetNftByTypeServiceResponse>
    {
      public uint GetNftId { get; set; }
    
    }
}
