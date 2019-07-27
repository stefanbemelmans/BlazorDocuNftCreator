namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType;
  using System.Threading.Tasks;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;

  class GetAllTokensOfTypeTests
  {
    public GetAllTokensOfTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NethWeb3 NethWeb3 { get; }
   public NftCreatorInstance NftCreator { get; }


    public async Task ShouldGetTotalTokensOfType()
    {
      // Arrange
      GetNftTypesServiceResponse response = await Mediator.Send(new GetNftTypesServiceRequest());


      Function<GetAllTokensOfTypeFunctionInput> aGetAllTokensOfTypeFunction = NftCreator.Instance.GetFunction<GetAllTokensOfTypeFunctionInput>();
      // Act
      var getAllTokenofTypeRequest = new GetAllTokensOfTypeServiceRequest { GetAllTokensOfType = response.TotalNftTypes };

      // The Solidity uses "uints" 

      //var aGetAllTokensOfTypeFunctionMessage = new GetAllTokensOfTypeFunctionInput { GetAllTokensOfType = aTokenId };

      GetAllTokensOfTypeOutputDto aTokenList = await aGetAllTokensOfTypeFunction.CallDeserializingToObjectAsync<GetAllTokensOfTypeOutputDto>(
      new GetAllTokensOfTypeFunctionInput
      {
        GetAllTokensOfType = getAllTokenofTypeRequest.GetAllTokensOfType
      }
      );

      //Assert
      aTokenList.TokenList.ShouldNotBe(null);
     

    }
  }
}
