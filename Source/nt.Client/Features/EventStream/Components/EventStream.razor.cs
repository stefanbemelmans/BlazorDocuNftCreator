namespace nt.Client.Features.EventStream.Components
{
  using System.Collections.Generic;
  using nt.Client.Features.Base.Components;

  public class EventStreamModel : BaseComponent
  {
    public IReadOnlyList<string> Events => EventStreamState.Events;

  }
}
