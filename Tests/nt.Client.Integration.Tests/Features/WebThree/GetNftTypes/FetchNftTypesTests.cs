namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using BlazorState;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;
  using System.Text.Json.Serialization;

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


    public async Task Should_GetJsonFromRouteAsync()
    {
      using HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(GetNftTypesSharedRequest.Route);
      string content = await httpResponseMessage.Content.ReadAsStringAsync();

      var getNftTypesSharedResponse = new GetNftTypesSharedResponse();

      GetNftTypesSharedResponse response = JsonSerializer.Parse<GetNftTypesSharedResponse>(content);

      getNftTypesSharedResponse.TotalNftTypes = response.TotalNftTypes;

      getNftTypesSharedResponse.TotalNftTypes.ShouldBe(2);

    }
    public async Task Should_Fetch_NftTypes()
    {
      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      response.TotalNftTypes.ShouldBe(2);
    }

  }
}
