namespace nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance
{
  using System.Text.Encodings;
  using System.IO;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;

  public class NftCreatorInstance
    {
      NethWeb3 NethWeb3 { get; set; }
      public Contract Instance { get; set; }
    
    //static StreamReader reader = new StreamReader(@"C:\mv\NewTimewarpTemplate\nt\Source\nt.Shared\Constants\ContractConstants\Herc115520\Abi.json");
    
      //readonly string NftCreatorAbi = reader.ReadToEnd();
      public NftCreatorInstance(NethWeb3 aNethWeb3)
      {
          NethWeb3 = aNethWeb3;
          Instance = NethWeb3.Instance.Eth.GetContract(ContractAbi.Abi,  NftCreatorAddresses.NftCreatorRinkebyAddress); 
      }
  }

}


