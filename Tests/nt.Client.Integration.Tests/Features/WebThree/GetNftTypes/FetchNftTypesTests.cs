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
  internal class FetchNftTypesTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private WebThreeState WebThreeState { get; set; }

    public FetchNftTypesTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      WebThreeState = Store.GetState<WebThreeState>();
    }

    public async Task Should_Fetch_NftTypes()
    {
      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState = await Mediator.Send(fetchNftTypes);

      WebThreeState.TotalNftTypes.ShouldBe(2);
    }

  }
}
