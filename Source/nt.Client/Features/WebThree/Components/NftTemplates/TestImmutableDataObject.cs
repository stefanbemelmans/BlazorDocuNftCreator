using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class TestImmutableDataObject : ImmutableDataObjectBase
    {
        public string Title = "The First Minted NFT!Take 2";
        public DateTime Date = DateTime.Now;
        public string MintedFrom = "Server.Services";

    }
}
