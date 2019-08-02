namespace nt.Shared.Features.WebThree.Contracts.Herc1155
{
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Contracts;
    using nt.Shared.Constants.AccountAddresses;

    [Function(name: "viewTokenData")] // This works
    public class ViewTokenDataFunctionInput : FunctionMessage
    {
        public ViewTokenDataFunctionInput()
        {
            FromAddress = TestEthAccounts.TestEthAccountAddress;
            Gas = new Nethereum.Hex.HexTypes.HexBigInteger(900000);
            AmountToSend = new Nethereum.Hex.HexTypes.HexBigInteger(0);
        }

        [Parameter(type: "uint", name: "_id", order: 1)]
        public uint ViewTokenId { get; set; }

    }
}
