using nt.Shared.Features.WebThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class TokenBase
    {
        public uint TokenId { get; set; }
        public int Balance { get; set; }
        public NftTemplate TemplateData { get; set; }
        public string MutableData { get; set; }
        public string ImmutableData { get; set; }

        public object DataObject { get; set; }

    }
}
