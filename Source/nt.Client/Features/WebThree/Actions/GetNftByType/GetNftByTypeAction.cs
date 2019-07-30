namespace nt.Client.Features.WebThree
{
  using MediatR;
  public class GetTotalNftsAction : IRequest<WebThreeState>
  {
   public uint GetNftType { get; set; }
  }
}
