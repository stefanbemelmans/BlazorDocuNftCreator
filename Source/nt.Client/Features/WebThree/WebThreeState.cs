namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using System.Collections.Generic;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public uint TotalNftTypes { get; set; }

    public List<uint> CurrentTokenIds { get; set; } 
    public NftTemplate CurrentNftType { get; set; }
    protected override void Initialize() { }
    

  }
}
