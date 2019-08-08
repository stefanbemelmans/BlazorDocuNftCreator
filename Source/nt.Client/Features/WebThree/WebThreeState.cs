namespace nt.Client.Features.WebThree
{
    using BlazorState;
  using Nethereum.RPC.Eth.DTOs;
  using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree;
    using System.Collections.Generic;

    internal partial class WebThreeState : State<WebThreeState>
    {
        public WebThreeState() { }

        //public List<KeyValuePair<uint, uint>> BalanceByTokenId { get; set; }
        public List<TokenBase> TokenDataList { get; set; }
        
        public uint TotalTokenTypes { get; set; }
        public List<uint> OwnedTokenIdList { get; set; }
        public uint CurrentTokenId { get; set; }
        public TokenBase CurrentTokenData { get; set; }
        public uint CurrentTokenNftType { get; set; } // CurrentTokenNftType will be used on the AssetNftPage NftTemplate Id is index + 1
        public FormDto CollectedFormValues { get; set; }
    public TransactionReceipt MintingTransactionReceipt { get; set; }
        public uint TotalNftTypes { get; set; }
        public int CurrentNftTypeIndex { get; set; } = 0;
        public NftTemplate CurrentNftTemplate { get; set; }// CurrentNftType will be used on the MintNftPage
        public List<NftTemplate> TemplateDataList { get; set; }
        protected override void Initialize()
        {
            TotalTokenTypes = 0;
            TokenDataList = new List<TokenBase>();
            OwnedTokenIdList = new List<uint>();
            CurrentTokenId = 0;
            CurrentTokenData = null;
            CurrentTokenNftType = 0;
            TotalNftTypes = 0;
            TemplateDataList = new List<NftTemplate>();
            CurrentNftTemplate = new NftTemplate();

        }


    }
}
