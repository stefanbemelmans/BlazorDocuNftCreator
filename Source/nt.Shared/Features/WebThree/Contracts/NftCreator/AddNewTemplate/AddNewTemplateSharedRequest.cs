namespace nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using nt.Shared.Features.Base;
  using MediatR;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  public class AddNewTemplateSharedRequest : BaseRequest, IRequest<GetNftByTypeSharedResponse>
  {
    public const string Route = "api/AddNewTemplate";

    public static string RouteFactory(int aId) => $"api/AddNewTemplate?MintNftType={aId}";
    public string NewTemplateName { get; set; }

    public string NewTemplateSymbol { get; set; }

    public int NewTemplateMintLimit { get; set; }

    public int NewTemplateAttachedTokens { get; set; }
  }

}
