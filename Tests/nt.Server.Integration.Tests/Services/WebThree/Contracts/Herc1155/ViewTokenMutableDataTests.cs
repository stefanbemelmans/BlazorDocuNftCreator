namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
  using AnySerializer;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Server.Services.WebThree.Contracts.Herc1155.Functions;
  using nt.Server.Services.WebThree.Instance;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class ViewTokenDataTests
  {
    private Herc1155Instance Herc1155 { get; set; }

    private IMediator Mediator { get; }

    private NethWeb3 NethWeb3 { get; set; }

    private IServiceProvider ServiceProvider { get; }

    public ViewTokenDataTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
      Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
      //NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
    }

    //private NftCreatorInstance NFtCreator { get; set; }

    public async Task ShouldDeserializeToken2()
    {
      var request = new ViewTokenDataServiceRequest { ViewTokenId = 2 };

      SerializerOptions options = 0;
      ViewTokenDataServiceResponse response = await Mediator.Send(request);
      byte[] SerializedObject = Convert.FromBase64String(response.TokenDataString);

      PurchaseOrderData deSerObj = Serializer.Deserialize<PurchaseOrderData>(SerializedObject, options);

      deSerObj.ShouldBeOfType<PurchaseOrderData>();
      deSerObj.Title.ShouldBe("Purchase Order Ropsten Test");
    }

    public async Task ShouldGetMutableData()
    { //  Arrange
      var getNftRequest = new ViewMutableDataServiceRequest { ViewTokenId = 2 };
      // Act

      ViewMutableDataServiceResponse response = await Mediator.Send(getNftRequest);
      // Assert
      response.ShouldNotBe(null);
      response.MutableDataString.ShouldBe("Server Services Mutable Data String Minting Tester");
    }
  }
}