namespace nt.Server.Services.WebThree.Contracts
{   // [Event("event name")]
    using Nethereum.ABI.FunctionEncoding.Attributes;
    using System.Numerics;

    // [Parameter("type", "param_name", order num, true/false is Indexed?)]

    [Event("TransferSingle")]
    public class TransferEventDto : IEventDTO
    {
        [Parameter("address", "_operater", 1, true)]
        public string Operator { get; set; }

        [Parameter("address", "_from", 2, true)]
        public string From { get; set; }

        [Parameter("address", "_to", 3, true)]
        public string To { get; set; }

        [Parameter("uint256", "_id", 4, false)]
        public BigInteger Id { get; set; }

        [Parameter("uint256", "_value", 4, false)]
        public BigInteger Value { get; set; }

    }
}
