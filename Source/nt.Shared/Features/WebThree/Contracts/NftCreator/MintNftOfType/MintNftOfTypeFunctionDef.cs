namespace nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  // Mints the selected NFT template
  // Triggers Herc1155 Transfer Single Event
  [Function("mintNFT")]
  public class MintNftOfTypeFunctionDef : FunctionMessage
  {
    [Parameter(type: "uint", name: "type", 1)]
    public int Type { get; set; }

    [Parameter("string", "data", 2)]
    public string ImmutableData { get; set; }

    [Parameter("string", "mutabledata", 3)]
    public string MutableData { get; set; }

  }
}
