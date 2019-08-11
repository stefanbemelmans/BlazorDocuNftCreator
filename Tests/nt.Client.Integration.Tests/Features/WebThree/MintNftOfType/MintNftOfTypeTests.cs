namespace nt.Client.Integration.Tests.Features.WebThree.MintNftOfType
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;
  using nt.Client.Features.WebThree.Actions.MintNft;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using global::AnySerializer;

  internal class MintNftOfTypeTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    public MintNftOfTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task ClientActionMintingTest()
    {
      // Assert 
      string MutableDataString = "Client Mutable Data String Minting Tester";

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
        Title = "PurchaseORder Test"
      };

      byte[] serializedImmutableObject = Serializer.Serialize(PurchaseOrData);

      string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      var TesterPoNft = new MintNftOfTypeClientAction()
      {
        ImmutableDataString = serializedObjectAsBase64String,
        MutableDataString = MutableDataString,
        MintNftId = 5
      };
      TesterPoNft.MutableDataString.ShouldBe("Client Mutable Data String Minting Tester");
      WebThreeState MintingResponse = await Mediator.Send(TesterPoNft);
      //{
      //  ImmutableDataString = serializedObjectAsBase64String,
      //  MutableDataString = MutableDataString,
      //  MintNftId = 5
      //});

      MintingResponse.TransactionHash.ShouldNotBe(null);

    }


  }
}
