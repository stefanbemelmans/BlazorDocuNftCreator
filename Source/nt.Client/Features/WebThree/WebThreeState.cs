namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public WebThreeState(){}

    public uint TotalNftTypes { get; set; }
    public uint TotalTokenTypes { get; set; } 
    public List<uint> OwnedTokenIdList { get; set; }

    // "int" type becuase it's an index position.
    public int CurrentNftTypeIndex { get; set; } = 1;
    public uint CurrentTokenId { get; set; }
    public uint CurrentTokenNftType { get; set; } // CurrentTokenNftType will be used on the AssetNftPage
    public NftTemplate CurrentNftTemplate { get; set; }// CurrentNftType will be used on the MintNftPage
    //public List<KeyValuePair<uint, NftTemplate>> NftIdxTypeKvpList { get; set; }
    public List<NftTemplate> TemplateDataList { get; set; }
    public List<TemplateBase> ListOfTokenInfo { get; set; }
    protected override void Initialize()
    {
      TotalNftTypes = 0;
      TotalTokenTypes = 0;
      OwnedTokenIdList = new List<uint>();
      //NftIdxTypeKvpList = new List<KeyValuePair<uint, NftTemplate>>();
      TemplateDataList = new List<NftTemplate>();
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
