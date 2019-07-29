namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType
{
  using nt.Shared.Features.Base;
  using System.Numerics;

  public class MintNftOfTypeServiceResponse : BaseResponse
    {
    // No response for this function but an Event is emitted
    // This is trying to capture the event Data
    public string Operator { get; set; }

    public string From { get; set; }

    public string To { get; set; }

    public BigInteger Id { get; set; }

    public BigInteger Value { get; set; }
  }
}
