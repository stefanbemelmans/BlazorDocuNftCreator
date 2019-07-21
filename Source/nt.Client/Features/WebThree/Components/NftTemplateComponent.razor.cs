namespace nt.Client.Features.WebThree.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  public class NftTemplateComponentModel : BaseComponent
  {

     public NftTemplate NftTemplate { get; set; }

   


    //AddNewNftTemplateFunction AddNewNftFunction = NftCreatorContract.GetFunction("NFTTemplates");

    //var AddNewTemplateHandler = web3.Eth.GetContractTransactionHandler<MintNftFunction>
    //();

    //public async Task MintNft()
    //{

    //NewTemplateFunctionMessage.Gas = new HexBigInteger(900000);

    //var transactionReceipt = await AddNewTemplateHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddress, NewTemplateFunctionMessage);

    //Console.WriteLine($"{transactionReceipt.TransactionHash}");

  }
}
    
