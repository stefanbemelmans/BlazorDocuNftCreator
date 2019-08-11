namespace nt.Client.Integration.Tests.Features.AnySerializer
{
  using System;
  using nt.Client.Integration.Tests.Infrastructure;
  using Shouldly;
  using global::AnySerializer;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Features.WebThree.Components.NftTemplates;

  class NewSerializeAndDeSerializeTests
  {
    private IServiceProvider ServiceProvider { get; }

    public NewSerializeAndDeSerializeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;

    }

    SerializerOptions options = 0;

    PurchaseOrderData TestObject = new PurchaseOrderData()
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
     
    };

    

    public void FullSerializeDeSerializeWithData_InPoDataType()
    {
      byte[] BolSerializedByteArray = Serializer.Serialize(TestObject);

      string byteArraytoBase64String = Convert.ToBase64String(BolSerializedByteArray);

      byte[] serializedObjectBase64StringBackToByteArray = Convert.FromBase64String(byteArraytoBase64String);

      PurchaseOrderData restoredFromBase64String = Serializer.Deserialize<PurchaseOrderData>(serializedObjectBase64StringBackToByteArray, options);

      ImmutableObjectBase immObjRestored = Serializer.Deserialize<ImmutableObjectBase>(serializedObjectBase64StringBackToByteArray, options);
      restoredFromBase64String.ShouldBeOfType<PurchaseOrderData>();

      //restoredFromBase64String.MutableDataString.ShouldBe(TestObject.MutableDataString);
      restoredFromBase64String.Item_Price.ShouldBe(TestObject.Item_Price);
      restoredFromBase64String.Approver.ShouldBe(TestObject.Approver);

      //System.Reflection.PropertyInfo[] proplist = immObjRestored.GetType().GetProperties();
      //foreach(System.Reflection.PropertyInfo prop in proplist)
      //{
      //  TestObject.GetType
      //  prop.GetValue(immObjRestored).ShouldBe(TestObject.[prop.Name]);
      //}
      
      //immObjRestored.ShouldBe(TestObject);
    }

    
  }
}