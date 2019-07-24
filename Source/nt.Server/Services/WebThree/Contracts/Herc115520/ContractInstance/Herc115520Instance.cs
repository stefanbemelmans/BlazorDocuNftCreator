namespace nt.Server.Services.WebThree.Contracts.Herc115520.ContractInstance
{
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.Herc115520;
  //using nt.Shared.Constants.ContractConstants.Herc115520;
  public class Herc115520Instance
    {
      NethWeb3 NethWeb3 { get; set; }
      public Contract Instance { get; set; }
    
    //static StreamReader reader = new StreamReader(@"C:\mv\NewTimewarpTemplate\nt\Source\nt.Shared\Constants\ContractConstants\Herc115520\Abi.json");
    
      //readonly string NftCreatorAbi = reader.ReadToEnd();
      public Herc115520Instance(NethWeb3 aNethWeb3)
      {
        NethWeb3 = aNethWeb3;
        Instance = NethWeb3.Instance.Eth.GetContract(ContractAbi.Abi, Herc115520Adresses.RinkebyAddress);
    }
  }

}


