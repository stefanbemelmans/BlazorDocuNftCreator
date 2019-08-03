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
        public uint Balance { get; set; }
        public NftTemplate TemplateData { get; set; }

    }
}
