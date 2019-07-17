namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTotalNftTypes
{
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Web3;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using MediatR;

  public class GetTotalNftTypesHandler : IRequestHandler<GetTotalNftTypesRequest, GetTotalNftTypesResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetTotalNftTypesHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetTotalNftTypesResponse> Handle(GetTotalNftTypesRequest aGetTotalNftTypesRequest, CancellationToken aCancellationToken)
    {
      Function totalNftsFunction = NftCreatorInstance.Instance.GetFunction("totalNFTs");

      var totalNftTypes = new GetTotalNftTypesResponse();

      int nfts =  await totalNftsFunction.CallAsync<int>();


      totalNftTypes.TotalNftTemplateTypes = nfts;
      return totalNftTypes;

    }
  }
}


