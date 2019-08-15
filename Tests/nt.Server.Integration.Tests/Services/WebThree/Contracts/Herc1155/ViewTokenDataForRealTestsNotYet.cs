namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class GetTokenNftTypeTests
  {

    private NftCreatorInstance NFtCreator { get; set; }

    private IServiceProvider ServiceProvider { get; }

    public GetTokenNftTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    public async Task GetTokenType()
    { //
      // Arrange

      Function tokenTypeFunction = NFtCreator.Instance.GetFunction("tokenType");

      // Act
      uint tokenType = await tokenTypeFunction.CallAsync<uint>(2);
      //tokenType.ShouldBe((uint)4);
      tokenType.ShouldBe((uint)1);
    }

   
  }
}