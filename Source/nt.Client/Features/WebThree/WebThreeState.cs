namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using System.Collections.Generic;
  using nt.Client.Features.WebThree.Actions;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;

  internal partial class WebThreeState : State<WebThreeState>
  {
    [Inject]
    IMediator Mediator { get; set; }
    public WebThreeState() { }

    public uint TotalNftTypes { get; set; }
    public uint TotalTokenTypes { get; set; } 
    public List<uint> CurrentTokenIds { get; set; } 
    public NftTemplate CurrentNftType { get; set; }
    protected override void Initialize()
    {
      Mediator.Send(new GetTotalNftsAction());
      Mediator.Send(new GetAllOwnedTokensAction());
      TotalTokenTypes = (uint)CurrentTokenIds.Count;
    }
    

  }
}
