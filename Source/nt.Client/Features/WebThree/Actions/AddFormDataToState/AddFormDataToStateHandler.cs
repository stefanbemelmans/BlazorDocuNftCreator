namespace nt.Client.Features.WebThree
{
  using BlazorState;
  using nt.Client.Features.Base;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class WebThreeState : State<WebThreeState>
  {
    public class AddFormDataToStateHandler : BaseHandler<AddFormDataToStateAction, WebThreeState>
    {
      public AddFormDataToStateHandler(IStore aStore) : base(aStore) { }

      public override Task<WebThreeState> Handle
        (
        AddFormDataToStateAction aAddFormDataToStateRequest,
        CancellationToken aCancellationToken
        )
      {
        ImmutableObjectBase formValues = aAddFormDataToStateRequest.FormObjectValues;

        WebThreeState.MutableDataString = aAddFormDataToStateRequest.MutableDataString;
        WebThreeState.ImmutableObject = formValues;

        
        return Task.FromResult(WebThreeState);

      }
    }
  }
}