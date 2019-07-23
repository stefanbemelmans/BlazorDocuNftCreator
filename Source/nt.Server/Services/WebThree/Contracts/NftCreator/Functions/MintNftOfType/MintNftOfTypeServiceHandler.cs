namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using nt.Shared.Constants.ContractConstants.NftCreator;

  public class MintNftOfTypeServerServiceHandler : IRequestHandler<MintNftOfTypeServiceRequest, MintNftOfTypeServiceResponse>
    {
    NftCreatorInstance NftCreatorInstance { get; set; }
    NethWeb3 NethWeb3 { get; set; }

    public MintNftOfTypeServerServiceHandler(NethWeb3 aNethWeb3, NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
      NethWeb3 = aNethWeb3;
    }

    public async Task<MintNftOfTypeServiceResponse> Handle(MintNftOfTypeServiceRequest aMintNftOfTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function aMintNftOfTypeFunction = NftCreatorInstance.Instance.GetFunction("mintNFT");

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<MintNftOfTypeFunctionDef> mintingHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<MintNftOfTypeFunctionDef>();

      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionDef {
        Type = aMintNftOfTypeServiceRequest.MintNftId,
        ImmutableData = aMintNftOfTypeServiceRequest.ImmutableData.ToString(),
        MutableData = aMintNftOfTypeServiceRequest.MutableData.ToString()
      };

      Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await mintingHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

     

      return new MintNftOfTypeServiceResponse() ;
    }
  }
}


