namespace nt.Client.Features.WebThree
{
  using MediatR;
  public class GetNftByTypeAction : IRequest<WebThreeState>
  {
   public uint GetNftType { get; set; }
  }
}
