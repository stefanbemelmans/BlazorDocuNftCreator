namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
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
      Function<MintNftOfTypeFunctionInput> aMintNftOfTypeFunction = NftCreatorInstance.Instance.GetFunction<MintNftOfTypeFunctionInput>();

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<MintNftOfTypeFunctionInput> mintingHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<MintNftOfTypeFunctionInput>();
            // serialization needed

      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionInput {
        Type = aMintNftOfTypeServiceRequest.MintNftId,
        ImmutableData = aMintNftOfTypeServiceRequest.ImmutableData.ToString(),
        MutableData = aMintNftOfTypeServiceRequest.MutableData.ToString()
      };
      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await mintingHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

      aMintNftOfTypeFunctionMessage.Gas = gasEstimate.Value;
      Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await mintingHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

      System.Collections.Generic.List<EventLog<MintNftOutputEventDto>> MintNftOutput = mintingTransactionReceipt.DecodeAllEvents<MintNftOutputEventDto>();


      return new MintNftOfTypeServiceResponse
      {
        
       
      };
    }
  }
}


