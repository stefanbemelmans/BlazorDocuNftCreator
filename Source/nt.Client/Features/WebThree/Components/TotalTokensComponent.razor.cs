namespace nt.Client.Features.WebThree.Components
{
  using MediatR;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public class TotalTokensComponentModel : BaseComponent
  {
    public TotalTokensComponentModel()
    {
    }

    public List<uint> TokenIds => WebThreeState.OwnedTokenIdList;
    public int TotalTokens => TokenIds.Count;

    protected override async Task OnInitAsync() => _ = await Mediator.Send(new GetAllOwnedTokensAction());
    
    //TokenIds = response.CurrentTokenIds;//TotalTokens = response.CurrentTokenIds.Count;
  }
}
