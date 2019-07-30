namespace nt.Client.Features.WebThree.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using System;

  public class TokenInfoComponentModel : BaseComponent
  {
    public TemplateFormBase TokenTypeInfo { get; set; }

    public uint TokenId { get; set; }

    public uint NftId { get; set; } 
    public NftTemplate TokenNftType { get; set; }

    public void PrintValues()
    {
      foreach(object obj in TokenTypeInfo){
        Console.WriteLine($"{obj.ToString()}: {obj.ToString()}"); 
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
    
