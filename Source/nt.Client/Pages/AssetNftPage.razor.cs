namespace nt.Client.Pages
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Features.WebThree.Actions.ChangeCurrentToken;
  using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public class AssetNftPageModel : BaseComponent
  {
   
    //public TokenBase CurrentTokenData => WebThreeState.CurrentTokenData;

    public List<uint> OwnedTokenIdList
    {
      get => WebThreeState.OwnedTokenIdList;
      set { }
    }

    public TokenBase CurrentTokenData
    {
      get => WebThreeState.CurrentTokenData;
      set { }
    }

    protected override async Task OnInitAsync()
    {
      // Getting All Nft Types
      await Mediator.Send(new GetNftTypesClientFeaturesAction());

      //TotalNfts = w3s.TotalNftTypes;

      await Mediator.Send(new GetAllOwnedTokensAction());
    }
  }
}