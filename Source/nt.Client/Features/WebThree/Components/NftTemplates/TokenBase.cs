namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using nt.Shared.Features.WebThree;
  using static nt.Client.Features.WebThree.Components.NftTemplates.ImmutableDataObjectBase;

  public class TokenBase

    {
        public uint TokenId { get; set; }
        public int Balance { get; set; }
        public NftTemplate TemplateData { get; set; }
        public string MutableData { get; set; }
        public string Data { get; set; }

        // Changing Object to ImmutableObjectBase that contains the Immutable DataProperty
        public ImmutableDataObjectBase DataObject { get; set; }

        public ImmutableData ImmDataObj { get; set; } 

        
    }
}
