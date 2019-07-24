namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.AddNewTemplate
{
  using MediatR;
  using nt.Shared.Features.WebThree;

  public class AddNewTemplateServiceRequest : IRequest<AddNewTemplateServiceResponse>
    {
   public NftTemplate NewNftTemplate { get; set; }

  }
}
