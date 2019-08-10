namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
    using System;
    using AnySerializer;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using System.Threading.Tasks;
    using nt.Shared.Constants.AccountAddresses;
    using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
    using Nethereum.Contracts;
    using Nethereum.RPC.Eth.DTOs;
    using nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator;

    class TokenDataDeserializationTests
  {
    public TokenDataDeserializationTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      //Mediator = ServiceProvider.GetService<IMediator>();
      //NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
    }

    public ImmutableData immutable = new ImmutableData();
    private IServiceProvider ServiceProvider { get; }
    //private IMediator Mediator { get; }
    //private NethWeb3 NethWeb3 { get; set; }
    private Herc1155Instance Herc1155 { get; set; }
    public async Task ShouldGetTokenData()
    { // 
      // Arrange 
      //var getNftRequest = new ViewTokenDataServiceRequest { ViewTokenId = 3 };"0x12833d6fADd206dEd2fcE84936d8D78326AB8EfA"
      SerializerOptions options = 0;
      Function viewTokenDataFunction = Herc1155.Instance.GetFunction("viewTokenData");

      CallInput CallInput = viewTokenDataFunction.CreateCallInput(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), value: new Nethereum.Hex.HexTypes.HexBigInteger(0), functionInput: 4);
      
      // Act
      string base64SerializedString = await viewTokenDataFunction.CallAsync<string>(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), value: new Nethereum.Hex.HexTypes.HexBigInteger(0), functionInput: 3);
      //ViewTokenDataServiceResponse response = await Mediator.Send(getNftRequest);

      byte[] serializedImmutableData = Convert.FromBase64String(base64SerializedString);

      ImmutableData deserializedObject = Serializer.Deserialize<ImmutableData>(serializedImmutableData, options);
      //Assert

      deserializedObject.ShouldNotBe(null);
      deserializedObject.MintedFrom.ShouldMatch(immutable.MintedFrom);
    }

   
  }
}
