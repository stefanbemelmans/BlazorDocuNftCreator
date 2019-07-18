namespace nt.Client.Server.Services.WebThree.Contracts
{   // [Function("name", "return type")]
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Contracts;
    using System.Numerics;

    // Mints the selected NFT template
    // Triggers Herc1155 Transfer Single Event
    [Function("mintNFT")]
    public class MintNftTemplate : FunctionMessage 
    {
        [Parameter("uint", "type", 1)]
        public int Type { get; set; }

        [Parameter("string", "data", 2)]
        public string ImmutableData { get; set; }

        [Parameter("string", "mutabledata", 3)]
        public string MutableData { get; set; }

    }
}
