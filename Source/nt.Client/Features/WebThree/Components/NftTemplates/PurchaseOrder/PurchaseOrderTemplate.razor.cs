namespace nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using System.Threading.Tasks;

  public class PurchaseOrderTemplateModel : BaseComponent
  {
    [Parameter]
    public PurchaseOrderData FormData { get; set; } = new PurchaseOrderData();

    public string MutableDataString { get; set; }

    public PurchaseOrderTemplateModel()
    {
      FormData.Title = "Purchase Order";
    }

    public async void SendDataToState()
    {
      WebThreeState response = await Mediator.Send(new AddFormDataToStateAction()
      {
        FormObjectValues = FormData,
        MutableDataString = MutableDataString
      });

      WebThreeState.CollectedFormValues = response.CollectedFormValues;
     
    }
  }
}