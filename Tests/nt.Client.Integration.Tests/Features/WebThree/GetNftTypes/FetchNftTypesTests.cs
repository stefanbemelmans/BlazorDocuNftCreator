namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;

  internal class FetchNftTypesTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private HttpClient HttpClient { get; }
    public FetchNftTypesTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      HttpClient = ServiceProvider.GetService<HttpClient>();
    }

    public async Task ClientActionTest()
    {
      
      var Action = new GetNftTypesClientFeaturesAction();

      WebThreeState ActionResponse = await Mediator.Send(Action);

      ActionResponse.ShouldNotBe(null);
      ActionResponse.TotalNftTypes.ShouldBeGreaterThan(2);

    }

    public async Task Should_Fetch_NftTypes()
    {
      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      response.TotalNftTypes.ShouldBeGreaterThan(2);
    }

  }
}
