namespace nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using System;
  using System.Threading.Tasks;

  public class PurchaseOrderTemplateModel : BaseComponent
  {
    public PurchaseOrderTemplateModel()
    {
      //FormData = new PurchaseOrderData();
    }
    
    public string MutableDataString { get; set; }

    public PurchaseOrderData FormData = new PurchaseOrderData();
    public async void SendDataToState()
    {
      ConsoleData();
      WebThreeState response = await Mediator.Send(new AddFormDataToStateAction()
      {
        FormObjectValues = FormData,
        MutableDataString = MutableDataString
      });

    }

    public void ConsoleData()
    {
      Console.WriteLine("Trying to Console...empty?");
      foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
      }
    }
  }
  public class PurchaseOrderData : ImmutableObjectBase
  {
    public string Approver { get; set; }

    public DateTime DeliveryDate { get; set; } = DateTime.Now;

    public string Department { get; set; }

    public string Item_Code { get; set; }

    public int Item_Discount { get; set; }

    public string Item_Name { get; set; }

    public string Item_Price { get; set; }

    public int Item_Qty { get; set; }

    public int Item_Total { get; set; }

    public string Notes { get; set; }

    public string Requester { get; set; }
  }

}