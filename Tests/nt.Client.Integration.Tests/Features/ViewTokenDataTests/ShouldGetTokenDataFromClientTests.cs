namespace nt.Client.Integration.Tests.Features.ViewTokenDataTests
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.WebThree.Actions.ViewTokenData;
  using nt.Client.Integration.Tests.Infrastructure;
  using System.Net.Http;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;

  class ShouldGetTokenDataFromClientTests
    {
        private IServiceProvider ServiceProvider { get; }
        private HttpClient HttpClient { get; }
        private IMediator Mediator { get; }
        public ShouldGetTokenDataFromClientTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;
            Mediator = ServiceProvider.GetService<IMediator>();
            HttpClient = ServiceProvider.GetService<HttpClient>();
            //NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
        }

        public void ViewTokenDataSharedRouteFactoryShouldWork()
        {
      string uriString = ViewTokenDataSharedRequest.RouteFactory(3);
            uriString.ShouldBe("api/viewTokenData?TokenIdToGet=3");
        }
        public void ViewTokenDataSharedRequestShouldWork()
        {
            var TestAction = new ViewTokenDataAction() { TokenIdToGet = 3 };
            var testRequest = new ViewTokenDataSharedRequest()
            {
                TokenIdToGet = TestAction.TokenIdToGet 
            };

            testRequest.TokenIdToGet.ShouldBe((uint)3);
        }

        public async Task ShouldRetrieveToken3DataFromClient()
        {
      string uriString = ViewTokenDataSharedRequest.RouteFactory(3);

      ViewTokenDataSharedResponse clientResponse = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(uriString);

            clientResponse.ShouldBeOfType<ViewTokenDataSharedResponse>();

            clientResponse.TokenDataString.ShouldNotBe(null);
        }

        public async Task ShouldRetrieveToken4DataFromClient()
        {
      string uriString = ViewTokenDataSharedRequest.RouteFactory(4);

      ViewTokenDataSharedResponse clientResponse = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(uriString);

            clientResponse.TokenDataString.ShouldNotBe(null);

        }
        public async Task ShouldRetrieveTokenBalanceFromClient()
        {
      string uriString = BalanceOfSharedRequest.RouteFactory(3);

      BalanceOfSharedResponse clientResponse = await HttpClient.GetJsonAsync<BalanceOfSharedResponse>(uriString);

            clientResponse.ShouldBeOfType<BalanceOfSharedResponse>();

            //clientResponse.Balance.ShouldNotBe(0);
            clientResponse.Balance.ShouldBe(0);
        }
    }

}
