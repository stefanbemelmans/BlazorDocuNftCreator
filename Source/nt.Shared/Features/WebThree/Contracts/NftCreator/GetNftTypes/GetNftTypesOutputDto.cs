namespace nt.Shared.Features.WebThree
{   // [Function("name", "return type")]
    using Nethereum.ABI.FunctionEncoding.Attributes;

    [FunctionOutput] // This Works
    public class GetNftTypesFunctionOutputDTO : IFunctionOutputDTO
    {
        [Parameter(type: "uint", name: "totalNFTs", 1)]
        public int TotalNftTypes { get; set; }
    }
}
