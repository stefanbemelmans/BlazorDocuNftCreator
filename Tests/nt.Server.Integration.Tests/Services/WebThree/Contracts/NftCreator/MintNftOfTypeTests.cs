namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using Nethereum.Contracts;
  using AnySerializer;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;

  // Below is nftType 4 for deserialization
  class ImmutableData
  {
    public string Title = "The First Minted NFT!Take 2";
    public DateTime Date = DateTime.Now;
    public string MintedFrom = "Server.Services";
  }

  class MutableData
  {
    public string Mutable = "Data for versioning perhaps x2";
  }
  class MintNftOfTypeTests
  {
    public MintNftOfTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NftCreatorInstance NftCreator { get; }
    private NethWeb3 NethWeb3 { get; }

    public void ShouldMintNftOfType()
    {
      // Arrange

      string MutableDataString = "Server Services Mutable Data String Minting Tester";

      var PurchaseOrData = new PurchaseOrderData()
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

      byte[] serializedImmutableObject = Serializer.Serialize(PurchaseOrData);

      string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      var TesterPoNft = new MintNftOfTypeServiceRequest()
      {
        ImmutableDataString = serializedObjectAsBase64String,
        MutableDataString = MutableDataString,
        MintNftId = 1
      };
      TesterPoNft.MutableDataString.ShouldBe("Server Services Mutable Data String Minting Tester");
      //MintNftOfTypeServiceResponse MintingResponse = await Mediator.Send(TesterPoNft);

      //MintingResponse.TransactionHash.ShouldNotBeNull();

    }
  }
}
