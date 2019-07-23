namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetAllTokensOfType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetAllTokensOfType;
  using MediatR;
  using System.Collections.Generic;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  public class GetAllTokensOfTypeServerServiceHandler : IRequestHandler<GetAllTokensOfTypeServiceRequest, GetAllTokensOfTypeServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetAllTokensOfTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetAllTokensOfTypeServiceResponse> Handle(GetAllTokensOfTypeServiceRequest aGetAllTokensOfTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function<GetAllTokensOfTypeFunctionDef> aGetAllTokensOfTypeFunction = NftCreatorInstance.Instance.GetFunction<GetAllTokensOfTypeFunctionDef>();
      
      // The Solidity uses "uints" 

      uint aTokenId = (uint)aGetAllTokensOfTypeServiceRequest.GetAllTokensOfType;
      //var aGetAllTokensOfTypeFunctionMessage = new GetAllTokensOfTypeFunctionDef { GetAllTokensOfType = aTokenId };

      GetAllTokensOfTypeOutputDto aTokenList = await aGetAllTokensOfTypeFunction.CallDeserializingToObjectAsync<GetAllTokensOfTypeOutputDto>(
      new GetAllTokensOfTypeFunctionDef
      {
        GetAllTokensOfType = aGetAllTokensOfTypeServiceRequest.GetAllTokensOfType
      }
      );

      var tokenList = new List<uint>();

      tokenList.AddRange(aTokenList.TokenList);

      return new GetAllTokensOfTypeServiceResponse { TokenList = tokenList };
    }
  }
}


