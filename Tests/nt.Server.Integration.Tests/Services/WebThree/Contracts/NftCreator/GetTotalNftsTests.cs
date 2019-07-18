namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

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
      var getNftRequest = new GetNftTypesRequest();

      // Act
      GetNftTypesResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.TotalNfts.ShouldBe(2);
      response.TotalNfts.ShouldNotBeNull();

    }
  }
}
