namespace nt.Server.Services.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using MediatR;
  using nt.Shared.Features.WebThree;
  

  public class AddNewTemplateServiceRequest : IRequest<AddNewTemplateServiceResponse>
    {
   public AddNewTemplateServiceRequest()
    {
      NewNftTemplate = new NftTemplate();
    }
   public NftTemplate NewNftTemplate { get; set; }

  }
}
