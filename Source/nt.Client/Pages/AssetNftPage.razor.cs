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
    public uint TotalNfts { get; set; }
    public int TotalTokens { get; set; }

    public NftTemplate CurrentNftTemplate { get; set; }
    public List<uint> CurrentTokenIds { get; set; }

    protected override async Task OnInitAsync()
    {
      WebThreeState response = await Mediator.Send(new GetNftTypesClientFeaturesAction());
      TotalNfts = response.TotalNftTypes;
    }
    //  WebThreeState template = await Mediator.Send(new GetNftByTypeAction()
    //  {
    //    GetNftType = 4
    //  }
    //    );
    //  CurrentNftTemplate = template.CurrentNftTemplate;

    //  WebThreeState tokenList = await Mediator.Send(new GetAllOwnedTokensAction());

    //  CurrentTokenIds = tokenList.CurrentTokenIds;

    //}
  }
}

