namespace nt.Client.Features.WebThree.Components
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.ChangeCurrentToken;
  using System.Collections.Generic;

  public class TokenCountComponentModel : BaseComponent
    {
    [Parameter]
    public List<uint> OwnedTokenIdList { get; set; }

    public void SetNewToken(UIChangeEventArgs eventArgs)
    {
      string TokenId = eventArgs.Value.ToString();

      Mediator.Send(new ChangeCurrentTokenAction() { TokenId = int.Parse(TokenId) });
    }

  }

}
