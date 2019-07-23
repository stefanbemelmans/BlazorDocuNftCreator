namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType
{
  using MediatR;
  using System.Collections.Generic;

  public class MintNftOfTypeServiceRequest : IRequest<MintNftOfTypeServiceResponse>
    {
      public int MintNftId { get; set; }

    public List<string> ImmutableData { get; set; }

    public List<string> MutableData { get; set; }
    
    }
}
