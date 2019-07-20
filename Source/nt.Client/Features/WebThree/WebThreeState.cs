namespace nt.Client.Features.WebThree
{
  using BlazorState;
  //using MediatR;
  //using Microsoft.AspNetCore.Components;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; } 
    public WebThreeState()
    {
      TotalNftTypes = 5;
    }
    //public int CurrentNftType { get; set; } = 5;

    //[Inject]
    //IMediator Mediator { get; set; }
    //public WebThreeState() { }



    protected override void Initialize() { }


  }
}
