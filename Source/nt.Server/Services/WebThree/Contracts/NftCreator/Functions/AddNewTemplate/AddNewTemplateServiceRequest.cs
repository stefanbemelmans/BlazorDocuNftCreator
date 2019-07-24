namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.AddNewTemplate
{
  using MediatR;

  public class AddNewTemplateServiceRequest : IRequest<AddNewTemplateServiceResponse>
    {
    public string NewTemplateName { get; set; }

    public string NewTemplateSymbol { get; set; }

    public int NewTemplateMintLimit { get; set; }

    public int NewTemplateAttachedTokens { get; set; }

  }
}
