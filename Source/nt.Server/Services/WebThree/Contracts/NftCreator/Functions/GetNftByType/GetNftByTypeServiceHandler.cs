namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using MediatR;
  using nt.Shared.Features.WebThree;

  public class GetNftByTypeServerServiceHandler : IRequestHandler<GetNftByTypeServiceRequest, GetNftByTypeServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftByTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftByTypeServiceResponse> Handle(GetNftByTypeServiceRequest aGetNftByTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function<GetNftByTypeFunctionInput> aGetNftByTypeFunction = NftCreatorInstance.Instance.GetFunction<GetNftByTypeFunctionInput>();

      var aGetNftByTypeFunctionMessage = new GetNftByTypeFunctionInput { NftId = aGetNftByTypeServiceRequest.GetNftId };

      GetNftByTypeOutputDto aTemplate = await aGetNftByTypeFunction.CallDeserializingToObjectAsync<GetNftByTypeOutputDto>(aGetNftByTypeFunctionMessage);

      var response = new NftTemplate
      {
        Name = aTemplate.Name,
        Symbol = aTemplate.Symbol,
        MintLimit = (int)aTemplate.MintLimit,
        AttachedTokens = (int)aTemplate.AttachedTokens

      };

      return new GetNftByTypeServiceResponse { NftTypeData = response };
    }
  }
}


