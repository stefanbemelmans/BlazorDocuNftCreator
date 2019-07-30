namespace nt.Client.Features.WebThree.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System;
  using System.Collections.Generic;

  public class MintNftTemplateComponentModel : BaseComponent
  {
    
    public MintNftTemplateComponentModel()
    {
      BuildInputs();
    }

    public TemplateFormBase TokenTypeInfo { get; set; }

    public Dictionary<object, object> FormInputs;

    public void BuildInputs()
    {
      foreach (System.Reflection.PropertyInfo prop in TokenTypeInfo.GetType().GetProperties())
      {
        FormInputs.Add(prop.ToString(), prop.GetType());
      }
    }

    public void PrintValues()
    {
      foreach(System.Reflection.PropertyInfo prop in TokenTypeInfo.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.ToString()}: {prop.ToString()}"); 
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
    
