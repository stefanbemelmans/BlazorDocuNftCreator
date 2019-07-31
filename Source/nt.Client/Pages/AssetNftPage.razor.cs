namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.WebThree.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using static nt.Client.Features.WebThree.Components.NftTemplates.TemplateFormBase;

  public class AssetNftPageModel : BaseComponent
  {
    public uint TotalNfts
    {
      get => WebThreeState.TotalNftTypes;
      set { }
    }

    public NftTemplate CurrentNft
    {
      get => WebThreeState.CurrentNftTemplate;
      set { }
    }

    public List<uint> CurrentTokenIds
    {
      get => WebThreeState.OwnedTokenIdList;
      set { }
    }

    public int TotalTokens { get; set; }

   public TemplateFormBase tokenData = new TemplateFormBase()
    {
      NftId = 5,
      Name = "TestTemplate",
      Symbol = "TTFL",
      MintLimit = 300,
      AttachedTokens = 0,
      NftProps = new Dictionary<string, string>()
      {
        { "FieldOneKey", "FieldOneVal" },
        { "ImportantNumber1fo2", "42" },
        { "ImportantWord1of2", "The Word1" },
        { "ImportantNumber2of2", "17" },
        { "ImportantWord2of2", "The Word2" },
        { "Date", new System.DateTime().ToString() }

      }
    };

    protected override async Task OnInitAsync()
    {
      // Getting All Nft Types
      WebThreeState w3s = await Mediator.Send(new GetNftTypesClientFeaturesAction());

      TotalNfts = w3s.TotalNftTypes;

      WebThreeState NftTypeResponse = await Mediator.Send(new GetNftByTypeAction()
      {
        GetNftType = TotalNfts // this number will come from the user NftId
      }
         );
      CurrentNft = NftTypeResponse.CurrentNftTemplate;

      WebThreeState tokenList = await Mediator.Send(new GetAllOwnedTokensAction());
      CurrentTokenIds = tokenList.OwnedTokenIdList;
      TotalTokens = CurrentTokenIds.Count;
     
    }
  }
}

