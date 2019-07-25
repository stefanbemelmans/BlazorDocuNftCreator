namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using nt.Shared.Features.WebThree;
  using nt.Server.Services.WebThree.Contracts.NftCreator.AddNewTemplate;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;

  class AddNewTemplateTests
  {
    public AddNewTemplateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NftCreatorInstance NftCreator { get; }
    private NethWeb3 NethWeb3 { get; }
    public async Task ShouldAddNewNftTemplate()
    {
      // Arrange
      Function<AddNewTemplateFunctionInput> aAddNewTemplateFunction = NftCreator.Instance.GetFunction<AddNewTemplateFunctionInput>();

      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<AddNewTemplateFunctionInput> addNewTemplateFunctionHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<AddNewTemplateFunctionInput>();

      var aAddNewTemplateFunctionMessage = new AddNewTemplateFunctionInput
      {
        NewTemplateName = "TesterTemplate_0",
        NewTemplateSymbol = "TT0",
        NewTemplateAttachedTokens = 0,
        NewTemplateMintLimit = 1000
      };

      // Gas Estimates, needs to be tested

      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await addNewTemplateFunctionHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aAddNewTemplateFunctionMessage);

      aAddNewTemplateFunctionMessage.Gas = gasEstimate.Value;

      gasEstimate.Value.ShouldBeGreaterThan(0);



      //Nethereum.RPC.Eth.DTOs.TransactionReceipt mintingTransactionReceipt = await addNewTemplateFunctionHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aAddNewTemplateFunctionMessage);

      //return new AddNewTemplateServiceResponse
      //{
      //  NewTemplateTransactionReceipt = mintingTransactionReceipt
      //};

    }
  }
}
