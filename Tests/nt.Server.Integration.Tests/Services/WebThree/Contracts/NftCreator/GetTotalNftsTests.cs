namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;

  class GetTotalNftsTests
  {
    public GetTotalNftsTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ShouldGetTotalNftTemplateTypes()
    { 
      // Arrange
      var getNftRequest = new GetNftTypesServiceRequest();

      // Act
      GetNftTypesServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.TotalNftTypes.ShouldBe(2);
      response.TotalNftTypes.ShouldNotBeNull();

    }
  }
}
