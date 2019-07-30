namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public class AssetNftPageModel : BaseComponent
  {
    public uint TotalNfts {
      get => WebThreeState.TotalNftTypes;
      set { }
    }

    //public int TotalTokens { get; set; }

    //public NftTemplate CurrentNftTemplate { get; set; }
    //public List<uint> CurrentTokenIds { get; set; }

    //public async Task GetTotalTokens()
    //{
    //  WebThreeState tokenList = await Mediator.Send(new GetAllOwnedTokensAction());
    //  CurrentTokenIds = tokenList.CurrentTokenIds;

    //}

    //protected override async Task OnAfterRenderAsync()
    //{
    //  WebThreeState tokenList = await Mediator.Send(new GetAllOwnedTokensAction());
    //  CurrentTokenIds = tokenList.CurrentTokenIds;
    //}
    protected override async Task OnInitAsync()
    {
      // Getting All Nft Types
     WebThreeState w3s = await Mediator.Send(new GetNftTypesClientFeaturesAction());

      TotalNfts = w3s.TotalNftTypes;
      //CurrentTokenIds = tokenList.CurrentTokenIds;

      //await Mediator.Send(new GetNftByTypeAction()
      //{
      //  GetNftType = nftType.TotalNftTypes // this number will come from the user NftId
      //}
      //  );

      //await Mediator.Send(new GetAllOwnedTokensAction());
      //CurrentNftTemplate = template.CurrentNftTemplate;

      //TotalNfts = response.TotalNftTypes;
    }

  }
}

