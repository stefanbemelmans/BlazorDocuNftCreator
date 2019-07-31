namespace nt.Client.Integration.Tests.Features.WebThree.FetchAllOwnedTokens
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;

  internal class FetchAllOwnedTokensTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }

    public WebThreeState newWebState = new WebThreeState();
    public FetchAllOwnedTokensTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task ClientActionTest()
    {

      var aGetAllOwnedTokensAction = new GetAllOwnedTokensAction();
      
      newWebState = await Mediator.Send(aGetAllOwnedTokensAction);

      newWebState.ShouldNotBe(null);
      newWebState.OwnedTokenIdList.ShouldNotBe(null);

      newWebState.OwnedTokenIdList.Count.ShouldBe(3);
    }

    //public async Task Should_Fetch_NftTypes()
    //{
     
    //  WebThreeState response = await Mediator.Send(new GetNftTypesClientFeaturesAction());

    //  response.CurrentNftType.Name.ShouldBeOfType<string>();
    //}

  }
}
