namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
    using Shouldly;
    using System;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
    using nt.Server.Services.WebThree.Instance;
    using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
    using nt.Shared.Features.WebThree.Contracts.Herc1155;

    class ViewTokenDataServerFeaturesTests
    {
        public ViewTokenDataServerFeaturesTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;
            Mediator = ServiceProvider.GetService<IMediator>();
            NethWeb3 = ServiceProvider.GetService<NethWeb3>();
            Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
            NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
        }

        private IServiceProvider ServiceProvider { get; }
        private IMediator Mediator { get; }
        private NethWeb3 NethWeb3 { get; set; }
        private Herc1155Instance Herc1155 { get; set; }
        private NftCreatorInstance NFtCreator { get; set; }

        public async Task ShouldGetTokenDataStringFromServerFeatures()
        { // 
          // Arrange
            ViewTokenDataSharedRequest TokenDataRequest = new ViewTokenDataSharedRequest() { TokenIdToGet = 5 };
          // Act

            var TokenDataResponse = await Mediator.Send(TokenDataRequest);
            TokenDataResponse.TokenDataString.ShouldBeOfType<string>();
        }


        //public async Task TestingTokenTypeFunctionShouldGetTypeWithCallInput()
        //{ // 
        //  // Arrange
        //    Function viewTokenDataFunction = Herc1155.Instance.GetFunction("viewTokenData");

        //    Function tokenTypeFunction = NFtCreator.Instance.GetFunction("tokenType");
        //    CallInput CallInput = tokenTypeFunction.CreateCallInput(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), new Nethereum.Hex.HexTypes.HexBigInteger(0), functionInput: 5);

        //    // Act
        //    uint tokenType = await tokenTypeFunction.CallAsync<uint>(CallInput);
        //    //tokenType.ShouldBe((uint)4);
        //    tokenType.ShouldBe((uint)4);
        //}

        //public async Task ShouldGetTokenBalance()
        //{
        //  Function viewBalanceFunction = Herc1155.Instance.GetFunction("balanceOf");

        //  CallInput CallInput = viewBalanceFunction.CreateCallInput(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), new Nethereum.Hex.HexTypes.HexBigInteger(0));

        //  int response = await viewBalanceFunction.CallAsync<int>(TestEthAccounts.TestEthAccountAddress, 5);
        //  int balance = response;
        //  balance.ShouldNotBe(0);
        //}

        //public async Task ShouldGetByteArrayAndTokenId()
        //{
        //  var request = new ViewTokenDataServiceRequest { ViewTokenId = 3 };

        //  ViewTokenDataServiceResponse response = await Mediator.Send(request);

        //  response.TokenType.ShouldBe((uint)4);
        //  ImmutableData deSerObj = Serializer.Deserialize<ImmutableData>(response.SerializedTokenData, 0);

        //  deSerObj.ShouldBeOfType<ImmutableData>();
        //  deSerObj.Title.ShouldBe("The First Minted NFT!Take 2");

        //}

    }
}
