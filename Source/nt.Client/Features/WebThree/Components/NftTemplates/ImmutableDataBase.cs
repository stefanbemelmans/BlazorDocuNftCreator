using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeSupport.Extensions;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class ImmutableDataObjectBase
    {
        public ImmutableDataObjectBase()
        {
            List<object> propList = new List<object>(this.GetProperties(0));

        }

        //private List<KeyValuePair<string, object>> TempList { get; set; }
        //public List<KeyValuePair<string, object>> TokenProps { get; set; }
        public uint TokenId { get; set; }
        public uint NftId { get; set; }
        
    public class ImmutableData
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
            public string MintedFrom { get; set; }
        }
        
    }
}
