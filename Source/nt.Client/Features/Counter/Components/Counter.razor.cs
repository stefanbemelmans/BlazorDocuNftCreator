namespace nt.Client.Features.Counter.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.Counter;

  public class CounterModel : BaseComponent
  {
    internal void ButtonClick() =>
      Mediator.Send(new IncrementCounterAction { Amount = 5 });
  }
}