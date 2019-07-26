namespace nt.Client.Integration.Tests.Features.AnySerializer
{
  using System;
  using nt.Client.Integration.Tests.Infrastructure;
  using System.Collections.Generic;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System.Text;
  using Shouldly;
  using global::AnySerializer;

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
  }
}