using nt.Shared.Features.WebThree;
using static nt.Client.Features.WebThree.Components.NftTemplates.ImmutableDataObjectBase;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class TokenBase

    {
        public uint TokenId { get; set; }
        public int Balance { get; set; }
        public NftTemplate TemplateData { get; set; }
        public string MutableData { get; set; }
        public string Data { get; set; }

        public ImmutableDataObjectBase DataObject { get; set; }

        public ImmutableData ImmDataObj { get; set; } 

        
    }
}
