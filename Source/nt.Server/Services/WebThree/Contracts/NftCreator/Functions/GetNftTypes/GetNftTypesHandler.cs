namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using MediatR;

  public class GetNftTypesHandler : IRequestHandler<GetNftTypesRequest, GetNftTypesResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftTypesHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftTypesResponse> Handle(GetNftTypesRequest aGetNftTypesRequest, CancellationToken aCancellationToken)
    {
      Function totalNftsFunction = NftCreatorInstance.Instance.GetFunction("totalNFTs");

      var totalNfts = new GetNftTypesResponse();

      int nfts =  await totalNftsFunction.CallAsync<int>();


      totalNfts.TotalNfts = nfts;
      return totalNfts;

    }
  }
}


