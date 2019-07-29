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
    public FetchAllOwnedTokensTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task ClientActionTest()
    {

      var aGetAllOwnedTokensAction = 
        new GetAllOwnedTokensAction
      {
        TokenOwner = TestEthAccounts.TestEthAccountAddress
      };

      WebThreeState aGetAllOwnedTokensResponse = await Mediator.Send(aGetAllOwnedTokensAction);

      aGetAllOwnedTokensResponse.ShouldNotBe(null);
      aGetAllOwnedTokensResponse.CurrentNftType.ShouldNotBe(null);

      aGetAllOwnedTokensResponse.CurrentNftType.Name.ShouldBeOfType<string>();
    }

    //public async Task Should_Fetch_NftTypes()
    //{
     
    //  WebThreeState response = await Mediator.Send(new GetNftTypesClientFeaturesAction());

    //  response.CurrentNftType.Name.ShouldBeOfType<string>();
    //}

  }
}
