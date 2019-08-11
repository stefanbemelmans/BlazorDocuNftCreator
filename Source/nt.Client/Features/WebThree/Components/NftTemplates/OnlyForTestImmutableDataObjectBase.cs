namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System;
  using System.Collections.Generic;
  using TypeSupport.Extensions;

  public class ImmutableDataObjectBase
    {
        
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

      public static implicit operator ImmutableData(ImmutableObjectBase v)
      {
        throw new NotImplementedException();
      }
    }
    }
}