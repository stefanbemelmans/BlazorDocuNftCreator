namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTotalNftTypes
{
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Web3;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Client.Server.Services.WebThree.Contracts;

  public class GetTotalNftTypesHandler
    {
    static Web3 Web3 { get; set; }

    NftCreatorInstance NftCreatorInstance = new NftCreatorInstance(Web3);

    public GetTotalNftTypesHandler(Web3 aWeb3)
    {
      Web3 = aWeb3;
    }

    public async Task<GetTotalNftTypesResponse> Handle(GetTotalNftTypesRequest aGetTotalNftTypesRequest, CancellationToken aCancellationToken)
    {
      Function TotalNftsFunction = NftCreatorInstance.NftCreatorContractInstance.GetFunction("totalNFTs");

      var TotalNftTypes = new GetTotalNftTypesResponse();

      int Nfts =  await TotalNftsFunction.CallAsync<int>();


      TotalNftTypes.TotalNftTemplateTypes = Nfts;
      return TotalNftTypes;

      }



    }


    }

