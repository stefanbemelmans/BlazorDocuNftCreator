namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTotalNftTypes;
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
      var GetNftRequest = new GetTotalNftTypesRequest();

      // Act
      GetTotalNftTypesResponse response = await Mediator.Send(GetNftRequest);

      //Assert
      response.TotalNftTemplateTypes.ShouldNotBeNull();
      response.TotalNftTemplateTypes.ShouldBe(2);

    }
  }
}
