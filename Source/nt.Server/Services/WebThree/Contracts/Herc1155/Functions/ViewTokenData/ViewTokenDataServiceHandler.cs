namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using System.Threading.Tasks;
  using System.Threading;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
  using nt.Shared.Features.WebThree.Contracts.Herc1155;
  using MediatR;

  public class ViewTokenDataServerServiceHandler : IRequestHandler<ViewTokenDataServiceRequest, ViewTokenDataServiceResponse>
  {
    Herc1155Instance Herc1155Instance { get; set; }

    public ViewTokenDataServerServiceHandler(Herc1155Instance aHerc1155Instance)
    {
      Herc1155Instance = aHerc1155Instance;
    }

    public async Task<ViewTokenDataServiceResponse> Handle(ViewTokenDataServiceRequest aViewTokenDataServiceRequest, CancellationToken aCancellationToken)
    {
      Function<ViewTokenDataFunctionInput> aViewTokenDataFunction = Herc1155Instance.Instance.GetFunction<ViewTokenDataFunctionInput>();

      string response = await aViewTokenDataFunction.CallAsync<string>(
        new ViewTokenDataFunctionInput
        {
          ViewTokenId = aViewTokenDataServiceRequest.ViewTokenId
        }
        );


      return

    }
  }
}


