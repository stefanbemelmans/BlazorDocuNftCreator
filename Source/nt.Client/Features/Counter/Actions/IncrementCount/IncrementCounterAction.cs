namespace nt.Client.Features.Counter
{
  using MediatR;
  using nt.Shared.Features.Base;

  public class IncrementCounterAction : BaseRequest, IRequest<CounterState>
  {
    public int Amount { get; set; }
  }
}