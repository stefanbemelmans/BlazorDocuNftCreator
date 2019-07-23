namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using MediatR;

  public class GetNftByTypeServerServiceHandler : IRequestHandler<GetNftByTypeServiceRequest, GetNftByTypeServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftByTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftByTypeServiceResponse> Handle(GetNftByTypeServiceRequest aGetNftByTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function aGetNftByTypeFunction = NftCreatorInstance.Instance.GetFunction("getNFTData");

      var aGetNftByTypeFunctionMessage = new GetNftByTypeFunctionInput { NftId = aGetNftByTypeServiceRequest.GetNftId };

      GetNftByTypeOutputDto aTemplate = await aGetNftByTypeFunction.CallDeserializingToObjectAsync<GetNftByTypeOutputDto>(aGetNftByTypeFunctionMessage.NftId);

      var response = new NftTemplate
      {
        Name = aTemplate.TokenName,
        Symbol = aTemplate.TokenSymbol,
        MintLimit = aTemplate.TokenMintLimit,
        AttachedTokens = aTemplate.TokenAttachedTokens

      };

      return new GetNftByTypeServiceResponse { NftTypeData = response };
    }
  }
}


