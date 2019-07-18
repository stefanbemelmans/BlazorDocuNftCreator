namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Shared.Features.WebThree;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  class GetNftTypesTests
  {
    public GetNftTypesTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task GetNftTemplatesShouldBeTwo()
    {
      var getNftRequest = new GetNftTypesRequest();

      GetNftTypesResponse response = await Mediator.Send(getNftRequest);

      response.ShouldNotBeNull();
      response.TotalNfts.ShouldBe(2);
    }
  }
}
