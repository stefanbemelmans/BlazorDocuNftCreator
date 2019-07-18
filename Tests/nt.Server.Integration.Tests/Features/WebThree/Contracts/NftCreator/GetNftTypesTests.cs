namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
  using System;
  using nt.Shared.Features.WebThree;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using MediatR;
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
      var getNftTypeRequest = new GetNftTypesRequest();

      GetNftTypesResponse response = await Mediator.Send(getNftTypeRequest);

      response.TotalNfts.ShouldBe(2);
    }
  }
}
