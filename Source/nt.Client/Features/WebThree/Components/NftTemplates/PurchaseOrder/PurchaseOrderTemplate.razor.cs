namespace nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using System;
  using System.Collections.Generic;

  public class PurchaseOrderTemplateModel : BaseComponent
  {
    public PurchaseOrderTemplateModel()
    {
      FormData.Title = "Purchase Order";
    }
    [Parameter]
    public PurchaseOrderData FormData { get; set; } = new PurchaseOrderData();

    public string MutableDataString { get; set; }
    public void PrintValues()
    {
      foreach (string prop in FormData.PoFormValueNames)
      {
        Console.WriteLine(value: $"{prop}: {FormData.GetType().GetProperty(prop).GetValue(FormData)}");
      }
    }
  }
}