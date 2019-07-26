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
    }
    SerializerOptions options = 0;

    public void WhichStringIsLonger()
    {
      var TestObject = new BillOfLadingTemplate();

      byte[] BolSerializedByteArray = Serializer.Serialize(TestObject);

      int byteArrayLength = BolSerializedByteArray.Length;

      string byteArrayToString = BolSerializedByteArray.ToString();

      int stringLength = byteArrayToString.Length;

      // byteArray is much longer Length
      //byteArrayLength.ShouldBeSameAs(expected: stringLength);
   
      BillOfLadingTemplate restoredObject = Serializer.Deserialize<BillOfLadingTemplate>(BolSerializedByteArray, options);

      //not EXACTLY the same object, but same object.
      restoredObject.ShouldBe(expected: TestObject);

    }
  }
}