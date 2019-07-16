namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Featurs.Nft;
  
public class AssetNftPageModel : BaseComponent
  {
    public int HercBalance = 300;

    string Address;
    int NftType;
    int TotalNfts;

    NftTemplate NftTemplate = new NftTemplate();
  




  public async Task GetNftByType()
  {
      @*Console.WriteLine("GetNFT by Type function is hit.");
      var web3 = new Web3(RopstenWeb3.RinkebyEndpoint);

      Console.WriteLine(web3);

      Contract NftCreatorContract = web3.Eth.GetContract(NftCreator.Abi, NftCreator.NftCreatorRinkebyAddress);

      Console.WriteLine(NftCreatorContract.Address);

      var GetNftDataFunction = NftCreatorContract.GetFunction("getNFTData");

      Console.WriteLine(GetNftDataFunction);

      var result = await GetNftDataFunction.CallDeserializingToObjectAsync<GetNftByIdFunctionOutputDTO>(NftType);

      Console.WriteLine($"TokenName: {result.TokenName}, TokenSymbol: {result.TokenSymbol}, TokenMintLimit: {result.TokenMintLimit}, Token AttachedTokens: {result.TokenAttachedTokens} NFTData?");
      NftTemplate.Name = result.TokenName;
      NftTemplate.Symbol = result.TokenSymbol;
      NftTemplate.MintLimit = result.TokenMintLimit;
      NftTemplate.AttachedTokens*@ = result.TokenAttachedTokens;
   }

      

  }

}
