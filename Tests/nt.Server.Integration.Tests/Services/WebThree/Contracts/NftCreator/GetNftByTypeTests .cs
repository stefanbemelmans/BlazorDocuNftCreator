namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  class GetNftByTypeTests
  {
    public GetNftByTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ShouldGetNftByType()
    { 
      // Arrange
      var getNftRequest = new GetNftByTypeServiceRequest { GetNftId = 1 };

      // Act
      GetNftByTypeServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.Name.ShouldBe("Purchase Order");
      response.Symbol.ShouldBe("POR");
      response.AttachedTokens.ShouldBe(0);
      response.MintLimit.ShouldBe(1);
    }

    public async Task ShouldGetNftByTypeFromServerFeatures()
    {
      // Arrange
      var getNftRequest = new GetNftByTypeSharedRequest { GetNftId = 2 };

      // Act
      GetNftByTypeSharedResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.NftTypeDto.Name.ShouldBe("Purchase Requeset");
      response.NftTypeDto.Symbol.ShouldBe("PRQ");
      response.NftTypeDto.AttachedTokens.ShouldBe(0);
      response.NftTypeDto.MintLimit.ShouldBe(1);
    }
  }
}
