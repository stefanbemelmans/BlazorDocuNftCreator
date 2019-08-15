namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftByType
{
  using MediatR;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Features.WebThree;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetNftByTypeServerServiceHandler : IRequestHandler<GetNftByTypeServiceRequest, GetNftByTypeServiceResponse>
  {
    private NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftByTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftByTypeServiceResponse> Handle(GetNftByTypeServiceRequest aGetNftByTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function<GetNftByTypeServiceRequest> aGetNftByTypeFunction = NftCreatorInstance.Instance.GetFunction<GetNftByTypeServiceRequest>();

      var aGetNftByTypeFunctionMessage = new GetNftByTypeServiceRequest { GetNftId = aGetNftByTypeServiceRequest.GetNftId };

      GetNftByTypeServiceResponse aTemplate = await aGetNftByTypeFunction.CallDeserializingToObjectAsync<GetNftByTypeServiceResponse>(aGetNftByTypeFunctionMessage);

      return new GetNftByTypeServiceResponse()
      {
        Name = aTemplate.Name,
        Symbol = aTemplate.Symbol,
        MintLimit = (int)aTemplate.MintLimit,
        AttachedTokens = (int)aTemplate.AttachedTokens
      };

    }
  }
}