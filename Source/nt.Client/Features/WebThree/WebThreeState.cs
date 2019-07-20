namespace nt.Client.Features.WebThree
{
  using BlazorState;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; } = 5;

    public int CurrentNftType { get; set; } = 5;

    //public WebThreeState() { }

    protected override void Initialize()
    {
      
    }
  }
}
