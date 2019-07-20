namespace nt.Client.Features.WebThree.Components
{
    using nt.Client.Features.Base.Components;

    public class NewNftTemplateFormModel : BaseComponent
    {
        public NftTemplate newNftTemplate = new NftTemplate();

        public string NewNftTemplateName { get; set; }

        public string NewNftTemplateSymbol { get; set; }

        public int NewNftTemplateMintLimit { get; set; }

        public int NewNftTemplateAttachedTokens { get; set; }



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
}