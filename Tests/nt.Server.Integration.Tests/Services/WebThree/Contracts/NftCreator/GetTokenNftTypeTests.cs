namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNftType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTokenNftType;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using Nethereum.Contracts;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetTokenNFtType;
  using nt.Shared.Constants.AccountAddresses;

  class GetTokenNftTypeTests
  {
    public GetTokenNftTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NftCreatorInstance NftCreator { get; }

    public async Task ShouldGetTokenNftType()
    {
      // Arrange


      Function<GetTokenNftTypeFunctionInput> getTokenNftTypeFunction = NftCreator.Instance.GetFunction<GetTokenNftTypeFunctionInput>();

      var getTokenNftTypeInput = new GetTokenNftTypeFunctionInput()
      {
        FromAddress = TestEthAccounts.TestEthAccountAddress,
        TokenId = 2
      };

      // Act

      GetTokenNftTypeFunctionOutput nftType = await getTokenNftTypeFunction.CallDeserializingToObjectAsync<GetTokenNftTypeFunctionOutput>(getTokenNftTypeInput);
     
      //Assert
      //response.TokensNftType.ShouldBe((uint)1);
      nftType.ShouldNotBeNull();
      nftType.NftId.ShouldBe((uint)1);

    }

    //public async Task ShouldGetTokenNftTypeWithFunctionInput()
    //{
    //  // Arrange


    //  Function<GetTokenNftTypeFunctionInput> GetTokenNftTypeFunction = NftCreator.Instance.GetFunction<GetTokenNftTypeFunctionInput>();
    //  var tokenId = new GetTokenNftTypeFunctionInput()
    //  {
    //    TokenId = 1
    //  };
    //  // Act

    //  GetTokenNftTypeFunctionOutput nftTypeContainer = await GetTokenNftTypeFunction.CallDeserializingToObjectAsync<GetTokenNftTypeFunctionOutput>(tokenId);
    //  //Assert
    //  //response.TokensNftType.ShouldBe((uint)1);
    //  nftTypeContainer.NftId.ShouldBe((uint)1);

    //}

  }
}

