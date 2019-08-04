namespace nt.Client.Features.WebThree.Components
{
    using nt.Shared.Features.WebThree;
    using nt.Client.Features.Base.Components;
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using System.Collections.Generic;
    using nt.Client.Features.WebThree.Actions.ChangeCurrentToken;

    public class TokenInfoModel : BaseComponent
    {
        public TokenBase CurrentToken
        {
            get => WebThreeState.CurrentTokenData;
            set { }
        }
        public List<TokenBase> TokenDataList => WebThreeState.TokenDataList;

        public void SetNewToken(UIChangeEventArgs eventArgs)
        {
            string TokenId = eventArgs.Value.ToString();
            
            Mediator.Send(new ChangeCurrentTokenAction() { TokenId = int.Parse(TokenId) });
        }
    }

}