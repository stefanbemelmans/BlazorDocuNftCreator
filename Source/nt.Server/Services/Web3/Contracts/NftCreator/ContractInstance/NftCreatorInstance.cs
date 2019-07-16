namespace nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance
{
  using System.IO;
  using nt.Shared.Constants;
  using Microsoft.AspNetCore.Components;
  using Nethereum.Contracts;
  using Nethereum.Web3;
  using nt.Server.Services.Web3.Web3Instance;

  public class NftCreatorInstance
    {
        public NftCreatorInstance(NethWeb3Instance aNethWeb3Instance)
        {
            NethWeb3Instance = aNethWeb3Instance;
            Contract NftCreatorContractInstance = NethWeb3Instance.instance.Eth.GetContract(NftCreatorAbi, NftCreatorAddresses.NftCreatorRinkebyAddress); 

        }
        string NftCreatorAbi = File.ReadAllText(@"C:\mv\nt\nt.Shared\Constants\ContractConstants\NftCreator\Abi.json;");

      NethWeb3Instance NethWeb3Instance { get; set; }
     public Contract NftCreatorContractInstance { get; set; }
    }

}
