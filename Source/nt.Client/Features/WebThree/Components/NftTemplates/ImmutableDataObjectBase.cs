using System;
using System.Collections.Generic;
using TypeSupport.Extensions;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class ImmutableDataObjectBase
    {
        public DateTime Date = DateTime.Now;

        //public uint NftId { get; set; }
        //public List<System.Reflection.PropertyInfo> PropList { get; set; }

        //public string Title { get; set; }
       public ICollection<TypeSupport.ExtendedProperty> PropList { get; set; }
        public ImmutableDataObjectBase()
        {
            PropList = this.GetProperties(0);
        }
        
        // test object
        public class ImmutableData
        {
            public DateTime Date { get; set; } = DateTime.Now;
            public string MintedFrom { get; set; } = "Yo Mama";
            public string Title { get; set; } = "Tester ImmutableDataObject";
        }
    }
}