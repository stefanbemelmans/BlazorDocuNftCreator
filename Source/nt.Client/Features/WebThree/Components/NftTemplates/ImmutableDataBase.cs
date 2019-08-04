using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class ImmutableDataObjectBase
    {
        public ImmutableDataObjectBase() { }

        public uint TokenId { get; set; } 
        public uint NftId { get; set; }

    }
}
