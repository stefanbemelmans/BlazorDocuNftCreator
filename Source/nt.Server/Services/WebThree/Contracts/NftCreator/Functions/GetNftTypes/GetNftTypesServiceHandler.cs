namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes
{
  using MediatR;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Shared.Constants.AccountAddresses;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetNftTypesServerServiceHandler : IRequestHandler<GetNftTypesServiceRequest, GetNftTypesServiceResponse>
  {
    private NftCreatorInstance NftCreatorInstance { get; set; }

    public GetNftTypesServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
    }

    public async Task<GetNftTypesServiceResponse> Handle(GetNftTypesServiceRequest aGetNftTypesServiceRequest, CancellationToken aCancellationToken)
    {
      Function totalNftsFunction = NftCreatorInstance.Instance.GetFunction("totalNFTs");

      var totalNfts = new GetNftTypesServiceResponse();

      uint nfts = await totalNftsFunction.CallAsync<uint>(
        from: TestEthAccounts.TestEthAccountAddress,
        gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000),
        new Nethereum.Hex.HexTypes.HexBigInteger(0)
        );

      totalNfts.TotalNftTypes = nfts;
      return totalNfts;
    }
  }
}