namespace nt.Client.Integration.Tests.Features.WebThree.GetNftCount
{
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Integration.Tests.Infrastructure;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount;
  using Shouldly;
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  internal class FetchNftCountTests
  {
    private HttpClient HttpClient { get; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }

    public FetchNftCountTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      HttpClient = ServiceProvider.GetService<HttpClient>();
    }

    public async Task ClientActionTest()
    {
      GetNftCountSharedResponse countResponse = await HttpClient.GetJsonAsync<GetNftCountSharedResponse>(GetNftCountSharedRequest.Route);

      countResponse.ShouldNotBe(null);
      countResponse.NftCount.ShouldBe((uint)2);
    }

   
  }
}