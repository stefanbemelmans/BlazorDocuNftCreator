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
  using nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetNftTypes;
  using nt.Shared.Constants.AccountAddresses;

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

      var getNftRequest = new GetNftTypesServiceRequest();

      GetNftTypesServiceResponse totalTypesBeforeTest = await Mediator.Send(getNftRequest);

      //var aAddNewTemplateFunctionMessage = new AddNewTemplateFunctionInput
      // Ropsten NFT 1
      //{
      //  NewTemplateName = "Purchase Order",
      //  NewTemplateSymbol = "POR",
      //  NewTemplateAttachedTokens = 0,
      //  NewTemplateMintLimit = 1,
      //  FromAddress = TestEthAccounts.TestEthAccountAddress
      //};
      // Ropsten NFT 2
      //{
      //  NewTemplateName = "Purchase Requeset",
      //  NewTemplateSymbol = "PRQ",
      //  NewTemplateAttachedTokens = 0,
      //  NewTemplateMintLimit = 1
      //};

      //Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await addNewTemplateFunctionHandler.EstimateGasAsync(NftCreatorAddresses.NewNftCreatorRopstenAddress, aAddNewTemplateFunctionMessage);

      //aAddNewTemplateFunctionMessage.Gas = gasEstimate.Value; 
      //gasEstimate.Value.ShouldBeGreaterThan(0);
      //Leaving this commented out as this is the action that makes a new template
      // it's been tested and works

      //Nethereum.RPC.Eth.DTOs.TransactionReceipt addingTemplateTransactionReceipt = await addNewTemplateFunctionHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NewNftCreatorRopstenAddress, aAddNewTemplateFunctionMessage);

      //addingTemplateTransactionReceipt.ShouldNotBe(null);


      GetNftTypesServiceResponse totalTypesAfterTest = await Mediator.Send(getNftRequest);


      totalTypesAfterTest.TotalNftTypes.ShouldBeGreaterThan(totalTypesBeforeTest.TotalNftTypes);
    }
  }
}
