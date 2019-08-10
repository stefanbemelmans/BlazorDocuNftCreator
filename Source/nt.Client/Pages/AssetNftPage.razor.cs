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

        //public uint TotalNfts
        //{
        //    get => WebThreeState.TotalNftTypes;
        //    set { }
        //}

        public TokenBase CurrentTokenData
        {
            get => WebThreeState.CurrentTokenData;
        }

        public uint TotalTokens
        {
            get => WebThreeState.TotalTokenTypes;
            set { }
        }

        public void SetNewToken(UIChangeEventArgs eventArgs)
        {
            string TokenId = eventArgs.Value.ToString();

            Mediator.Send(new ChangeCurrentTokenAction() { TokenId = int.Parse(TokenId) });
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