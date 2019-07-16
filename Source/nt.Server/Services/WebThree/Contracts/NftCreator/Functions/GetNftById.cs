namespace nt.Client.Server.Services.WebThree.Contracts
{   // [Function("name", "return type")]
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Contracts;

    [Function(name: "getNFTData")] // This works
    public class GetNftByIdFunction : FunctionMessage
    {
        [Parameter("uint", "id", 1)]
        public int NftId { get; set; }
    }
}
