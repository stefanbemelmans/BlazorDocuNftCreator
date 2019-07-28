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
  using System.Collections.Generic;

  class GetAllTokensOfTypeTests
  {
    public GetAllTokensOfTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NethWeb3 NethWeb3 { get; set; }
   public NftCreatorInstance NftCreator { get; set; }


    public async Task ShouldGetTotalTokensOfType()
    {
      // Arrange
      //GetNftTypesServiceResponse response = await Mediator.Send(new GetNftTypesServiceRequest());
      //4
      Function aGetAllTokensOfTypeFunction = NftCreator.Instance.GetFunction("getAllTokensofType");

      //Function<GetAllTokensOfTypeFunctionInput> aGetAllTokensOfTypeFunction = NftCreator.Instance.GetFunction<GetAllTokensOfTypeFunctionInput>();
      // Act
      //var getAllTokenofTypeFunctionMessage = new GetAllTokensOfTypeFunctionInput { GetAllTokensOfType = 4 };
      //uint getAlTokenofTypeFunctionMessage = 4;
      // The Solidity uses "uints" 

      //var aGetAllTokensOfTypeFunctionMessage = new GetAllTokensOfTypeFunctionInput { GetAllTokensOfType = aTokenId };
      List<int> aTokenList = await aGetAllTokensOfTypeFunction.CallAsync<List<int>>(4);
     
      //GetAllTokensOfTypeOutputDto aTokenList = await aGetAllTokensOfTypeFunction.CallDeserializingToObjectAsync<GetAllTokensOfTypeOutputDto>(getAllTokenofTypeFunctionMessage);


      //Assert
      aTokenList.ShouldNotBe(null);
     

    }
  }
}
