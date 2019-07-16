namespace nt.Client.Features.Application.Components
{
  using nt.Client.Features.Base.Components;

  public class SideBarModel: BaseComponent
  {
    protected string NavMenuCssClass => ApplicationState.IsMenuExpanded ? null : "collapse";
  }
}
  