namespace nt.Server.Services.Web3.Web3Instance
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Nethereum.Web3;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Shared.Constants.WebThree;

  public class NethWeb3Instance
  {
    public NethWeb3Instance()
    {
      instance = new Web3(TestEthAccounts.TesterAcct, Web3Endpoints.RinkebyEndpoint);
    }

    public Web3 instance { get; set; }
  }

}
