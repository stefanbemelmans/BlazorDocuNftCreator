namespace nt.Client.Server.Services.WebThree.Contracts
{   // [Function("name", "return type")]
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Contracts;
    using System.Numerics;

    // Create a new NFT Template 
    // This Works
    [Function(name: "AddNFTTemplate")]
    public class AddNewNftTemplate : FunctionMessage
    {
        [Parameter("string", "name", 1)]
        public string NewNftTemplateName { get; set; }

        [Parameter("string", "symbol", 2)]
        public string NewNftTemplateSymbol { get; set; }

        [Parameter("uint", "mintlimit", 3)]
        public BigInteger NewNftTemplateMintLimit { get; set; }

        [Parameter("uint", "attachedTokens", 4)]
        public BigInteger NewNftTemplateAttachedTokens { get; set; }

    }
}
