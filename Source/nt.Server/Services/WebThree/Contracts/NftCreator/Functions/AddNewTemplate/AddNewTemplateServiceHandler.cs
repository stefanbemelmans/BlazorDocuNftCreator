﻿namespace nt.Server.Services.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using MediatR;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate;

  public class AddNewTemplateServerServiceHandler : IRequestHandler<AddNewTemplateServiceRequest, AddNewTemplateServiceResponse>
  {
    NftCreatorInstance NftCreatorInstance { get; set; }
    NethWeb3 NethWeb3 { get; set; }

    public AddNewTemplateServerServiceHandler(NethWeb3 aNethWeb3, NftCreatorInstance aNftCreatorInstance)
    {
      NftCreatorInstance = aNftCreatorInstance;
      NethWeb3 = aNethWeb3;
    }

    public async Task<AddNewTemplateServiceResponse> Handle(AddNewTemplateServiceRequest aAddNewTemplateServiceRequest, CancellationToken aCancellationToken)
    {
      Function<AddNewTemplateFunctionInput> aAddNewTemplateFunction = NftCreatorInstance.Instance.GetFunction<AddNewTemplateFunctionInput>();

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<AddNewTemplateFunctionInput> addNewTemplateFunctionHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<AddNewTemplateFunctionInput>();

      var aAddNewTemplateFunctionMessage = new AddNewTemplateFunctionInput
      {
        NewTemplateName = aAddNewTemplateServiceRequest.NewTemplateName,
        NewTemplateSymbol = aAddNewTemplateServiceRequest.NewTemplateSymbol,
        NewTemplateAttachedTokens = aAddNewTemplateServiceRequest.NewTemplateAttachedTokens,
        NewTemplateMintLimit = aAddNewTemplateServiceRequest.NewTemplateMintLimit
      };

      // Gas Estimates, needs to be tested

      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await addNewTemplateFunctionHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aAddNewTemplateFunctionMessage);

      aAddNewTemplateFunctionMessage.Gas = gasEstimate.Value;

      Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await addNewTemplateFunctionHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aAddNewTemplateFunctionMessage);

      return new AddNewTemplateServiceResponse
      {
        NewTemplateTransactionReceipt = mintingTransactionReceipt
      };
    }
  }
}
