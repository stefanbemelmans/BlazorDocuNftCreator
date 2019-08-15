namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftCount;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class GetNftCountTests
  {
    private IMediator Mediator { get; }

    private NftCreatorInstance NftCreator { get; set; }

    private IServiceProvider ServiceProvider { get; }

    public GetNftCountTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    public async Task ShouldGetNftcount()
    {
      // Arrange
      var getNftRequest = new GetNftCountServiceRequest();

      // Act
      GetNftCountServiceResponse response = await Mediator.Send(getNftRequest);

      //Assert
      //response.TotalNftTypes.ShouldBeGreaterThan(2);
      response.NftCount.ShouldNotBeNull();
      response.NftCount.ShouldBe((uint)2);
    }



    public async Task ShouldGetNftCountFromShared()
    {
      // Arrange
      var getNftRequest = new GetNftCountSharedRequest();

      // Act
      GetNftCountSharedResponse response = await Mediator.Send(getNftRequest);

      //Assert
      //response.TotalNftTypes.ShouldBeGreaterThan(2);
      response.NftCount.ShouldNotBeNull();
      response.NftCount.ShouldBe((uint)2);
    }
    //public async Task ShouldGetTotalNftTypesFromContractVariable()
    //{
    //  // Arrange
    //  Function getNftCountFunction = NftCreator.Instance.GetFunction("totalNFTs");

    //  // Act

    //  uint totalNfts = await getNftCountFunction.CallAsync<uint>(
    //     from: TestEthAccounts.TestEthAccountAddress,
    //    gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000),
    //    new Nethereum.Hex.HexTypes.HexBigInteger(0)
    //    );

    //  //Assert
    //  //response.TotalNftTypes.ShouldBeGreaterThan(2);
    //  totalNfts.ShouldNotBeNull();
    //  totalNfts.ShouldBe((uint)2);
    //}

    //public async Task ShouldGetTotalNftTypesFromContractVariableWithoutCallSign()
    //{
    //  // Arrange
    //  Function getNftCountFunction = NftCreator.Instance.GetFunction("totalNFTs");

    //  // Act

    //  uint totalNfts = await getNftCountFunction.CallAsync<uint>();

    //  //Assert
    //  //response.TotalNftTypes.ShouldBeGreaterThan(2);
    //  totalNfts.ShouldNotBeNull();
    //  totalNfts.ShouldBe((uint)2);
    //}
  }
}