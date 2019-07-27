namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType
{
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using System.Collections.Generic;

  [FunctionOutput] 
  public class GetAllTokensOfTypeOutputDto : IFunctionOutputDTO
  {
    public GetAllTokensOfTypeOutputDto() { }

    [Parameter(type: "uint[100]", name: "List", 1)]
    public uint[] TokenList { get; set; }

  }
}
