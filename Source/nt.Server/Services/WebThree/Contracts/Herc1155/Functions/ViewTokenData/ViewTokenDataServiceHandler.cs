namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;
  using AnySerializer;
  using MediatR;
  using nt.Shared.Constants.AccountAddresses;
  using System;

  public class ViewTokenDataServerServiceHandler : IRequestHandler<ViewTokenDataServiceRequest, ViewTokenDataServiceResponse>
  {
    Herc1155Instance Herc1155 { get; set; }

    public ViewTokenDataServerServiceHandler(Herc1155Instance aHerc1155Instance)
    {
      Herc1155 = aHerc1155Instance;
    }

    public async Task<ViewTokenDataServiceResponse> Handle(ViewTokenDataServiceRequest aViewTokenDataServiceRequest, CancellationToken aCancellationToken)
    {
      // using the functionMessage seems to error when it's a simple call. More research needed.
      Function aViewTokenDataFunction = Herc1155.Instance.GetFunction("viewTokenData");
      //(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), value: new Nethereum.Hex.HexTypes.HexBigInteger(0), functionInput: 3)

      Function tokenTypeFunction = Herc1155.Instance.GetFunction("tokenType");

      uint TokenType = await tokenTypeFunction.CallAsync<uint>(aViewTokenDataServiceRequest.ViewTokenId);

      string serializedBase64String = await aViewTokenDataFunction.CallAsync<string>(from: TestEthAccounts.TestEthAccountAddress, gas: new Nethereum.Hex.HexTypes.HexBigInteger(900000), value: new Nethereum.Hex.HexTypes.HexBigInteger(0), functionInput: aViewTokenDataServiceRequest.ViewTokenId);

      byte[] serializedImmutableData = Convert.FromBase64String(serializedBase64String);

      return new ViewTokenDataServiceResponse
      {
        SerializedTokenData = serializedImmutableData,
        TokenType = TokenType
      };

    }
  }
}


