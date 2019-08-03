﻿using System;
using System.Collections.Generic;
using System.Text;

namespace nt.Client.Integration.Tests.Features.ViewTokenDataTests
{
    using System;
    using MediatR;
    using AnySerializer;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
    using System.Threading.Tasks;
    using nt.Shared.Constants.AccountAddresses;
    using nt.Shared.Features.WebThree.Contracts.Herc1155;
    using nt.Server.Services.WebThree.Instance;
    using Nethereum.Contracts;
    using Nethereum.RPC.Eth.DTOs;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.WebThree.Actions.ViewTokenData;
    using nt.Client.Integration.Tests.Infrastructure;
    using System.Net.Http;
    using nt.Shared.Features.WebThree.Contracts.Herc1155.ViewTokenData;

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
            var uriString = ViewTokenDataSharedRequest.RouteFactory(3);
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
            var uriString = ViewTokenDataSharedRequest.RouteFactory(3);

            var clientResponse = await HttpClient.GetJsonAsync<ViewTokenDataSharedResponse>(uriString);

            clientResponse.ShouldBeOfType<ViewTokenDataSharedResponse>();

            clientResponse.TokenDataString.ShouldNotBe(null);
        }

    }

}
