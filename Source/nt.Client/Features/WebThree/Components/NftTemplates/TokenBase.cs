using nt.Shared.Features.WebThree;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class TokenBase

    {
        public uint TokenId { get; set; }
        public int Balance { get; set; }
        public NftTemplate TemplateData { get; set; }
        public string MutableData { get; set; }
        public string ImmutableData { get; set; }

        public ImmutableDataObjectBase DataObject { get; set; }

        
    }
}
