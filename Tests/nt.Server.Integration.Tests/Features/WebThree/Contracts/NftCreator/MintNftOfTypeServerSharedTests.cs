namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
  using AnySerializer;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Contracts;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  // Below is nftType 4 for deserialization

  internal class MintNftOfTypeServerSharedTests
  {
    private IMediator Mediator { get; }

    private NethWeb3 NethWeb3 { get; }

    private NftCreatorInstance NftCreator { get; }

    private IServiceProvider ServiceProvider { get; }

    public MintNftOfTypeServerSharedTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
    }

    public async Task ShouldMintNftOfType()
    {
      // Arrange

      Function<MintNftOfTypeFunctionInput> aMintNftOfTypeFunction = NftCreator.Instance.GetFunction<MintNftOfTypeFunctionInput>();

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<MintNftOfTypeFunctionInput> MintNftOfTypeFunctionHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<MintNftOfTypeFunctionInput>();

      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionInput
      {
        Type = 4,
        MutableDataString = "The Third Minted NFT!Take 3",
        ImmutableDataString = "This Is MintingTest 3"
      };

      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await MintNftOfTypeFunctionHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

      aMintNftOfTypeFunctionMessage.Gas = gasEstimate.Value;

      gasEstimate.Value.ShouldBeGreaterThan(0);
    }


    //public async Task ShouldMint_SerializedNftFrom_Shared()
    //{
    //  // Arrange
    //  string MutableDataString = "Client Mutable Data String Minting Tester";

    //  var PurchaseOrData = new PurchaseOrderData()
    //  {
    //    Department = "TestingDept",
    //    Notes = "Serialization Test With Data, This is some data.",
    //    Requester = "The Man",
    //    Approver = "The Man's Man Approves",
    //    Item_Code = "Item Code Here",
    //    Item_Discount = 123,
    //    Item_Name = "Fancy Product Name Test",
    //    Item_Price = "Fancy Price Tester",
    //    Item_Qty = 42,
    //    Item_Total = 1234,
    //    Title = "Purchase Order Test"
    //  };

    //  byte[] serializedImmutableObject = Serializer.Serialize(PurchaseOrData);

    //  string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

    //  var TesterPoNft = new MintNftOfTypeSharedRequest()
    //  {
    //    ImmutableDataString = serializedObjectAsBase64String,
    //    MutableDataString = MutableDataString,
    //    MintNftId = 5
    //  };

      // Act

      //MintNftOfTypeSharedResponse mintingResponse = await Mediator.Send(TesterPoNft);

      //mintingResponse.TransactionHash.ShouldNotBe(null);

    }
  }

    //public async Task ShouldMintNftOfTypeFromClient()
    //{

    //  // Arrange

    //  var aMintNftOfTypeClientAction = new MintNftOfTypeClientAction()
    //  {
    //    MintNftId = 4,
    //    MutableDataString = "Testing Minting From Client Features! Here's some Mutable Data",
    //    ImmutableDataString = "Testing Minting From Client Features! Here's some  ImMutable Data 19-8-7"
    //  };

    //  WebThreeState ClientMintResponse = await Mediator.Send(aMintNftOfTypeClientAction);

    //  aMintNftOfTypeClientAction.ShouldNotBeNull();
    //  ClientMintResponse.MintingTransactionReceipt.ShouldNotBe(null);
    //}

  


