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

    NethWeb3 NethWeb3 { get; set; }

    public GetTotalNftTypesHandler(NethWeb3 aNethWeb3, NftCreatorInstance aNftCreatorInstance)
    {
      NethWeb3 = aNethWeb3;
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetTotalNftTypesResponse> Handle(GetTotalNftTypesRequest aGetTotalNftTypesRequest, CancellationToken aCancellationToken)
    {
      Function TotalNftsFunction = NftCreatorInstance.Instance.GetFunction("totalNFTs");

      var TotalNftTypes = new GetTotalNftTypesResponse();

      int Nfts =  await TotalNftsFunction.CallAsync<int>();


      TotalNftTypes.TotalNftTemplateTypes = Nfts;
      return TotalNftTypes;

    }
  }
}


