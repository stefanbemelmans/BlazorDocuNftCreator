namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; }

    public NftTemplate CurrentNftType { get; set; }
    protected override void Initialize() { }
    

  }
}
