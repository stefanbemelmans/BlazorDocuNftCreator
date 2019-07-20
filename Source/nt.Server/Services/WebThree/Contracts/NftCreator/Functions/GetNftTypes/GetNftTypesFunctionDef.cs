namespace nt.Client.Server.Services.WebThree.Contracts
{
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Contracts;

    [Function(name: "totalNFTs", returnType: "uint")]
    public class GetNftTypesFunctionFunctionDef : FunctionMessage
    {
        // This is a call function on the Contract Variable "totalNFTs"
    }
}
