namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.MintNftOfType
{
  using MediatR;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.Herc1155;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.MintNftOfType;
  using System.Threading;
  using System.Threading.Tasks;

  public class MintNftOfTypeServerServiceHandler : IRequestHandler<MintNftOfTypeServiceRequest, MintNftOfTypeServiceResponse>
  {
    private NethWeb3 NethWeb3 { get; set; }
    private NftCreatorInstance NftCreatorInstance { get; set; }

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

      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionInput
      {
        Type = aMintNftOfTypeServiceRequest.MintNftId,
        ImmutableDataString = aMintNftOfTypeServiceRequest.ImmutableDataString,
        MutableDataString = aMintNftOfTypeServiceRequest.MutableDataString
      };
      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await mintingHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

      aMintNftOfTypeFunctionMessage.Gas = gasEstimate.Value;

      Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await mintingHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

      System.Collections.Generic.List<EventLog<MintNftOutputEventDto>> MintNftOutput = mintingTransactionReceipt.DecodeAllEvents<MintNftOutputEventDto>();

      return new MintNftOfTypeServiceResponse
      {
        mintingTransactionReceipt = mintingTransactionReceipt
      };
    }
  }
}