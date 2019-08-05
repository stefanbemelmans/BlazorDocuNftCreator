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
  using static nt.Client.Features.WebThree.Components.NftTemplates.TemplateBase;

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

    public uint TotalTokens
        {
            get => WebThreeState.TotalTokenTypes;
            set { }
        }


    protected override async Task OnInitAsync()
    {
      // Getting All Nft Types
      WebThreeState w3s = await Mediator.Send(new GetNftTypesClientFeaturesAction());

       TotalNfts = w3s.TotalNftTypes;


            // The below now gets taken care of in the above Handler and produces the 
            //_ = await Mediator.Send(new GetNftByTypeAction()
            // {
            //   GetNftType = TotalNfts // this number will come from the user NftId
            // }
            //    );

            WebThreeState tokenList = await Mediator.Send(new GetAllOwnedTokensAction());


            //CurrentTokenIds = tokenList.OwnedTokenIdList;
            //TotalTokens = CurrentTokenIds.Count;

        }
  }
}

