namespace nt.Client.Features.WebThree
{
  using BlazorState;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; }

    public int CurrentNftType { get; set; }

    //public WebThreeState() { }

    protected override void Initialize()
    {
      // Get TotalNftTypesAction
      TotalNftTypes = 5;
    }
  }
}
