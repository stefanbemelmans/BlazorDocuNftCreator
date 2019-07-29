namespace nt.Client.Features.WebThree
{
  using MediatR;
  public class GetNftByTypeClientFeaturesAction : IRequest<WebThreeState>
  {
   public uint GetNftType { get; set; }
  }
}
