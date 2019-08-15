namespace nt.Client.Features.WebThree.Components
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;

  public class MintingModalModel : BaseComponent
  {
    [Parameter]
    public bool IsMinting { get; set; } = false;

    public void ChangeModalState() => IsMinting = !IsMinting;

  }
}
