namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTokenNftType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;

  class GetTokenNftTypeTests
  {
    public GetTokenNftTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ClientShouldGetTokenNftType()
    {
      // Arrange
      var getNftRequest = new GetTokenNftTypeServiceRequest { TokenId = 3 };

      // Act
      GetTokenNftTypeServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.TokensNftType.ShouldBe((uint)4);

    }
    public async Task SharedShouldGetTokenNftType()
    {
      // Arrange
      var getNftSharedRequest = new GetTokenNftTypeSharedRequest { TokenId = 3 };

      // Act
      GetTokenNftTypeSharedResponse response = await Mediator.Send(getNftSharedRequest);

      //Assert
      response.NftType.ShouldBe((uint)4);

    }
  }
}
