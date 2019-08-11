namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTokenNftType
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using MediatR;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Constants.AccountAddresses;

  public class GetTokenNftTypeServerServiceHandler : IRequestHandler<GetTokenNftTypeServiceRequest, GetTokenNftTypeServiceResponse>
    {
    NftCreatorInstance NftCreator { get; set; }

    public GetTokenNftTypeServerServiceHandler(NftCreatorInstance aNftCreatorInstance)
    {
      NftCreator = aNftCreatorInstance;
    }

    public async Task<GetTokenNftTypeServiceResponse> Handle(GetTokenNftTypeServiceRequest aGetTokenNftTypeServiceRequest, CancellationToken aCancellationToken)
    {
      Function tokenTypeFunction = NftCreator.Instance.GetFunction("tokenType");
      
      uint tokenType = await tokenTypeFunction.CallAsync<uint>(
        from: TestEthAccounts.TestEthAccountAddress,
        gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), 
        new Nethereum.Hex.HexTypes.HexBigInteger(0), 
        functionInput: aGetTokenNftTypeServiceRequest.TokenId
        );

      return new GetTokenNftTypeServiceResponse { TokensNftType = tokenType };
    }
  }
}


