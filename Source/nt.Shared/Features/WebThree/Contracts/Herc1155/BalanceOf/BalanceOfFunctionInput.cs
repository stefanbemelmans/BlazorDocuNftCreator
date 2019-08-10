namespace nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf
{
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using Nethereum.Web3.Accounts;
    using Nethereum.Contracts;
    using nt.Shared.Constants.AccountAddresses;

    [Function(name: "balanceOf")] // This works
    public class BalanceOfFunctionInput : FunctionMessage
    {
        [Parameter(type: "address", name: "owner", order: 1)]
        public string TokenOwner { get; set; }

        [Parameter(type: "uint", name: "id")]
        public uint TokenId { get; set; }
    }
}
