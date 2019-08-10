namespace nt.Client.Layout
{
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Components.Layouts;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using System.ComponentModel;

  public class AssetNftLayoutModel :  LayoutComponentBase 
  {
    [Inject]
    IMediator mediator { get; set; }

    //protected override async Task OnAfterRenderAsync()
    //{
      // Are we in the proper state for this page?

     //await mediator.Send(new GetNftTypesClientFeaturesAction());
      


  }
}
