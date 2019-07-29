namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using MediatR;

  public class GetNftTypesServerServiceHandler : IRequestHandler<GetNftTypesServiceRequest, GetNftTypesServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftTypesServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftTypesServiceResponse> Handle(GetNftTypesServiceRequest aGetNftTypesServiceRequest, CancellationToken aCancellationToken)
    {
      Function totalNftsFunction = NftCreatorInstance.Instance.GetFunction("totalNFTs");

      var totalNfts = new GetNftTypesServiceResponse();

      uint nfts =  await totalNftsFunction.CallAsync<uint>();


      totalNfts.TotalNftTypes = nfts;
      return totalNfts;

    }
  }
}


