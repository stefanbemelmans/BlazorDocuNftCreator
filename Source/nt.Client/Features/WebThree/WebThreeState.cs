namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  internal partial class WebThreeState : State<WebThreeState>
  {
   
   
    public WebThreeState()
    {
      
    }

    public uint TotalNftTypes { get; set; }
    public uint TotalTokenTypes { get; set; } 
    public List<uint> OwnedTokenIdList { get; set; }
    public uint CurrentNftType { get; set; }
    public uint CurrentTokenId { get; set; }
    public uint CurrentTokenNftType { get; set; }
    public NftTemplate CurrentNftTemplate { get; set; }
    public List<NftTemplate> NftTypeList { get; set; }
    
    public List<TemplateBase> ListOfTokenInfo { get; set; }
    protected override void Initialize()
    {
      TotalNftTypes = 0;
      TotalTokenTypes = 0;
      CurrentNftType = 0;
      OwnedTokenIdList = new List<uint>();
      CurrentTokenId = 0;
      
      CurrentNftTemplate = new NftTemplate()
      {
        Name = "fillerName",
        Symbol = "stubSymbol",
        MintLimit = 42,
        AttachedTokens = 0
      };

    }
    

  }
}
