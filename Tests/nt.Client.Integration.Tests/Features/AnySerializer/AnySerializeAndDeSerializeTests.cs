//namespace nt.Client.Integration.Tests.Features.AnySerializer
//{
//    using System;
//    using nt.Client.Integration.Tests.Infrastructure;
//    using Shouldly;
//    using global::AnySerializer;
//    using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;

//    class NotUsingAnyMoreAnySerializeAndDeSerializeTestsOld
//  {
//    private IServiceProvider ServiceProvider { get; }

    //public AnySerializeAndDeSerializeTests(TestFixture aTestFixture)
    //{
    //  ServiceProvider = aTestFixture.ServiceProvider;
    
    //}

    //SerializerOptions options = 0;

    //BillOfLadingTemplate TestObject = new BillOfLadingTemplate();

    //PurchaseOrderTemplate objectWithData = new PurchaseOrderTemplate()
    //{
    //  Department = "TestingDept",
    //  Notes = "Serialization Test With Data, This is some data.",
    //  Requester = "The Man",
    //};

    //ItemTemplate itemInfo = new ItemTemplate()
    //{
    //  Code = "Fancy Code Tester",
    //  Discount = "Fancy Tester Discount",
    //  Name = "Fancy Product Name Test",
    //  Price = "Fancy Price Tester",
    //  Qty = 24,
    //  Total = 100
    //};


    //public void FullSerializeDeSerializeNoData()
    //{
    //byte[] BolSerializedByteArray = Serializer.Serialize(new BillOfLadingTemplate());

    //  string byteArraytoBase64String = Convert.ToBase64String(BolSerializedByteArray);

    //  byte[] serializedObjectBase64StringBackToByteArray = Convert.FromBase64String(byteArraytoBase64String);

    //  BillOfLadingTemplate restoredFromBase64String = Serializer.Deserialize<BillOfLadingTemplate>(serializedObjectBase64StringBackToByteArray, options);

    //  restoredFromBase64String.ShouldBeOfType<BillOfLadingTemplate>();

    //}

    //public void FullSerializeDeSerializeWithData()
    //{

    //  byte[]  PoSerializedWithData = Serializer.Serialize<ItemTemplate>(itemInfo);

    //  string BolSerializedByteArrayWithDatatoBase64String = Convert.ToBase64String(PoSerializedWithData);

    //  byte[] BolSerializedByteArrayWithDatatoBase64StringBackToByteArray = Convert.FromBase64String(BolSerializedByteArrayWithDatatoBase64String);

    //  ItemTemplate deSerializedObjectWithData = Serializer.Deserialize<ItemTemplate>(BolSerializedByteArrayWithDatatoBase64StringBackToByteArray, options);

    //  deSerializedObjectWithData.Discount.ShouldBe(itemInfo.Discount);

    //  deSerializedObjectWithData.Code.ShouldBe(itemInfo.Code);

    //}
//  }
//}