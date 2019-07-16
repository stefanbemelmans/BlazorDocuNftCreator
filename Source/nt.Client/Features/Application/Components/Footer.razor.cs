namespace nt.Client.Features.Application.Components
{
  using nt.Client.Features.Base.Components;

  public class FooterModel: BaseComponent
  {
    protected string Version => ApplicationState.Version;
  }
}
