namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;
  using MediatR;
  using System.Collections.Generic;

  public class GetAllTokensOfTypeServerServiceHandler : IRequestHandler<GetAllTokensOfTypeServiceRequest, GetAllTokensOfTypeServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetAllTokensOfTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetAllTokensOfTypeServiceResponse> Handle(GetAllTokensOfTypeServiceRequest aGetAllTokensOfTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function aGetAllTokensOfTypeFunction = NftCreatorInstance.Instance.GetFunction("getAllTokensofType");
      
      // The Solidity uses "uints" 

      uint TokenId = (uint)aGetAllTokensOfTypeServiceRequest.GetAllTokensOfType;
      var aGetAllTokensOfTypeFunctionMessage = new GetAllTokensOfTypeFunctionDef { GetAllTokensOfType = TokenId };

      GetAllTokensOfTypeOutputDto aTokenList = await aGetAllTokensOfTypeFunction.CallDeserializingToObjectAsync<GetAllTokensOfTypeOutputDto>(aGetAllTokensOfTypeFunctionMessage.GetAllTokensOfType);

      var tokenList = new List<int>();
      foreach(uint token in aTokenList.TokenList)
      {
        tokenList.Add((int)token);
      }

      return new GetAllTokensOfTypeServiceResponse { TokenList = tokenList };
    }
  }
}


