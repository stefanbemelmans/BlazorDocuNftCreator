namespace nt.Client.Integration.Tests.Features.WebThree.GetTokenNftType
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;

  internal class FetchGetTokenNftTypeTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    public FetchGetTokenNftTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task ClientGetTokenNftType()
    {

      var aFetchTokenNftTypeAction = 
        new FetchTokenNftTypeAction
      {
        TokenId = 2
      };

      WebThreeState aFetchTokenNftTypeResponse = await Mediator.Send(aFetchTokenNftTypeAction);

      aFetchTokenNftTypeResponse.CurrentTokenNftType.ShouldNotBe((uint)0);
      aFetchTokenNftTypeResponse.CurrentTokenNftType.ShouldBe((uint)1);

    }
       
  }
}
