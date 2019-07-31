namespace nt.Client.Features.WebThree.Components
{
    using System.Collections;
    using System.Collections.Generic;
    using nt.Shared.Features.WebThree;
    using nt.Shared.Features.Base;
    using nt.Client.Features.WebThree.Components.NftData;

    public class TokenInfoModel : BaseComponent
    { 

        [Parameter]
        public TemplateForm TokenData { get; set; }
        [Parameter]
        public string MutableData { get; set; }

        NftTemplate TemplateData = new NftTemplate()
        {
            Name = TokenData.TokenBaseInfo.Name,
            Symbol = TokenData.TokenBaseInfo.Symbol,
            MintLimit = TokenData.TokenBaseInfo.MintLimit,
            AttachedTokens = TokenData.TokenBasInfo.AttachedTokens
        };

    }

}