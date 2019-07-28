namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
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

  class ViewTokenDeserializeDataTests
  {
    public ViewTokenDeserializeDataTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NethWeb3 NethWeb3 { get; set; }
    private Herc1155Instance Herc1155 { get; set; }
    public TestEthAccounts testEthAccounts { get; set; }
    public async Task ShouldGetTokenData()
    { // 
      // Arrange
      //var getNftRequest = new ViewTokenDataServiceRequest { ViewTokenId = 3 };
      var blockParameter = new BlockParameter();
      Function viewTokenDataFunction = Herc1155.Instance.GetFunction("viewTokenData");
      // Act
      string response = await viewTokenDataFunction.CallAsync<string>(from: "0x12833d6fADd206dEd2fcE84936d8D78326AB8EfA", gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), new Nethereum.Hex.HexTypes.HexBigInteger(0),5);
      //ViewTokenDataServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.ShouldNotBe(null);
      response.ShouldMatch("This Is MintingTest 2");

    }
  }
}
