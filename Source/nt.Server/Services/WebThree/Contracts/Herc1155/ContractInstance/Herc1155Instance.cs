namespace nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance
{
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.Herc1155;
  //using nt.Shared.Constants.ContractConstants.Herc1155;
  public class Herc1155Instance
    {
      NethWeb3 NethWeb3 { get; set; }
      public Contract Instance { get; set; }
    
    //static StreamReader reader = new StreamReader(@"C:\mv\NewTimewarpTemplate\nt\Source\nt.Shared\Constants\ContractConstants\Herc1155\Abi.json");
    
      //readonly string NftCreatorAbi = reader.ReadToEnd();
      public Herc1155Instance(NethWeb3 aNethWeb3)
      {
        NethWeb3 = aNethWeb3;
        Instance = NethWeb3.Instance.Eth.GetContract(ContractAbi.Abi, Herc1155Addresses.RinkebyAddress);
    }
  }

}


