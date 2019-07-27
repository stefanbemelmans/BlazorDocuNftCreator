namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using AnySerializer;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;

  class ViewTokenDeserializeDataTests
  {
    public ViewTokenDeserializeDataTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ShouldGetTotalNftTemplateTypes()
    { // 
      // Arrange
      var getNftRequest = new ViewTokenDataServiceRequest { ViewTokenId = 3 };

      // Act
      ViewTokenDataServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.TokenUri.ShouldNotBe(null);

    }
  }
}
