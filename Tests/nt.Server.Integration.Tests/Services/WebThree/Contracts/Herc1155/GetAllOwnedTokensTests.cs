namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Server.Services.WebThree.Contracts.Herc1155.GetAllOwnedTokens;
  using nt.Server.Services.WebThree.Instance;
  using Nethereum.Contracts;
  using System.Collections.Generic;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Shared.Features.WebThree.Contracts.Herc1155.GetAllOwnedTokens;

  class GetAllOwnedTokensTests
  {
    public GetAllOwnedTokensTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
    }

    private IServiceProvider ServiceProvider { get; }
    public Herc1155Instance Herc1155 { get; }
    public IMediator Mediator { get; }


    public async Task ShouldGetAllOwnedTokens()
    {
      // Arrange
      // Returns an array of owned token id's

      Function aGetAllOwnedTokensFunction = Herc1155.Instance.GetFunction("getAllOwnedTokens");

      // Act
      List<int> aTokenIdList = await aGetAllOwnedTokensFunction.CallAsync<List<int>>(TestEthAccounts.TestEthAccountAddress);

      //Assert
      aTokenIdList.ShouldNotBe(null);
      aTokenIdList.Count.ShouldBe(0);


    }

    public async Task ShouldGetAllOwnedTokensWithFunctionInput()
    {
      Function<GetAllOwnedTokensFunctionInput> aGetAllOwnedTokensFunction = Herc1155.Instance.GetFunction<GetAllOwnedTokensFunctionInput>();

      var GetAllOwnedTokensFunctionIput = new GetAllOwnedTokensFunctionInput
      {
        TokenOwner = TestEthAccounts.TestEthAccountAddress
      };

      List<uint> tokenList = await aGetAllOwnedTokensFunction.CallAsync<List<uint>>(GetAllOwnedTokensFunctionIput);

      tokenList.Count.ShouldBe(0);
    }

    public async Task ShouldGetAllTokensUsingServerServices()
    {
      var request = new GetAllOwnedTokensServiceRequest()
      {
        TokenOwner = TestEthAccounts.TestEthAccountAddress
      };

      GetAllOwnedTokensServiceResponse totalTokens = await Mediator.Send(request);

      totalTokens.TokenIdList.Count.ShouldBe(0);

    }

    public async Task ShouldGetAllTokensUsingServerFeatures()
    {
      var request = new GetAllOwnedTokensSharedRequest();

      GetAllOwnedTokensSharedResponse totalTokens = await Mediator.Send(request);

      totalTokens.TokenIdList.Count.ShouldBe(0);

    }


  }
}
