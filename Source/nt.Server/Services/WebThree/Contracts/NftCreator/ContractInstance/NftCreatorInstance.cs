namespace nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance
{
  using System.IO;
  using nt.Shared.Constants;
  using Microsoft.AspNetCore.Components;
  using Nethereum.Contracts;
  using Nethereum.Web3;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;

  public class NftCreatorInstance
    {
        public NftCreatorInstance(NethWeb3 aNethWeb3)
        {
            NethWeb3 = aNethWeb3;
            Instance = NethWeb3.Instance.Eth.GetContract(NftCreatorAbi, NftCreatorAddresses.NftCreatorRinkebyAddress); 

        }

    readonly string NftCreatorAbi = File.ReadAllText(@"C:\mv\nt\nt.Shared\Constants\ContractConstants\NftCreator\Abi.json;");

      NethWeb3 NethWeb3 { get; set; }
     public Contract Instance { get; set; }
    }

}
