namespace nt.Server.Features.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using MediatR;
  using nt.Server.Services.WebThree.Contracts.NftCreator.AddNewTemplate;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate;
  using System.Threading;
  using System.Threading.Tasks;

  public class AddNewTemplateServerFeaturesHandler : IRequestHandler<AddNewTemplateSharedRequest, AddNewTemplateSharedResponse>
  {
    IMediator Mediator { get; set; }

    public AddNewTemplateServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public AddNewTemplateServerFeaturesHandler()
    {
    }

    public async Task<AddNewTemplateSharedResponse> Handle
    (
      AddNewTemplateSharedRequest aAddNewTemplateSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aNftRequest = new AddNewTemplateServiceRequest
      {
        NewNftTemplate = aAddNewTemplateSharedRequest.NewNftTemplate
      };




      AddNewTemplateServiceResponse response = await Mediator.Send(aNftRequest);

      return new AddNewTemplateSharedResponse
      {
        NewTemplateTransactionReceipt = response.NewTemplateTransactionReceipt  };
    }
  }
}