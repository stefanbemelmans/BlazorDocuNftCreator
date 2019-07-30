namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  internal partial class WebThreeState : State<WebThreeState>
  {
   
   
    public WebThreeState()
    {
      
    }

    public uint TotalNftTypes { get; set; }
    public uint TotalTokenTypes { get; set; } 
    public List<uint> CurrentTokenIds { get; set; }
    public uint CurrentNftType { get; set; }
    public NftTemplate CurrentNftTemplate { get; set; }
    protected override void Initialize()
    {
      TotalNftTypes = 0;
      TotalTokenTypes = 0;
      CurrentNftType = 0;
      CurrentTokenIds = new List<uint>();
      
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
