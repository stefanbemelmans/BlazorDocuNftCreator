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

    public async Task ShouldGetTotalNftTemplateTypes()
    { 
      // Arrange
      var getNftRequest = new GetNftByTypeServiceRequest { GetNftId = 1 };

      // Act
      GetNftByTypeServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.NftTypeData.ShouldBeOfType<NftTemplate>();
      response.NftTypeData.Name.ShouldBeOfType<string>();

    }
  }
}
