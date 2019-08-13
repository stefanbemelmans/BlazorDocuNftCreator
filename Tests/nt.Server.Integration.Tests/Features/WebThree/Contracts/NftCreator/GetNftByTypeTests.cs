namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
  using System;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using MediatR;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Shared.Features.WebThree;

  class GetNftByTypeTests
  {
    public GetNftByTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    // this test is not working either
    public async Task GetNftByType()
    {
      var getNftTypeRequest = new GetNftByTypeSharedRequest() { GetNftType = 2 };

      GetNftByTypeSharedResponse response = await Mediator.Send(getNftTypeRequest);

        response.NftTypeData.Name.ShouldMatch("Purchase Requeset");
        response.NftTypeData.Symbol.ShouldMatch("PRQ");
        response.NftTypeData.MintLimit.ShouldBe(1);
    }
  }
}
