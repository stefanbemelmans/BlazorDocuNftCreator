namespace nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using Nethereum.RPC.Eth.DTOs;
  using nt.Shared.Features.Base;
  using System.Numerics;

  public class WebThreeState : BaseResponse
  {
    public TransactionReceipt MintingTransactionReceipt { get; set; }

    //public string Operator { get; set; }

    //public string From { get; set; }

    //public string To { get; set; }

    //public BigInteger Id { get; set; }

    //public BigInteger Value { get; set; }
  }
}
