namespace nt.Client.Features.Base.Components
{
  using nt.Client.Features.Application;

  public class ResetButtonModel : BaseComponent
  {
    internal void ButtonClick() => Mediator.Send(new ResetStoreAction());
  }
}