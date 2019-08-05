namespace nt.Client.Features.WebThree.Components
{
    using nt.Shared.Features.WebThree;
    using nt.Client.Features.Base.Components;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using System.Collections.Generic;
    using nt.Client.Features.WebThree.Actions.ChangeCurrentToken;
    using System.Threading.Tasks;
    using nt.Client.Features.WebThree.Actions.GetAllOwnedTokens;

    public class TokenInfoModel : BaseComponent
    {
        public TokenBase CurrentTokenData
        {
            get => WebThreeState.CurrentTokenData;
            set { }
        }
        public List<TokenBase> TokenDataList
        {
            get => WebThreeState.TokenDataList;
            set { }
        }

        public List<uint> OwnedTokenIdList => WebThreeState.OwnedTokenIdList;
        
        public NftTemplate CurrentTokenNftType { get; set; }

        public void SetNewToken(UIChangeEventArgs eventArgs)
        {
            string TokenId = eventArgs.Value.ToString();

            Mediator.Send(new ChangeCurrentTokenAction() { TokenId = int.Parse(TokenId) });
        }

        //protected override async Task OnInitAsync()
        //{
        //    var TokenData = await Mediator.Send(new GetAllOwnedTokensAction());
        //    CurrentTokenData = TokenDataList[0];
        //    CurrentTokenId = TokenDataList[0].TokenId;
        //    CurrentTokenNftType = TokenDataList[0].TemplateData;
        //    //WebThreeState.CurrentTokenNftType = TokenDataList[0].TemplateData.NftId;
        //}
    }

}