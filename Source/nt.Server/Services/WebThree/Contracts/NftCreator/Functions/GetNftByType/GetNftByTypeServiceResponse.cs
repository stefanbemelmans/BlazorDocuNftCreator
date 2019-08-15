namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;

  using Nethereum.ABI.FunctionEncoding.Attributes;

  [FunctionOutput]
  public class GetNftByTypeServiceResponse : IFunctionOutputDTO
  {
    [Parameter("string", "name", 1)]
    public string Name { get; set; }

    [Parameter("string", "symbol", 2)]
    public string Symbol { get; set; }

    [Parameter("uint", "mintlimit", 3)]
    public int MintLimit { get; set; }

    [Parameter("uint", "attachedTokens", 4)]
    public int AttachedTokens { get; set; }

  }
}
