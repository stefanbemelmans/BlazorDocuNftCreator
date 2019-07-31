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

    public TemplateFormBase TokenData => new TesterNftTemplate();

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

