namespace nt.Client.Features.Nft 
{

    public class NewFtTemplateFormModel : BaseComponent
    {
      NftTemplate newNftTemplate = new NftTemplate();

      string NewNftTemplateName { get; set; }

      string NewNftTemplateSymbol { get; set; }

      int NewNftTemplateMintLimit { get; set; }

      int NewNftTemplateAttachedTokens { get; set; }

    }


//public async Task AddNewNft()
//{

//    var url = RopstenWeb3.RinkebyEndpoint;
//    var NftCreatorAddress = NftCreator.NftCreatorRinkebyAddress;

//    var privateKey = RopstenWeb3.TestRopstenPrivateKey;
//    var account = new Account(privateKey);
//    var web3 = new Web3(account, url);

//    var testFromAddress = RopstenWeb3.TestRopstenAccountAddress;

//    Contract NftCreatorContract = web3.Eth.GetContract(NftCreator.Abi, NftCreatorAddress);

//    var AddNewNftFunction = NftCreatorContract.GetFunction("NFTTemplates");

//    var AddNewTemplateHandler = web3.Eth.GetContractTransactionHandler<AddNewNftTemplateFunction>();

//    var NewTemplateFunctionMessage = new AddNewNftTemplateFunction
//    {  

//        NewNftTemplateName = NewNftTemplateName,
//        NewNftTemplateSymbol = NewNftTemplateSymbol,
//        NewNftTemplateMintLimit = NewNftTemplateMintLimit,
//        NewNftTemplateAttachedTokens = NewNftTemplateAttachedTokens

//    };


//    NewTemplateFunctionMessage.Gas = new HexBigInteger(900000);

//    var transactionReceipt = await AddNewTemplateHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddress, NewTemplateFunctionMessage);

//    Console.WriteLine($"{transactionReceipt.TransactionHash}");

//   }
}