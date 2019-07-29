namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;
  using MediatR;
  using nt.Shared.Constants.AccountAddresses;
  using System.Collections.Generic;
  using Nethereum.Contracts.ContractHandlers;

  public class GetAllOwnedTokensServerServiceHandler : IRequestHandler<GetAllOwnedTokensServiceRequest, GetAllOwnedTokensServiceResponse>
  {
    Herc1155Instance Herc1155Instance { get; set; }

    public GetAllOwnedTokensServerServiceHandler(Herc1155Instance aHerc1155Instance)
    {
      Herc1155Instance = aHerc1155Instance;
    }
    public async Task<GetAllOwnedTokensServiceResponse> Handle(GetAllOwnedTokensServiceRequest aGetAllOwnedTokensServiceRequest, CancellationToken aCancellationToken)
    {
      Function<GetAllOwnedTokensFunctionInput> aGetAllOwnedTokensFunction = Herc1155Instance.Instance.GetFunction<GetAllOwnedTokensFunctionInput>();

      List<uint> response = await aGetAllOwnedTokensFunction.CallAsync<List<uint>>(
        new GetAllOwnedTokensFunctionInput
        {
          TokenOwner = TestEthAccounts.TestEthAccountAddress
        }
        );

      return new GetAllOwnedTokensServiceResponse
      {
        TokenIdList = response
      };

    }
  }
}


