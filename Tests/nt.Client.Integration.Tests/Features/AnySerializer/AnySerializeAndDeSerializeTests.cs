namespace nt.Client.Integration.Tests.Features.AnySerializer
{
  using System;
  using nt.Client.Integration.Tests.Infrastructure;
  using System.Collections.Generic;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System.Text;
  using Shouldly;
  using global::AnySerializer;
  using static nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrderTemplate;

  class AnySerializeAndDeSerializeTests
  {
    private IServiceProvider ServiceProvider { get; }

    public AnySerializeAndDeSerializeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      //BolSerializedByteArray = Serializer.Serialize(TestObject);
      objectWithData.ItemTemplate = itemInfo;
      PoSerializedWithData = Serializer.Serialize(objectWithData);
    }

    SerializerOptions options = 0;

    //BillOfLadingTemplate TestObject = new BillOfLadingTemplate();

    PurchaseOrderTemplate objectWithData = new PurchaseOrderTemplate()
    {
      Department = "TestingDept",
      Notes = "Serialization Test With Data, This is some data.",
      Requester = "The Man",
    };

    ItemTemplate itemInfo = new ItemTemplate()
    {
      Code = "Fancy Code Tester",
      Discount = "Fancy Tester Discount",
      Name = "Fancy Product Name Test",
      Price = "Fancy Price Tester",
      Qty = 24,
      Total = 100
    };


    //public void FullSerializeDeSerializeNoData()
    //{
    byte[] PoSerializedWithData;
    //byte[] BolSerializedByteArray = Serializer.Serialize(new BillOfLadingTemplate());

    //  string byteArraytoBase64String = Convert.ToBase64String(BolSerializedByteArray);

    //  byte[] serializedObjectBase64StringBackToByteArray = Convert.FromBase64String(byteArraytoBase64String);

    //  BillOfLadingTemplate restoredFromBase64String = Serializer.Deserialize<BillOfLadingTemplate>(serializedObjectBase64StringBackToByteArray, options);

    //  restoredFromBase64String.ShouldBeOfType<BillOfLadingTemplate>();

    //}

    public void FullSerializeDeSerializeWithData()
    {



      string BolSerializedByteArrayWithDatatoBase64String = Convert.ToBase64String(PoSerializedWithData);

      byte[] BolSerializedByteArrayWithDatatoBase64StringBackToByteArray = Convert.FromBase64String(BolSerializedByteArrayWithDatatoBase64String);

      PurchaseOrderTemplate deSerializedObjectWithData = Serializer.Deserialize<PurchaseOrderTemplate>(BolSerializedByteArrayWithDatatoBase64StringBackToByteArray, options);

      deSerializedObjectWithData.Approver.ShouldBe(objectWithData.Approver);

      objectWithData.ItemTemplate.Code.ShouldBe(objectWithData.ItemTemplate.Code);

    }
  }
}