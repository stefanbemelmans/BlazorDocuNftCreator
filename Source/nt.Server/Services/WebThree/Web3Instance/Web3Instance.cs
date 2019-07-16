namespace nt.Server.Services.WebThree.Instance
{
    
  using Nethereum.Web3;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Shared.Constants.WebThree;

  public class NethWeb3
  {
    public NethWeb3()
    {
      Instance = new Web3(TestEthAccounts.TesterAcct, Web3Endpoints.RinkebyEndpoint);
    }

    public Web3 Instance { get; set; }
  }

}
