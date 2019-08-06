namespace nt.Client.Integration.Tests.Features.ImmutableObjectTests
{
    using System;
    using nt.Client.Integration.Tests.Infrastructure;
    using System.Collections.Generic;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using System.Text;
    using Shouldly;
    using global::AnySerializer;
    using static nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrderTemplate;

    class BuildImmutableObjectTests
    {
        private IServiceProvider ServiceProvider { get; }

        public BuildImmutableObjectTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;

        }

        readonly List<object> ListOfProperties = new List<object>();
        PurchaseOrderTemplate PurchaseOrder = new PurchaseOrderTemplate();

        // I investigated the ListOfProperties in the debugger and it is 
        public void ShouldIterateOverProps()
        {
            foreach (var property in PurchaseOrder.PoPropList)
            {
                ListOfProperties.Add(property);
            }
            ListOfProperties.Count.ShouldBeGreaterThan(3);
        }


      
        };


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

        //    byte[] PoSerializedWithData = Serializer.Serialize<ItemTemplate>(itemInfo);

        //    string BolSerializedByteArrayWithDatatoBase64String = Convert.ToBase64String(PoSerializedWithData);

        //    byte[] BolSerializedByteArrayWithDatatoBase64StringBackToByteArray = Convert.FromBase64String(BolSerializedByteArrayWithDatatoBase64String);

        //    ItemTemplate deSerializedObjectWithData = Serializer.Deserialize<ItemTemplate>(BolSerializedByteArrayWithDatatoBase64StringBackToByteArray, options);

        //    deSerializedObjectWithData.Discount.ShouldBe(itemInfo.Discount);

        //    deSerializedObjectWithData.Code.ShouldBe(itemInfo.Code);

        //}
    }
