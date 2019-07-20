namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public int TotalNftTypes { get; set; }
    public IMediator Mediator{ get; set; }
    public GetNftTypesSharedResponse Response { get; set; }

   public  WebThreeState(IMediator aMediator)
    {
      Mediator = aMediator;  
    }
    //public int CurrentNftType { get; set; } = 5;



    protected override async void Initialize()
    {
      WebThreeState Nfts = await Mediator.Send(new GetNftTypesClientFeaturesAction());

      TotalNftTypes = Response.TotalNftTypes; 

    }


  }
}
