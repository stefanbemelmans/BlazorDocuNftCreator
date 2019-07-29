namespace nt.Client.Features.WebThree.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System;

  public class MintNftTemplateComponentModel : BaseComponent
  {
    // this is just for testing
    public TemplateFormBase TokenTypeInfo { get; set; }

    public void PrintValues()
    {
      foreach(object kvp in TokenTypeInfo)
      {
        Console.WriteLine($"{kvp.ToString()}: {kvp.ToString()}"); 
      }
    }

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
    
