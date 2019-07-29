namespace nt.Client.Integration.Tests.Features.WebThree.GetByType
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;

  internal class FetchNftByTypeTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    public FetchNftByTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task ClientActionTest()
    {

      var aGetNftByTypeAction = 
        new GetNftByTypeClientFeaturesAction
      {
        GetNftType = 1
      };

      WebThreeState aGetNftByTypeResponse = await Mediator.Send(aGetNftByTypeAction);

      aGetNftByTypeResponse.ShouldNotBe(null);
      aGetNftByTypeResponse.CurrentNftType.ShouldNotBe(null);

      aGetNftByTypeResponse.CurrentNftType.Name.ShouldBeOfType<string>();
    }

    //public async Task Should_Fetch_NftTypes()
    //{
     
    //  WebThreeState response = await Mediator.Send(new GetNftTypesClientFeaturesAction());

    //  response.CurrentNftType.Name.ShouldBeOfType<string>();
    //}

  }
}
