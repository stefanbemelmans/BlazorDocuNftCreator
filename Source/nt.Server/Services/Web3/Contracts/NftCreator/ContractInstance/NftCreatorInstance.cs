using System.IO;
using nt.Shared.Constants;
using Microsoft.AspNetCore.Components;
using Nethereum.Contracts;
using Nethereum.Web3;

namespace nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance
{
    public class NftCreatorInstance
    {
        public NftCreatorInstance(Web3 aWeb3Instance)
        {
            Web3 = aWeb3Instance;
            Contract NftCreatorContractInstance = Web3.Eth.GetContract(NftCreatorAbi, NftCreatorAddresses.NftCreatorRinkebyAddress); 

        }
        string NftCreatorAbi = File.ReadAllText(@"C:\mv\nt\nt.Shared\Constants\ContractConstants\NftCreator\Abi.json;");
     
       Web3 Web3 { get; set; }
     public Contract NftCreatorContractInstance { get; set; }
    }

}
