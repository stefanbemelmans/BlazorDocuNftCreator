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
      BolSerializedByteArray = Serializer.Serialize(TestObject);
    }

    SerializerOptions options = 0;

    BillOfLadingTemplate TestObject = new BillOfLadingTemplate();

    PurchaseOrderTemplate objectWithData { get; set; }
    

    byte[] BolSerializedByteArray { get; set; }

    public void FullSerializeDeSerializeNoData()
    {

      int byteArrayLength = BolSerializedByteArray.Length;

      //string byteArrayToString = BolSerializedByteArray.ToString();

      //string byteArrayToString = Encoding.UTF8.GetString(BolSerializedByteArray);

      string byteArraytoBase64String = Convert.ToBase64String(BolSerializedByteArray);

      int byteArraytoBase64StringLength = byteArraytoBase64String.Length;

      byteArrayLength.CompareTo(byteArraytoBase64StringLength);

      //BillOfLadingTemplate restoredObject = Serializer.Deserialize<BillOfLadingTemplate>(BolSerializedByteArray, options);

      //restoredObject.ShouldBeOfType<BillOfLadingTemplate>();

      byte[] serializedObjectBase64StringBackToByteArray = Convert.FromBase64String(byteArraytoBase64String);

      //serializedObjectStringBackToByteArray.Length.CompareTo(byteArrayLength);


      //serializedObjectStringBackToByteArray.Length.ShouldBe(stringLength);

      serializedObjectBase64StringBackToByteArray.ShouldBe(BolSerializedByteArray);

      //BillOfLadingTemplate /*restoredFromString*/ = Serializer.Deserialize<BillOfLadingTemplate>(serializedObjectStringBackToByteArray, options);
      BillOfLadingTemplate restoredFromBase64String = Serializer.Deserialize<BillOfLadingTemplate>(serializedObjectBase64StringBackToByteArray, options);

      restoredFromBase64String.ShouldBeOfType<BillOfLadingTemplate>();

    }

    public void FullSerializeDeSerializeWithData()
    {

      objectWithData = new PurchaseOrderTemplate()
      {
        Approver = "ApproverTestData",
        DeliveryDate = DateTime.Now,
        Department = "TestingDept",
        Notes = "Serialization Test With Data, This is some data.",
        Requester ="The Man",
      };
      var itemInfo = new ItemTemplate()
      {
        Code = "Fancy Code Tester",
        Discount = "Fancy Tester Discount",
        Name = "Fancy Product Name Test",
        Price = "Fancy Price Tester",
        Qty = "Many!",
        Total = 100
      };

      objectWithData.ItemTemplate = itemInfo;

      byte[] serializedObjectWithData = Serializer.Serialize(objectWithData);


      PurchaseOrderTemplate deSerializedObjectWithData = Serializer.Deserialize<PurchaseOrderTemplate>(serializedObjectWithData, options);

      deSerializedObjectWithData.Approver.ShouldBe(objectWithData.Approver);

      objectWithData.ItemTemplate.Code.ShouldBe(objectWithData.ItemTemplate.Code);

    }
  }
}