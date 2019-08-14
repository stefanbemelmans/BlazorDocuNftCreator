namespace nt.Client.Integration.Tests.Features.WebThree.MintNftOfType
{
  using global::AnySerializer;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Contracts;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Integration.Tests.Infrastructure;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using Shouldly;
  using System;

  using System.Threading.Tasks;

  internal class MintNftOfTypeTests
  {
    private IMediator Mediator { get; }
    private NethWeb3 NethWeb3 { get; set; }
    private NftCreatorInstance NftCreator { get; }
    private IServiceProvider ServiceProvider { get; }

    public MintNftOfTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
    }

    public async Task ClientActionMintingTest()
    {
      // A
      string mutableDataString = "Client Mutable Data String Minting Tester";

      var purchaseOrData = new PurchaseOrderData()
      {
        Department = "TestingDept",
        Notes = "Serialization Test With Data, This is some data.",
        Requester = "The Man",
        Approver = "The Man's Man Approves",
        Item_Code = "Item Code Here",
        Item_Discount = 123,
        Item_Name = "Fancy Product Name Test",
        Item_Price = "Fancy Price Tester",
        Item_Qty = 42,
        Item_Total = 1234,
        Title = "Purchase Order Ropsten Test"
      };

      byte[] serializedImmutableObject = Serializer.Serialize(purchaseOrData);

      string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionInput
      {
        ImmutableDataString = serializedObjectAsBase64String,
        MutableDataString = mutableDataString,
        NftId = 1
      };

      Function<MintNftOfTypeFunctionInput> aMintNftOfTypeFunction = NftCreator.Instance.GetFunction<MintNftOfTypeFunctionInput>();

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<MintNftOfTypeFunctionInput> mintingHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<MintNftOfTypeFunctionInput>();
      // serialization needed

      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await mintingHandler.EstimateGasAsync(NftCreatorAddresses.NewNftCreatorRopstenAddress, aMintNftOfTypeFunctionMessage);

      aMintNftOfTypeFunctionMessage.Gas = gasEstimate.Value;

      Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await mintingHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NewNftCreatorRopstenAddress, aMintNftOfTypeFunctionMessage);

      System.Collections.Generic.List<EventLog<MintNftOutputEventDto>> MintNftOutput = mintingTransactionReceipt.DecodeAllEvents<MintNftOutputEventDto>();

      mintingTransactionReceipt.ShouldNotBeNull();

      MintNftOutput.ShouldNotBeNull();
    }
  }
}