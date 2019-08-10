namespace nt.Client.Features.WebThree.Actions.AddFormDataToState
{
  using MediatR;
  using nt.Client.Features.WebThree.Components.NftTemplates;

  public class AddFormDataToStateAction : IRequest<WebThreeState>
  {
    public ImmutableObjectBase FormObjectValues { get; set; }
    public string MutableDataString { get; set; }
  }
}
