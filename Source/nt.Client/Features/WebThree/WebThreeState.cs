namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; }

    protected override void Initialize() { }
    

  }
}
