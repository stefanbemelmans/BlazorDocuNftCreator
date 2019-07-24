namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
  using System;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using MediatR;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;

  class GetNftTypesTests
  {
    public GetNftTypesTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    // this test is not working either
    public async Task GetNftTemplatesShouldBeTwo()
    {
      var getNftTypeRequest = new GetNftTypesSharedRequest();

      GetNftTypesSharedResponse response = await Mediator.Send(getNftTypeRequest);

      response.TotalNftTypes.ShouldBe(2);
    }
  }
}
