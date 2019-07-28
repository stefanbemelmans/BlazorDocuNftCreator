namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using BlazorState;
  using MediatR;
  using System.Threading.Tasks;
  internal class WebThreeStateTests
  {
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private WebThreeState webThreeState { get; set; }

    public WebThreeStateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Store = ServiceProvider.GetService<IStore>();
    }

    public void WebThreeState_Should_Exist()
    {

      webThreeState = Store.GetState<WebThreeState>();

      webThreeState.ShouldNotBe(null);

      webThreeState.TotalNftTypes.ShouldBeGreaterThan((uint)0);
      //var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      //WebThreeState = await Mediator.Send(fetchNftTypes);

      //WebThreeState.TotalNftTypes.ShouldBe(2);
    }

  }
}
