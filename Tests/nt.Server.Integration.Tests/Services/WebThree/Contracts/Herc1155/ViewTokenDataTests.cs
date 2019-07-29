namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
  using System;
  using MediatR;
  using AnySerializer;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
  using System.Threading.Tasks;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using Nethereum.Contracts;
  using Nethereum.RPC.Eth.DTOs;
  using nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;

  class ViewTokenDataTests
  {
    public ViewTokenDataTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
      //NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NethWeb3 NethWeb3 { get; set; }
    private Herc1155Instance Herc1155 { get; set; }
    //private NftCreatorInstance NFtCreator { get; set; }

    public async Task ShouldGetTokenData()
    { // 
      // Arrange
      //var getNftRequest = new ViewTokenDataServiceRequest { ViewTokenId = 3 };"0x12833d6fADd206dEd2fcE84936d8D78326AB8EfA"
      Function viewTokenDataFunction = Herc1155.Instance.GetFunction("viewTokenData");
      // Act
      string response = await viewTokenDataFunction.CallAsync<string>(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), new Nethereum.Hex.HexTypes.HexBigInteger(0), 5);
      //ViewTokenDataServiceResponse response = await Mediator.Send(getNftRequest);
      //Assert
      response.ShouldNotBe(null);
      response.ShouldMatch("This Is MintingTest 3");
    }

    public async Task ShouldGetTokenBalance()
    {
      Function viewBalanceFunction = Herc1155.Instance.GetFunction("balanceOf");

      CallInput CallInput = viewBalanceFunction.CreateCallInput(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), new Nethereum.Hex.HexTypes.HexBigInteger(0));

      int response = await viewBalanceFunction.CallAsync<int>(TestEthAccounts.TestEthAccountAddress, 5);
      int balance = response;
      balance.ShouldNotBe(0);
    }

    public async Task ShouldDeserializeTokenData()
    {
      var request = new ViewTokenDataServiceRequest { ViewTokenId = 3 };

      ViewTokenDataServiceResponse response = await Mediator.Send(request);

      response.TokenType.ShouldBe((uint)4);
      ImmutableData deSerObj = Serializer.Deserialize<ImmutableData>(response.SerializedTokenData, 0);

      deSerObj.ShouldBeOfType<ImmutableData>();
      deSerObj.Title.ShouldBe("The First Minted NFT!");

    }

  }
}
