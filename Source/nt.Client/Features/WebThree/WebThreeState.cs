namespace nt.Client.Features.WebThree
{
    using BlazorState;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree;
    using System.Collections.Generic;

    internal partial class WebThreeState : State<WebThreeState>
    {
        public WebThreeState() { }

        //public List<KeyValuePair<uint, uint>> BalanceByTokenId { get; set; }
        public List<TokenBase> TokenDataList { get; set; }

        public Dictionary<uint, uint> TokenBalances { get; set; }
        public uint TotalTokenTypes { get; set; }
        public List<uint> OwnedTokenIdList { get; set; }
        public uint CurrentTokenId { get; set; }
        public uint CurrentTokenNftType { get; set; } // CurrentTokenNftType will be used on the AssetNftPage
                                                      // "int" type becuase it's an index position.
                                                      // NftTemplate Id is index + 1

        public uint TotalNftTypes { get; set; }
        public int CurrentNftTypeIndex { get; set; } = 0;
        public NftTemplate CurrentNftTemplate { get; set; }// CurrentNftType will be used on the MintNftPage
        public int Balance { get; set; }                                      // public List<KeyValuePair<uint, NftTemplate>> NftIdxTypeKvpList { get; set; }
        public List<NftTemplate> TemplateDataList { get; set; }
        protected override void Initialize()
        {
            TotalTokenTypes = 0;
            OwnedTokenIdList = new List<uint>();
            CurrentTokenId = 0;
            Balance = 0;
            CurrentTokenNftType = 0;
            //BalanceByTokenId = new List<KeyValuePair<uint, uint>>();
            TokenDataList = new List<TokenBase>();
            TotalNftTypes = 0;
            //NftIdxTypeKvpList = new List<KeyValuePair<uint, NftTemplate>>();
            TemplateDataList = new List<NftTemplate>();
            TokenBalances = new Dictionary<uint, uint>();
            CurrentNftTemplate = new NftTemplate()
            {
                Name = "fillerName",
                Symbol = "stubSymbol",
                MintLimit = 42,
                AttachedTokens = 0
            };

        }


    }
}
