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
      Function GetNftByTypeFunction = NftCreatorInstance.Instance.GetFunction("getNFTData");

      var GetNftByTypeFunctionMessage = new GetNftByTypeFunctionDef { NftId = aGetNftByTypeServiceRequest.GetNftId };

      int nfts =  await totalNftsFunction.CallAsync<int>();


      totalNfts.TotalNftTypes = nfts;
      return totalNfts;

    }
  }
}


